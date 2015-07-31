/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace WindowsFormsApplication10
{
    partial class SecurityClassificationControl
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
           
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbSecurityClass = new System.Windows.Forms.ComboBox();
            this.chkClassified = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "SecurityClassification.Classified";
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Classified";
            // 
            // cmbSecurityClass
            // 
            this.cmbSecurityClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSecurityClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecurityClass.Enabled = false;
            this.cmbSecurityClass.FormattingEnabled = true;
            this.cmbSecurityClass.Items.AddRange(new object[] {
            "UNCLASSIFIED",
            "CLASSIFIED",
            "SECRET",
            "CONFIDENTIAL",
            "TOP SECRET"});
            this.cmbSecurityClass.Location = new System.Drawing.Point(80, 0);
            this.cmbSecurityClass.Name = "cmbSecurityClass";
            this.cmbSecurityClass.Size = new System.Drawing.Size(299, 21);
            this.cmbSecurityClass.TabIndex = 1;
            this.cmbSecurityClass.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // chkClassified
            // 
            this.chkClassified.AutoSize = true;
            this.chkClassified.Location = new System.Drawing.Point(62, 4);
            this.chkClassified.Name = "chkClassified";
            this.chkClassified.Size = new System.Drawing.Size(15, 14);
            this.chkClassified.TabIndex = 0;
            this.chkClassified.UseVisualStyleBackColor = true;
            this.chkClassified.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // SecurityClassificationControl
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSecurityClass);
            this.Controls.Add(this.chkClassified);
            this.Name = "SecurityClassificationControl";
            this.Size = new System.Drawing.Size(379, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkClassified;
        private System.Windows.Forms.ComboBox cmbSecurityClass;
        private ATMLCommonLibrary.controls.HelpLabel label2;
    }
}

