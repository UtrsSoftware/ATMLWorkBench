/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;
using WeifenLuo.WinFormsUI.Docking;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLForm : DockContent, IATMLDockableWindow
    {
        // ID for the Validate Schema system menu
        private const int DESIGN_TIME_DPI = 96;
        private readonly float _currentDpi;
        private ATMLDocumentBaseForm _atmlContentform;
        private bool _closeOnSave = true;
        protected String originalSerializedATMLObject = null;

        public ATMLForm( Control parent ) : this()
        {
            Parent = parent;
        }

        public ATMLForm()
        {
            InitializeComponent();

            FormManager.AddActiveForm( this );
            //TODO: Need to rethink this for nested dialogs (Specification Groups for example)
            /*
            if (!FormManager.AddActiveForm(this))
            {
                MessageBox.Show(@"An instance of this form type is already open.");
                DialogResult = DialogResult.Abort;
                Close();
            }
            */
            BackColor = ATMLContext.COLOR_FORM;
            panel1.BackColor = ATMLContext.COLOR_PANEL;
            StartPosition = FormStartPosition.CenterScreen;
            btnCancel.CausesValidation = false;
            btnOk.CausesValidation = true;
            Closing += ATMLForm_Closing;
            Activated += ATMLForm_Activated;
            HandleDestroyed += ATMLForm_HandleDestroyed;
            AddValidatingHandlers( Controls );
            Resize += ( sender, args ) => SyncFormLocations();
            Move += ( sender, args ) => SyncFormLocations();

            Graphics g = CreateGraphics();
            try
            {
                _currentDpi = g.DpiX;
            }
            finally
            {
                g.Dispose();
            }
        }

        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Category( "Behaviour" ), Description( "Enter the XML Schema Type Name." )]
        public string SchemaTypeName { get; set; }

        [Category( "Behaviour" ), Description( "Enter the target namespace for the Schema Type." )]
        public string TargetNamespace { get; set; }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Control LastActiveControl { get; set; }

        //----------------------------------------------------------------------//
        //--- Used to simulate a Modal form when it has been opened modeless ---//
        //----------------------------------------------------------------------//
        public bool CloseOnSave
        {
            get { return _closeOnSave; }
            set { _closeOnSave = value; }
        }

        public void CloseProject()
        {
        }

        public event EventHandler Saved;
        public event EventHandler Canceled;
        public event EventHandler AtmlViewShown;

        protected virtual void OnCanceled()
        {
            EventHandler handler = Canceled;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnAtmlViewShown()
        {
            EventHandler handler = AtmlViewShown;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        public event EventHandler AtmlViewHidden;

        protected virtual void OnAtmlViewHidden()
        {
            EventHandler handler = AtmlViewHidden;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnSaved()
        {
            //DialogResult = DialogResult.None;
            UpdateAll();
            EventHandler handler = Saved;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if (keyData == ( Keys.Control | Keys.I ))
            {
                DisplayFormInfo();
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }

        [Conditional( "DEBUG" )]
        private void DisplayFormInfo()
        {
            var sb = new StringBuilder();
            Type type = GetType();
            string fullName = type.FullName;
            sb.Append( fullName ).Append( "\r\n" );
            foreach (Control control in Controls)
            {
                GetControlMetadata( sb, control, 1 );
            }
            var form = new ATMLTextForm( sb.ToString() );
            form.Show();
        }

        private static void GetControlMetadata( StringBuilder sb, Control control, int level )
        {
            for (int i = 0; i < level; i++)
                sb.Append( "\t" );
            sb.Append( control.GetType().FullName ).Append( " (" ).Append( control.Name ).Append( ")\r\n" );
            foreach (Control c in control.Controls)
            {
                GetControlMetadata( sb, c, level + 1 );
            }
        }

        // P/Invoke declarations
        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        private static extern IntPtr GetSystemMenu( IntPtr hWnd, bool bRevert );

        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        private static extern bool AppendMenu( IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem );

        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        private static extern bool InsertMenu( IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem );

        public event EventHandler ValidateSchema;
        public event EventHandler UndoChanges;

        protected virtual void OnUndoChanges()
        {
            EventHandler handler = UndoChanges;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnValidateSchema()
        {
            EventHandler handler = ValidateSchema;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        private void AddValidatingHandlers( Control.ControlCollection controls )
        {
            foreach (Control control in controls)
            {
                AddValidatingHandlers( control.Controls );
                control.Validating += control_Validating;
            }
        }

        private void control_Validating( object sender, CancelEventArgs e )
        {
            var c = sender as Control;
            if (c != null)
            {
                if (e.Cancel)
                {
                    int i = 0; //Breakpoint Test Point
                }
            }
        }

        private void ATMLForm_HandleDestroyed( object sender, EventArgs e )
        {
            FormManager.RemoveActiveForm( this );
        }

        private void ATMLForm_Activated( object sender, EventArgs e )
        {
            if (LastActiveControl != null)
                FormManager.LastActiveControl = LastActiveControl;
        }

        private void ATMLForm_Closing( object sender, CancelEventArgs e )
        {
            if (e.Cancel)
            {
                e.Cancel = false;
                FormManager.RemoveActiveForm( this );
            }
            else
            {
                if (DialogResult.Cancel == DialogResult || DialogResult.Abort == DialogResult)
                {
                    OnCanceled();
                }
                else if (DialogResult.OK == DialogResult)
                {
                    try
                    {
                        bool thisValidated = Validate();
                        bool childrenValidated = ValidateChildren( ValidationConstraints.Enabled );
                        if (!thisValidated || !childrenValidated)
                        {
                            childrenValidated = ValidateChildren( ValidationConstraints.Enabled );
                            //Hack: need to check children again
                            if (!thisValidated || !childrenValidated)
                            {
                                e.Cancel = true;
                                UpdateAll();
                                ICollection<string> errorsList = ErrorManager.GatherErrorMessages( this );
                                if (errorsList.Count > 0)
                                    ATMLErrorListBox.Show( errorsList );

                                LogManager.Debug( "Form \"{0}\" Validated: {1}, Children Validated: {2}",
                                                  Text,
                                                  thisValidated,
                                                  childrenValidated );
                            }
                            else
                            {
                                OnSaved();
                            }
                        }
                        else
                        {
                            OnSaved();
                        }
                    }
                    catch (Exception err)
                    {
                        LogManager.Error( err, "An error occurred saving the form." );
                        e.Cancel = true;
                    }

                    e.Cancel = e.Cancel |= !_closeOnSave;
                }

                if (!e.Cancel)
                {
                    if (OwnedForms.Length > 0)
                    {
                        foreach (Form ownedForm in OwnedForms)
                        {
                            LogManager.Warn( string.Format( "Child Form Forced Closed: {0}", ownedForm.GetType().Name ) );
                            try
                            {
                                ownedForm.Close();
                            }
                            catch (Exception err)
                            {
                                LogManager.Debug( err );
                            }
                        }
                    }
                    else
                    {
                        FormManager.RemoveActiveForm( this );
                    }
                }

                //------------------------------------------------------------------------//
                //--- If the user presses the command box X on the form when the form  ---//
                //--- has been opened modeless and the user has already saved the data ---//
                //--- with the OK button we must set the DialogResult to something     ---//
                //--- other than OK so the form will close. This is because the X does ---//
                //--- not set the DialogResult to a Cancel State or change it at all   ---//
                //--- for that matter as far as I know.                                ---//
                //--- TODO: Need to look into setting cancel state on command X        ---//
                //------------------------------------------------------------------------//
                if (!Modal && !_closeOnSave)
                {
                    DialogResult = DialogResult.None;
                }

            }

            //---------------------------------------------//
            //--- Close the ATML View Form if it exists ---//
            //---------------------------------------------//
            if (!e.Cancel && _atmlContentform != null)
            {
                _atmlContentform.HideOnClose = false;
                _atmlContentform.Close();
            }

            if (e.Cancel)
                UpdateAll();
        }

        private void ATMLForm_Load( object sender, EventArgs e )
        {
            //SetAutoScale(AutoScaleMode.Inherit, new SizeF(6F, 13F));
        }

        protected virtual void btnOk_Click( object sender, EventArgs e )
        {
            if (!Modal)
            {
                Close();
            }
        }

        protected virtual void btnCancel_Click( object sender, EventArgs e )
        {
            if (!Modal)
            {
                Close();
            }
        }

        protected void StoreOriginalValue( object item )
        {
            MethodInfo mi = item.GetType().GetMethod( "Serialize" );
            if (mi != null)
            {
                originalSerializedATMLObject = (string) mi.Invoke( item, null );
            }
        }

        public static void ValidateToSchema( object item )
        {
            ATMLControl.ValidateToSchema( item );
        }

        private void ATMLForm_HelpRequested( object sender, HelpEventArgs hlpevent )
        {
            ATMLContext.ShowHelp( this, Text );
        }

        protected void CreateAtmlView()
        {
            _atmlContentform = new ATMLDocumentBaseForm();
            _atmlContentform.IsXmlDocument = true;
            _atmlContentform.HideOnClose = false;
            _atmlContentform.AllowSave = false;
        }

        protected void UpdateAtmlViewContent<T>( T atmlObject )
        {
            if (null != atmlObject && null != _atmlContentform)
            {
                MethodInfo pi1 = atmlObject.GetType().GetMethod( "Serialize" );
                if (pi1 != null)
                    _atmlContentform.Content = (string) pi1.Invoke( atmlObject, null );
            }
        }

        protected void ShowAtmlContent<T>( T atmlObject )
        {
            if (null != atmlObject)
            {
                if (_atmlContentform == null || _atmlContentform.IsDisposed)
                {
                    CreateAtmlView();
                    LoadAtmlView( atmlObject );
                    if (_atmlContentform != null)
                    {
                        _atmlContentform.Show( this );
                        _atmlContentform.FormClosed += delegate { OnAtmlViewHidden(); };
                        OnAtmlViewShown();
                    }
                    SyncFormLocations();
                }
                else if (_atmlContentform.Visible)
                {
                    _atmlContentform.Close();
                    _atmlContentform = null;
                }
            }
        }

        protected void LoadAtmlView<T>( T atmlObject )
        {
            MethodInfo pi1 = atmlObject.GetType().GetMethod( "Serialize" );
            MethodInfo pi2 = atmlObject.GetType().GetMethod( "GetAtmlFileName" );
            if (pi1 == null || pi2 == null)
                LogManager.Error( "Unable to view ATML - Invalid Atml Object." );
            else
            {
                if (_atmlContentform != null)
                {
                    _atmlContentform.Content = (string) pi1.Invoke( atmlObject, null );
                    _atmlContentform.Text = (string) pi2.Invoke( atmlObject, null );
                }
            }
        }

        private void SyncFormLocations()
        {
            if (_atmlContentform != null)
            {
                Point pt = Location;
                pt.X = pt.X - _atmlContentform.Width;
                _atmlContentform.Height = Height;
                _atmlContentform.Location = pt;
            }
        }

        public void InitViewButton( Button btnViewATML )
        {
            AtmlViewHidden += delegate { btnViewATML.Text = @"View ATML"; };
            AtmlViewShown += delegate { btnViewATML.Text = @"Hide ATML"; };
        }

        public void UpdateAll()
        {
            InvalidateAllControls( Controls );
            Update();
        }

        private void InvalidateAllControls( Control.ControlCollection controls )
        {
            foreach (Control control in controls)
            {
                control.Invalidate();
                InvalidateAllControls( control.Controls );
            }
        }

        #region Scaling Methods

        public void SetAutoScale( AutoScaleMode mode, SizeF drawingSize )
        {
            AutoScaleMode = mode;
            AutoScaleDimensions = drawingSize;
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            float scaleFactor = DESIGN_TIME_DPI/_currentDpi;
            ScaleFontForControl( this, scaleFactor );
            SetControlScaleModes( Controls, mode, Font, drawingSize );
        }

        private void SetControlScaleModes( Control.ControlCollection controls, AutoScaleMode mode, Font font,
                                           SizeF drawingSize )
        {
            lblDenoteRequiredField.Text = "DPI:" + _currentDpi;
            foreach (Control control in controls)
            {
                //control.Font = font;
                SetControlScaleModes( control.Controls, mode, font, drawingSize );
                var container = control as ContainerControl;
                if (container != null)
                {
                    container.AutoScaleMode = mode;
                    container.AutoScaleDimensions = drawingSize;
                }
                else
                {
                    control.AutoSize = true;
                }
            }
        }

        public static void ScaleFonts( Control.ControlCollection controls, float multiplier )
        {
            foreach (Control c in controls)
            {
                ScaleFonts( c.Controls, multiplier );
                if (c.Parent == null || !c.Parent.Font.Equals( c.Font ))
                {
                    c.Font = new Font( c.Font.FontFamily, c.Font.Size*multiplier, c.Font.Style );
                }
            }
        }

        protected virtual void ScaleFonts( float scaleFactor )
        {
            //Go through all controls in the control tree and set their Font property
            //Note that this might not work with some RadElements which have the Font property
            //set via theme or a local setting and they need to be handled separately (e.g. TreeNodeElement)
            ScaleFontForControl( this, scaleFactor );
        }

        private static void ScaleFontForControl( Control control, float factor )
        {
            control.Font = new Font( control.Font.FontFamily,
                                     control.Font.Size*factor,
                                     control.Font.Style );

            foreach (Control child in control.Controls)
            {
                ScaleFontForControl( child, factor );
            }
        }

        #endregion
    }
}