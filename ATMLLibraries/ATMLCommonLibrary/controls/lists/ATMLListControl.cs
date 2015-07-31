/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary;
using ATMLUtilitiesLibrary;
using WeifenLuo.WinFormsUI.Docking;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ATMLListControl : ATMLControl
    {
        #region Delegates

        public delegate void CompletedAddDelegate(object obj);

        public delegate void CompletedDeleteDelegate(object obj);

        public delegate void CompletedEditDelegate(object obj);

        public delegate void FormInitializationDelegate(Form form);

        public delegate void OnAddDelegate();

        public delegate void OnDeleteDelegate();

        public delegate void OnEditDelegate();

        public delegate void OnFindDelegate();

        public delegate void OnIndexChangedDelegate(object sender, EventArgs e);

        #endregion

        #region Events

        public event OnAddDelegate OnAdd;
        public event OnEditDelegate OnEdit;
        public event OnDeleteDelegate OnDelete;
        public event OnFindDelegate OnFind;

        public event CompletedAddDelegate CompletedAdd;
        public event CompletedEditDelegate CompletedEdit;
        public event CompletedDeleteDelegate CompletedDelete;
        public event FormInitializationDelegate InitializeForm;
        public event OnIndexChangedDelegate SelectedIndexChanged;
        public event EventHandler SequenceChanged;

        #endregion
        private ICollection _data;
        private Type _dataType;
        private readonly List<Tuple<string, string, double>> _columnData = new List<Tuple<string, string, double>>();
        private readonly List<string> _fieldNames = new List<string>();
        private readonly List<double> _fieldWidths = new List<double>();
        private readonly Dictionary<ListViewItem, Form> _openForms = new Dictionary<ListViewItem, Form>();

        private readonly ListViewColumnSorter lvwColumnSorter;
        private bool _allowRowResequencing;

        /** Form Class Type for list items */
        private Type _dataObjectFormType;

        /** The name of the data object located in the form specified by the DataObjectFormType */
        private String _dataObjectName;

        protected String _filter;
        private String _formTitle;

        protected String _listName;

        public ATMLListControl()
        {
            InitializeComponent();
            lvList.SelectedIndexChanged += lvList_SelectedIndexChanged;
            lvList.Resize += lvList_Resize;
            lvList.View = View.Details;
            lvList.FullRowSelect = true;
            toolStrip.Renderer = new MyRenderer();
            SetButtonstates();
            lvwColumnSorter = new ListViewColumnSorter();
            lvList.ListViewItemSorter = lvwColumnSorter;
            lvList.DoubleClick += lvList_DoubleClick;
            ATMLContext.PropertyChanged += AtmlContextOnPropertyChanged;
        }

        public void Initialize(Type dataType, Type formType, params Tuple<string, string, double>[] columns)
        {
            _dataType = dataType;
            DataObjectName = dataType.Name;
            DataObjectFormType = formType;
            foreach (Tuple<string, string, double> column in columns)
            {
                AddColumnData(column.Item1, column.Item2, column.Item3);
            }
            InitColumns();
        }


        public String TooltipTextAddButton
        {
            set { btnAdd.ToolTipText = value; }
            get { return btnAdd.ToolTipText; }
        }

        public String TooltipTextEditButton
        {
            set { btnEdit.ToolTipText = value; }
            get { return btnEdit.ToolTipText; }
        }

        public String TooltipTextDeleteButton
        {
            set { btnDelete.ToolTipText = value; }
            get { return btnDelete.ToolTipText; }
        }

        protected override void DestroyHandle()
        {
            ATMLContext.PropertyChanged -= AtmlContextOnPropertyChanged;
            base.DestroyHandle();
        }

        private void AtmlContextOnPropertyChanged(object sender, EventArgs eventArgs)
        {
            foreach (ListViewItem lvi in Items)
                lvi.BackColor = lvi.Index%2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
        }

        /** Default contstructor for the ATMLListControl class */

        public void Clear()
        {
            lvList.Items.Clear();
        }

        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (OnEdit != null)
                    OnEdit();
                else if (_dataObjectFormType != null && _dataObjectName != null)
                {
                    EditSelectedObject(_dataObjectFormType, _dataObjectName);
                }
            }
            catch (Exception error)
            {
                LogManager.Error( error );
            }
        }

        protected virtual void OnOnFind()
        {
            OnFindDelegate handler = OnFind;
            if (handler != null) handler();
        }

        protected virtual void OnInitializeForm(Form form)
        {
            FormInitializationDelegate handler = InitializeForm;
            if (handler != null) handler(form);
        }

        protected virtual void OnCompletedDelete(object obj)
        {
            CompletedDeleteDelegate handler = CompletedDelete;
            if (handler != null) handler(obj);
        }

        protected virtual void OnCompletedEdit(object obj)
        {
            CompletedEditDelegate handler = CompletedEdit;
            if (handler != null) handler(obj);
        }

        protected virtual void OnCompletedAdd(object obj)
        {
            CompletedAddDelegate handler = CompletedAdd;
            if (handler != null) handler(obj);
        }

        private void lvList_Resize(object sender, EventArgs e)
        {
            try
            {
                if (_fieldWidths.Count > 0)
                    SetDistributedColumnWidths(_fieldWidths.ToArray());
            }
            catch (Exception exception)
            {
                LogManager.Error( exception );
            }
        }

        public void AddColumnData(String columnName, String fieldName, Double columnWidth)
        {
            _columnData.Add(new Tuple<string, string, double>(columnName, fieldName, columnWidth));
        }

        public void InitColumns()
        {
            foreach (var columnName in _columnData)
            {
                Columns.Add(columnName.Item1);
                _fieldNames.Add(columnName.Item2);
                _fieldWidths.Add(columnName.Item3);
            }
        }

        public bool RemoveSelectedItem(String name, String value)
        {
            bool removed = false;
            if (HasSelected)
            {
                String prompt = MessageManager.getMessage(MessageManager.GENERIC_DELETE_PROMPT);
                String title = MessageManager.getMessage(MessageManager.GENERIC_TITLE_VERIFICATION);
                if (DialogResult.Yes == MessageBox.Show(String.Format(prompt, name, value),
                                                        title,
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question))
                {
                    lvList.Items.Remove(SelectedListViewItem);
                    removed = true;
                }
            }
            return removed;
        }

        protected virtual void OnSequenceChanged()
        {
            EventHandler handler = SequenceChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
            SetButtonstates();
        }

        private void SetButtonstates()
        {
            bool hasSelected = HasSelected;
            btnEdit.Visible = hasSelected;
            btnDelete.Visible = hasSelected;
            btnMoveUp.Enabled = hasSelected && lvList.SelectedItems[0].Index > 0;
            btnMoveDown.Enabled = hasSelected && lvList.SelectedItems[0].Index < (lvList.Items.Count - 1);
        }

        public void RemoveSelectedItem()
        {
            if (HasSelected)
            {
                int idx = lvList.SelectedItems[0].Index;
                lvList.SelectedItems[0].Remove();
                if ((idx - 1) >= 0)
                    lvList.Items[(idx - 1)].Selected = true;
            }
        }

        public void SetAddButtonTooltip(String tip)
        {
            btnAdd.ToolTipText = tip;
        }

        public void SetEditButtonTooltip(String tip)
        {
            btnEdit.ToolTipText = tip;
        }

        public void SetDeleteButtonTooltip(String tip)
        {
            btnDelete.ToolTipText = tip;
        }

        public void AddButton(ToolStripButton button)
        {
            toolStrip.Items.Add(button);
        }

        public void Populate<T>(ICollection<T> data)
        {
            if (data != null)
            {
                Items.Clear();
                foreach (T obj in data)
                {
                    AddListViewObject(obj);
                }
            }
        }

        public List<T> Harvest<T>()
        {
            List<T> data = null;
            if (lvList.Items.Count > 0)
            {
                data = (from ListViewItem lvi in lvList.Items select (T) lvi.Tag).ToList();
            }
            return data;
        }


        public void SetDistributedColumnWidths()
        {
            if (lvList.Columns.Count > 0)
            {
                int width = lvList.Width;
                int cols = lvList.Columns.Count;
                var colWidth = (int) (width/(double) cols);
                for (int i = 0; i < cols; i++)
                {
                    if (i == (cols - 1))
                        lvList.Columns[i].Width = width - ((cols - 1)*colWidth);
                    else
                        lvList.Columns[i].Width = colWidth;
                }
            }
        }

        public void SetDistributedColumnWidths(double[] columnWeights)
        {
            if (columnWeights.Length != lvList.Columns.Count)
                throw new Exception(
                    string.Format( "Programming Error: SetDistributedColumnWidths provided column widths do not match actual number of columns. Column Weights: {0}, Column Count {1}, Name: {2}", columnWeights.Length, lvList.Columns.Count, this.Name ) );
            double totalWidth = 0;
            StringBuilder s = new StringBuilder("{");
            foreach (double d in columnWeights)
            {
                totalWidth += d;
                s.Append( d ).Append( ", " );
            }


            if (totalWidth > 1d )
            {
                string name = this.Name;
                if (s.ToString().EndsWith(", "))
                    s.Length = s.Length - 2;
                s.Append("}");
                throw new Exception(
                    string.Format( "Programming Error: List: {0} The total column width weights provided excede 100%, {1} <> {2}", 
                                    name, s, totalWidth ) );
            }

            if (lvList.Columns.Count > 0)
            {
                int width = lvList.Width;
                int cols = lvList.Columns.Count;
                int totalPriorWidths = 0;
                for (int i = 0; i < cols; i++)
                {
                    var colWidth = (int) (width*columnWeights[i]);
                    if (i == (cols - 1))
                        lvList.Columns[i].Width = width - totalPriorWidths;
                    else
                        totalPriorWidths += lvList.Columns[i].Width = colWidth;
                }
            }
        }


        protected void DeleteSelectedObject(String dataObjectName)
        {
            object obj = SelectedObject;
            if (obj != null)
            {
                if( RemoveSelectedItem(dataObjectName, obj.ToString()) )
                    OnCompletedDelete(obj);
            }
        }


        protected void AddObject(Type type, String dataObjectName)
        {
            object instance = Activator.CreateInstance(type);
            if (instance is ATMLForm)
            {
                var form = (ATMLForm) instance;
                if (!form.IsDisposed)
                {
                    OnInitializeForm(form);
                    if (!string.IsNullOrWhiteSpace(_formTitle))
                        form.Text = @"New " + _formTitle;

                    RegisterForm(form);
                    form.Saved += delegate(object sndr, EventArgs ee)
                    {
                        try
                        {
                            var f = sndr as Form;
                            if (f != null)
                            {
                                PropertyInfo pi = f.GetType().GetProperty(dataObjectName);
                                if (pi == null)
                                    throw new Exception(string.Format("Invalid Data Object Name [{0}] in Form [{1}]",
                                                                      dataObjectName, form.GetType().Name));
                                object obj = pi.GetValue(f, null);
                                if (obj == null)
                                    return;

                                string key = obj.ToString();
                                pi = obj.GetType().GetProperty("uuid");
                                if (pi != null)
                                    key = (string) pi.GetValue(obj, null);
                                if (pi == null || !lvList.Items.ContainsKey(key)) //only check for duplicate uuid
                                {
                                    AddListViewObject(obj);
                                }
                                else
                                {
                                    LogManager.Debug("Attempting to add a duplicate object {0} to the list. This is usually caused by editing an already saved ADD.", dataObjectName);
                                }
                                if (ValidateChildren(ValidationConstraints.Enabled))
                                    OnCompletedAdd(obj);
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(@"Error: " + err.Message, @"E R R O R");
                        }
                    };
                    form.Closed += delegate( object sndr, EventArgs ee )
                                   {
                                       UnRegisterForm((Form) sndr);
                                   };

                    form.Show();    
                }
            }
        }

        public static string SerializeObject<T>(T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof (T));
            var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        public int AddListViewObject(object obj)
        {
            int idx = -1;
            string key = obj.ToString();
            PropertyInfo piObject = obj.GetType().GetProperty("uuid");
            if (piObject != null)
                key = (string) piObject.GetValue(obj, null);

            if (TestFilter(obj.ToString()))
            {
                ListViewItem lvi = null;
                foreach (string fieldName in _fieldNames)
                {
                    Type objType = obj.GetType();
                    PropertyInfo piField = objType.GetProperty(fieldName);
                    if (piField == null && !"Type".Equals(fieldName) && !"ToString()".Equals(fieldName))
                        throw new Exception("Invalid Field Name: " + fieldName);
                    object fieldValue = "ToString()".Equals(fieldName)
                                            ? obj.ToString()
                                            : (piField == null && "Type".Equals(fieldName)
                                                   ? obj.GetType().Name
                                                   : piField != null ? piField.GetValue(obj, null) : null);
                    string value = GetFieldValue( fieldValue );
                    if (lvi == null)
                        lvi = new ListViewItem(value);
                    else
                        lvi.SubItems.Add(value);
                }
                if (lvi != null)
                {
                    lvi.Tag = obj;
                    lvi.Name = key;
                    idx = lvList.Items.Add(lvi).Index;
                    lvi.BackColor = idx%2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
                }
            }
            return idx;
        }

        private static string GetFieldValue( object fieldValue )
        {
            string value = "";
            if (fieldValue != null)
            {
                if (fieldValue is DateTime)
                {
                    if (!( (DateTime) fieldValue ).Equals( DateTime.MinValue )
                        && !( (DateTime) fieldValue ).Equals( DateTime.MaxValue ))
                    {
                        value = ( (DateTime) fieldValue ).ToShortDateString();
                    }
                    else
                    {
                        value = null;
                    }
                }
                else
                {
                    value = fieldValue.ToString();
                }
            }
            return value;
        }

        protected void EditSelectedObject(Type _type, String dataObjectName)
        {
            if (HasSelected)
            {
                HourGlass.Start();
                ListViewItem lvi = SelectedListViewItem;
                if (_openForms.ContainsKey(SelectedListViewItem))
                {
                    Form f = _openForms[SelectedListViewItem];
                    if (f.IsDisposed)
                    {
                        _openForms.Remove( SelectedListViewItem );
                    }
                    else
                    {
                        _openForms[SelectedListViewItem].Focus();
                        HourGlass.Stop();
                        return;
                    }
                }

                object instance = Activator.CreateInstance(_type);
                if (instance is ATMLForm)
                {
                    var form = (ATMLForm) instance;
                    form.Tag = SelectedListViewItem;
                    if (!form.IsDisposed)
                    {
                        OnInitializeForm(form);
                        if (!string.IsNullOrWhiteSpace(_formTitle))
                            form.Text = @"Change " + _formTitle;

                        RegisterForm(form);
                        _openForms.Add(SelectedListViewItem, form);
                        PropertyInfo pi = form.GetType().GetProperty(dataObjectName);
                        if (pi == null)
                            throw new Exception("Invalid Object Name: " + dataObjectName);
                        if (SelectedObject is BASEBean)
                            ((BASEBean) SelectedObject).DataState = BASEBean.eDataState.DS_EDIT;
                        else if (SelectedObject is ATMLCommon)
                            ((ATMLCommon) SelectedObject).DataState = BASEBean.eDataState.DS_EDIT;
                        pi.SetValue(form, SelectedObject, null);
                        form.Saved += delegate(object sndr, EventArgs ee)
                        {
                            try
                            {
                                var f = sndr as Form;
                                if (f != null)
                                {
                                    pi = f.GetType().GetProperty(dataObjectName);
                                    if (pi == null)
                                        throw new Exception("Invalid Object Name: " + dataObjectName);
                                    object obj = pi.GetValue(f, null);
                                    if (obj == null)
                                        throw new Exception(
                                            string.Format("Invalid Data Object Value: {0} in form: {1}",
                                                          dataObjectName, f.Text));
                                    int idx = 0;
                                    foreach (string fieldName in _fieldNames)
                                    {
                                        Type objType = obj.GetType();
                                        PropertyInfo piField = objType.GetProperty(fieldName);
                                        if (piField == null && !"Type".Equals(fieldName) &&
                                            !"ToString()".Equals(fieldName))
                                            throw new Exception("Invalid Field Name: " + fieldName);
                                        object fieldValue = "ToString()".Equals(fieldName)
                                                                ? obj.ToString()
                                                                : (piField == null && "Type".Equals(fieldName)
                                                                       ? obj.GetType().Name
                                                                       : piField != null
                                                                             ? piField.GetValue(obj, null)
                                                                             : null);
                                        string value = GetFieldValue(fieldValue);
                                        if (lvi != null)
                                        {
                                            ListViewItem.ListViewSubItem subItem = lvi.SubItems[idx++];
                                            if (subItem != null)
                                                subItem.Text = value;
                                        }
                                    }
                                    if (lvi != null) lvi.Tag = obj;
                                    //ValidateToSchema(obj);
                                    OnCompletedEdit(obj);
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(@"Error: " + err.Message, @"E R R O R");
                                LogManager.Error(err);
                            }
                        };

                        form.Closed += delegate(object sndr, EventArgs ee)
                        {
                            _openForms.Remove((ListViewItem)form.Tag);
                            UnRegisterForm((Form) sndr);
                            if (ee is FormClosedEventArgs)
                            {
                                var f = (Form) sndr;
                                pi = f.GetType().GetProperty(dataObjectName);
                            }
                        };
                        form.Show();
                    }
                }
                HourGlass.Stop();
            }
        }

        private void lvList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvList.Sort();
            lvList.SetSortIcon(lvwColumnSorter.SortColumn, lvwColumnSorter.Order);
        }

        public virtual void ApplyFilter(string filterString)
        {
            _filter = filterString;
        }

        public void ClearFilter()
        {
            _filter = null;
        }

        protected bool TestFilter(string value)
        {
            bool results = true;
            if (!string.IsNullOrWhiteSpace(_filter))
            {
                /*
                if (_filter.StartsWith("*") && _filter.EndsWith("*"))
                    results = value.Contains(_filter.Replace("*", ""));
                else if (_filter.StartsWith("*"))
                    results = value.EndsWith(_filter.Replace("*", ""));
                else if (_filter.EndsWith("*"))
                    results = value.StartsWith(_filter.Replace("*", ""));
                else
                    results = value.StartsWith(_filter);
                 */
                results = value.ToUpper().Contains(_filter.ToUpper().Replace("*", ""));
            }
            return results;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (HasSelected)
            {
                ListViewItem lvi = lvList.SelectedItems[0];
                int idx = lvi.Index;
                if (idx > 0)
                {
                    lvList.Items.RemoveAt(idx);
                    lvList.Items.Insert(idx - 1, lvi);
                }
                OnSequenceChanged();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (HasSelected)
            {
                ListViewItem lvi = lvList.SelectedItems[0];
                int idx = lvi.Index;
                if (idx < (lvList.Items.Count - 1))
                {
                    lvList.Items.RemoveAt(idx);
                    lvList.Items.Insert(idx + 1, lvi);
                }
                OnSequenceChanged();
            }
        }

        #region ButtonEvents

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            if (OnAdd != null)
                OnAdd();
            else if (_dataObjectFormType != null && _dataObjectName != null)
            {
                AddObject(_dataObjectFormType, _dataObjectName);
            }
        }


        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {
            if (OnEdit != null)
                OnEdit();
            else if (_dataObjectFormType != null && _dataObjectName != null)
            {
                EditSelectedObject(_dataObjectFormType, _dataObjectName);
            }
        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
                OnDelete();
            else if (_dataObjectFormType != null && _dataObjectName != null)
            {
                DeleteSelectedObject(_dataObjectName);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (OnFind != null)
                OnFind();
        }

        #endregion

        #region Public Properties

        public String ListName
        {
            get { return _listName; }
            set
            {
                _listName = value;
                SetAddButtonTooltip(String.Format("Press to add a new {0}", value));
                SetEditButtonTooltip(String.Format("Press to edit the selected {0}", value));
                SetDeleteButtonTooltip(String.Format("Press to delete the selected {0}", value));
            }
        }

        /** The first selected object in the list view. */

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedObject
        {
            get { return HasSelected ? lvList.SelectedItems[0].Tag : null; }
            set { if (HasSelected) lvList.SelectedItems[0].Tag = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedListViewItem
        {
            get { return HasSelected ? lvList.SelectedItems[0] : null; }
        }

        public ListView.ColumnHeaderCollection Columns
        {
            get { return lvList.Columns; }
        }

        public ListView.ListViewItemCollection Items
        {
            get { return lvList.Items; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get { return lvList.SelectedItems; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasSelected
        {
            get { return lvList.SelectedItems.Count > 0; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type DataObjectFormType
        {
            get { return _dataObjectFormType; }
            set { _dataObjectFormType = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataObjectName
        {
            get { return _dataObjectName; }
            set
            {
                _dataObjectName = value; 
                TooltipTextAddButton = string.Format("Click to add a new {0}", DataObjectName);
                TooltipTextEditButton = string.Format("Click to edit the selected {0}", DataObjectName);
                TooltipTextDeleteButton = string.Format("Click to delete the selected {0}", DataObjectName);
            }
        }

        public bool ShowFind
        {
            get { return btnFind.Visible; }
            set { btnFind.Visible = value; }
        }

        public string FormTitle
        {
            get { return _formTitle; }
            set { _formTitle = value; }
        }

        public bool AllowRowResequencing
        {
            get { return _allowRowResequencing; }
            set
            {
                _allowRowResequencing = value;
                btnMoveUp.Visible = _allowRowResequencing;
                btnMoveDown.Visible = _allowRowResequencing;
            }
        }

        public List<T> GetData<T>() 
        {
            return Harvest<T>();
        }

        public void SetData<T>( ICollection<T> data)
        {
            Populate(data);
        }

        #endregion
    }

    internal class MyRenderer : ToolStripRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
    }
}

public class ListViewColumnSorter : IComparer
{
    /// <summary>
    ///     Case insensitive comparer object
    /// </summary>
    private readonly CaseInsensitiveComparer ObjectCompare;

    /// <summary>
    ///     Specifies the column to be sorted
    /// </summary>
    private int ColumnToSort;

    /// <summary>
    ///     Specifies the order in which to sort (i.e. 'Ascending').
    /// </summary>
    private SortOrder OrderOfSort;

    /// <summary>
    ///     Class constructor.  Initializes various elements
    /// </summary>
    public ListViewColumnSorter()
    {
        // Initialize the column to '0'
        ColumnToSort = 0;

        // Initialize the sort order to 'none'
        OrderOfSort = SortOrder.None;

        // Initialize the CaseInsensitiveComparer object
        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// <summary>
    ///     Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    /// </summary>
    public int SortColumn
    {
        set { ColumnToSort = value; }
        get { return ColumnToSort; }
    }

    /// <summary>
    ///     Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    /// </summary>
    public SortOrder Order
    {
        set { OrderOfSort = value; }
        get { return OrderOfSort; }
    }


    /// <summary>
    ///     This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive
    ///     comparison.
    /// </summary>
    /// <param name="x">First object to be compared</param>
    /// <param name="y">Second object to be compared</param>
    /// <returns>
    ///     The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater
    ///     than 'y'
    /// </returns>
    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listviewX, listviewY;

        // Cast the objects to be compared to ListViewItem objects
        listviewX = (ListViewItem) x;
        listviewY = (ListViewItem) y;

        // Compare the two items
        compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text,
                                              listviewY.SubItems[ColumnToSort].Text);

        // Calculate correct return value based on object comparison
        if (OrderOfSort == SortOrder.Ascending)
        {
            // Ascending sort is selected, return normal result of compare operation
            return compareResult;
        }
        if (OrderOfSort == SortOrder.Descending)
        {
            // Descending sort is selected, return negative result of compare operation
            return (-compareResult);
        }
        // Return '0' to indicate they are equal
        return 0;
    }
}


internal static class ListViewExtensions
{
    private const Int32 HDI_WIDTH = 0x0001;
    private const Int32 HDI_HEIGHT = HDI_WIDTH;
    private const Int32 HDI_TEXT = 0x0002;
    private const Int32 HDI_FORMAT = 0x0004;
    private const Int32 HDI_LPARAM = 0x0008;
    private const Int32 HDI_BITMAP = 0x0010;
    private const Int32 HDI_IMAGE = 0x0020;
    private const Int32 HDI_DI_SETITEM = 0x0040;
    private const Int32 HDI_ORDER = 0x0080;
    private const Int32 HDI_FILTER = 0x0100;

    private const Int32 HDF_LEFT = 0x0000;
    private const Int32 HDF_RIGHT = 0x0001;
    private const Int32 HDF_CENTER = 0x0002;
    private const Int32 HDF_JUSTIFYMASK = 0x0003;
    private const Int32 HDF_RTLREADING = 0x0004;
    private const Int32 HDF_OWNERDRAW = 0x8000;
    private const Int32 HDF_STRING = 0x4000;
    private const Int32 HDF_BITMAP = 0x2000;
    private const Int32 HDF_BITMAP_ON_RIGHT = 0x1000;
    private const Int32 HDF_IMAGE = 0x0800;
    private const Int32 HDF_SORTUP = 0x0400;
    private const Int32 HDF_SORTDOWN = 0x0200;

    private const Int32 LVM_FIRST = 0x1000; // List messages
    private const Int32 LVM_GETHEADER = LVM_FIRST + 31;
    private const Int32 HDM_FIRST = 0x1200; // Header messages
    private const Int32 HDM_SETIMAGELIST = HDM_FIRST + 8;
    private const Int32 HDM_GETIMAGELIST = HDM_FIRST + 9;
    private const Int32 HDM_GETITEM = HDM_FIRST + 11;
    private const Int32 HDM_SETITEM = HDM_FIRST + 12;

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    private static extern IntPtr SendMessageLVCOLUMN(IntPtr hWnd, Int32 Msg, IntPtr wParam, ref LVCOLUMN lPLVCOLUMN);


    //This method used to set arrow icon
    public static void SetSortIcon(this ListView listView, int columnIndex, SortOrder order)
    {
        IntPtr columnHeader = SendMessage(listView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

        for (int columnNumber = 0; columnNumber <= listView.Columns.Count - 1; columnNumber++)
        {
            var columnPtr = new IntPtr(columnNumber);
            var lvColumn = new LVCOLUMN();
            lvColumn.mask = HDI_FORMAT;

            SendMessageLVCOLUMN(columnHeader, HDM_GETITEM, columnPtr, ref lvColumn);

            if (!(order == SortOrder.None) && columnNumber == columnIndex)
            {
                switch (order)
                {
                    case SortOrder.Ascending:
                        lvColumn.fmt &= ~HDF_SORTDOWN;
                        lvColumn.fmt |= HDF_SORTUP;
                        break;
                    case SortOrder.Descending:
                        lvColumn.fmt &= ~HDF_SORTUP;
                        lvColumn.fmt |= HDF_SORTDOWN;
                        break;
                }
                lvColumn.fmt |= (HDF_LEFT | HDF_BITMAP_ON_RIGHT);
            }
            else
            {
                lvColumn.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP & ~HDF_BITMAP_ON_RIGHT;
            }

            SendMessageLVCOLUMN(columnHeader, HDM_SETITEM, columnPtr, ref lvColumn);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LVCOLUMN
    {
        public Int32 mask;
        public Int32 cx;
        [MarshalAs(UnmanagedType.LPTStr)] public string pszText;
        public IntPtr hbm;
        public Int32 cchTextMax;
        public Int32 fmt;
        public Int32 iSubItem;
        public Int32 iImage;
        public Int32 iOrder;
    }
}