/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.controls.driver
{
    partial class IVIDriverControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClass = new System.Windows.Forms.TabPage();
            this.lvClassNames = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabDocument = new System.Windows.Forms.TabPage();
            this.documentControl = new DocumentControl();
            this.tabControl1.SuspendLayout();
            this.tabClass.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // driverModuleControl
            // 
            this.driverModuleControl.Size = new System.Drawing.Size(457, 87);
            // 
            // driverUnifiedControl
            // 
            this.driverUnifiedControl.Size = new System.Drawing.Size(457, 183);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabClass);
            this.tabControl1.Controls.Add(this.tabDocument);
            this.tabControl1.Location = new System.Drawing.Point(13, 224);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 138);
            this.tabControl1.TabIndex = 9;
            // 
            // tabClass
            // 
            this.tabClass.Controls.Add(this.lvClassNames);
            this.tabClass.Location = new System.Drawing.Point(4, 22);
            this.tabClass.Name = "tabClass";
            this.tabClass.Padding = new System.Windows.Forms.Padding(3);
            this.tabClass.Size = new System.Drawing.Size(447, 112);
            this.tabClass.TabIndex = 0;
            this.tabClass.Text = "Class";
            this.tabClass.UseVisualStyleBackColor = true;
            // 
            // lvClassNames
            // 
            //this.lvClassNames.AllowRowResequencing = false;
            this.lvClassNames.BackColor = System.Drawing.Color.AliceBlue;
            this.lvClassNames.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.lvClassNames.FormTitle = null;
            this.lvClassNames.HelpKeyWord = null;
            //this.lvClassNames.ListName = null;
            this.lvClassNames.Location = new System.Drawing.Point(3, 3);
            this.lvClassNames.Margin = new System.Windows.Forms.Padding(0);
            this.lvClassNames.Name = "lvClassNames";
            this.lvClassNames.SchemaTypeName = null;
            //this.lvClassNames.ShowFind = false;
            this.lvClassNames.Size = new System.Drawing.Size(441, 106);
            this.lvClassNames.TabIndex = 0;
            this.lvClassNames.TargetNamespace = null;
            //this.lvClassNames.TooltipTextAddButton = "Press to add a new ";
            //this.lvClassNames.TooltipTextDeleteButton = "Press to delete the selected ";
            //this.lvClassNames.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabDocument
            // 
            this.tabDocument.Controls.Add(this.documentControl);
            this.tabDocument.Location = new System.Drawing.Point(4, 22);
            this.tabDocument.Name = "tabDocument";
            this.tabDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocument.Size = new System.Drawing.Size(588, 203);
            this.tabDocument.TabIndex = 1;
            this.tabDocument.Text = "Document";
            this.tabDocument.UseVisualStyleBackColor = true;
            // 
            // documentControl
            // 
            this.documentControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.documentControl.BackColor = System.Drawing.Color.Transparent;
            this.documentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentControl.HelpKeyWord = null;
            this.documentControl.Location = new System.Drawing.Point(3, 3);
            this.documentControl.Name = "documentControl";
            this.documentControl.SchemaTypeName = null;
            this.documentControl.Size = new System.Drawing.Size(582, 197);
            this.documentControl.TabIndex = 0;
            this.documentControl.TargetNamespace = null;
            this.documentControl.ValidationEnabled = true;
            // 
            // IVIDriverControl
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "IVIDriverControl";
            this.Size = new System.Drawing.Size(490, 380);
            this.Resize += new System.EventHandler(this.IVIDriverControl_Resize);
            this.Controls.SetChildIndex(this.driverUnifiedControl, 0);
            this.Controls.SetChildIndex(this.driverModuleControl, 0);
            this.Controls.SetChildIndex(this.cmbDriverType, 0);
            this.Controls.SetChildIndex(this.lblDriverType, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabClass.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabClass;
        protected System.Windows.Forms.TabPage tabDocument;
        protected awb.AWBTextCollectionList lvClassNames;
        protected DocumentControl documentControl;
    }
}
