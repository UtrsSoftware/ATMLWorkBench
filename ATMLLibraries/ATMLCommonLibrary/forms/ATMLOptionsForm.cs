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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.Properties;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLOptionsForm : ATMLForm
    {
        public ATMLOptionsForm()
        {
            InitializeComponent();

            Stream stream = GetType().Assembly.GetManifestResourceStream(Resources.Options);
            if( stream == null )
                throw new Exception( "Failed to load the Property Options resources.");

            var reader = new XmlTextReader(stream);
            var document = new XmlDocument();
            document.Load(reader);
            XmlElement root = document.DocumentElement;
            Dictionary<String, PropertyOption> options = new Dictionary<string, PropertyOption>();

            ProcessOption(root, null, options );
        }

        public static void LoadContext()
        {
            //--------------------------------------------//
            //--- Make sure that a Context File Exists ---//
            //--------------------------------------------//
            //if (!File.Exists(ATMLContext.CONTEXT_FILE_NAME))
            {
                var form = new ATMLOptionsForm();
                form.SaveContext();
                form.Close();
            }
        }

        private void ProcessOption(XmlElement parentElement, TreeNode parentTreeNode, Dictionary<String, PropertyOption> options )
        {
            foreach (XmlNode child in parentElement.ChildNodes)
            {
                var element = child as XmlElement;
                if (element != null)
                {
                    if ("option".Equals(child.Name))
                    {
                        string name = element.GetAttribute("name");
                        var node = new TreeNode(name);
                        node.SelectedImageIndex =
                            node.ImageIndex = int.Parse(element.GetAttribute("imageId"));
                        if (parentTreeNode == null)
                            optionTree.Nodes.Add(node);
                        else
                            parentTreeNode.Nodes.Add(node);
                        PropertyOption option = null;
                        if (options.ContainsKey(name))
                            option = options[name];
                        else
                        {
                            option = new PropertyOption(name);
                            options.Add(name, option);
                        }
                        try
                        {
                            ProcessOption(element, node, option.Options);
                        }
                        catch (Exception)
                        {
                            int i = 0;
                        }
                        
                    }
                    else if ("controls".Equals(child.Name))
                    {
                        var properties = new Dictionary<string, PropertyOption>();
                        foreach (XmlNode control in element.ChildNodes)
                        {
                            var xmlElement = control as XmlElement;
                            if (xmlElement != null)
                            {
                                string _label = xmlElement.GetAttribute("label");
                                string _name = xmlElement.GetAttribute("name");
                                string _default = xmlElement.GetAttribute("default");
                                string _class = xmlElement.GetAttribute("class");
                                string _description = xmlElement.GetAttribute("description");
                                string _category = xmlElement.GetAttribute("category");
                                object _value = ATMLContext.GetProperty(_name);

                                if (!string.IsNullOrEmpty(_class))
                                {
                                    if( _value == null )
                                        _value = "String".Equals(_class)
                                                ? _default
                                                : "double".Equals(_class)
                                                ? double.Parse(_default)
                                                : "int".Equals(_class)
                                                ? int.Parse(_default)
                                                : "Int32".Equals(_class)
                                                ? Int32.Parse(_default)
                                                : "Boolean".Equals(_class) 
                                                ? "1"==_default
                                                : "Color".Equals(_class) 
                                                ? ColorTranslator.FromHtml(_default)
                                                : Activator.CreateInstance(Type.GetType(_class));
                                    PropertyOption option = null;
                                    if (options.ContainsKey(_name))
                                        option = options[_name];
                                    else
                                    {
                                        option = new PropertyOption(_name);
                                        option.Description = _description;
                                        option.Category = _category;
                                        option.Label = _label;
                                        options.Add(_name, option);
                                    }
                                    option.Value = _value;
                                    properties.Add(_name, option);
                                }
                            }
                        }
                        if (parentTreeNode != null) parentTreeNode.Tag = properties;
                    }
                }
            }
        }

        private void optionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if( e != null && e.Node != null && e.Node.Tag != null )
                propertyGrid.SelectedObject = new DictionaryPropertyGridAdapter((IDictionary<string, PropertyOption>)e.Node.Tag);
        }

        private void propertyGrid_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
               
        }

        private void ATMLOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                SaveContext();
            }
        }

        private void SaveContext()
        {
            try
            {
                processTreeNodes(optionTree.Nodes);
                ATMLContext.Save();
            }
            catch (Exception e)
            {
                LogManager.Error(e);
            }
        }

        private static void SetPropertyValue(TreeNode node)
        {
            Dictionary<string, PropertyOption> options = node.Tag as Dictionary<string, PropertyOption>;
            if (options != null)
            {
                foreach (PropertyOption option in options.Values)
                {
                    ATMLContext.SetProperty(option.Name, option.Value);
                }
            }
        }

        private void processTreeNodes(TreeNodeCollection parentNodeCollection)
        {
            foreach (TreeNode node in parentNodeCollection)
            {
                processTreeNodes(node.Nodes);
                SetPropertyValue(node);
            }
        }
    }

    internal class DictionaryPropertyGridAdapter : ICustomTypeDescriptor
    {
        private readonly IDictionary<string,PropertyOption> _dictionary;

        public DictionaryPropertyGridAdapter(IDictionary<string, PropertyOption> d)
        {
            _dictionary = d;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return ((ICustomTypeDescriptor) this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = new ArrayList();
            if (_dictionary != null)
            {
                foreach (PropertyOption e in _dictionary.Values)
                {
                    properties.Add(new DictionaryPropertyDescriptor(_dictionary, e.Name));
                }
            }

            var props =
                (PropertyDescriptor[]) properties.ToArray(typeof (PropertyDescriptor));

            return new PropertyDescriptorCollection(props);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _dictionary;
        }
    }

    internal class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        private readonly IDictionary<string,PropertyOption> _dictionary;
        private readonly string _key;

        internal DictionaryPropertyDescriptor(IDictionary<string, PropertyOption> d, string key)
            : base(key, null)
        {
            _dictionary = d;
            _key = key;
        }

        public override Type PropertyType
        {
            get
            {
                PropertyOption option = _dictionary[_key];
                return option.Value.GetType();
            }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type ComponentType
        {
            get { return null; }
        }

        public override void SetValue(object component, object value)
        {
            _dictionary[_key].Value = value;
        }

        public override object GetValue(object component)
        {
            return _dictionary[_key].Value;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override string Description
        {
            get { return _dictionary[_key].Description; }
        }

        public override string Category
        {
            get { return _dictionary[_key].Category; }
        }

        public override string DisplayName
        {
            get { return _dictionary[_key].Label; }
        }
    }

}