/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class ATMLSelectionCheckListForm
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
            this.components = new System.ComponentModel.Container();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.lblSelectionLabel = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lvCheckList = new System.Windows.Forms.ListView();
            this.lblCheckList = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCheckList);
            this.panel1.Controls.Add(this.lvCheckList);
            this.panel1.Controls.Add(this.lblSelectionLabel);
            this.panel1.Controls.Add(this.cmbSelect);
            this.panel1.Size = new System.Drawing.Size(433, 351);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 369);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 369);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 380);
            // 
            // cmbSelect
            // 
            this.cmbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Location = new System.Drawing.Point(16, 34);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(398, 21);
            this.cmbSelect.TabIndex = 0;
            // 
            // lblSelectionLabel
            // 
            this.lblSelectionLabel.AutoSize = true;
            this.lblSelectionLabel.HelpMessageKey = null;
            this.lblSelectionLabel.Location = new System.Drawing.Point(16, 18);
            this.lblSelectionLabel.Name = "lblSelectionLabel";
            this.lblSelectionLabel.RequiredField = false;
            this.lblSelectionLabel.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectionLabel.Size = new System.Drawing.Size(37, 13);
            this.lblSelectionLabel.TabIndex = 1;
            this.lblSelectionLabel.Text = "Select";
            // 
            // lvCheckList
            // 
            this.lvCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCheckList.Location = new System.Drawing.Point(16, 84);
            this.lvCheckList.Name = "lvCheckList";
            this.lvCheckList.Size = new System.Drawing.Size(398, 253);
            this.lvCheckList.TabIndex = 2;
            this.lvCheckList.UseCompatibleStateImageBehavior = false;
            this.lvCheckList.View = System.Windows.Forms.View.Details;
            // 
            // lblCheckList
            // 
            this.lblCheckList.AutoSize = true;
            this.lblCheckList.HelpMessageKey = null;
            this.lblCheckList.Location = new System.Drawing.Point(16, 68);
            this.lblCheckList.Name = "lblCheckList";
            this.lblCheckList.RequiredField = false;
            this.lblCheckList.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckList.Size = new System.Drawing.Size(38, 13);
            this.lblCheckList.TabIndex = 3;
            this.lblCheckList.Text = "Check";
            // 
            // ATMLSelectionCheckListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 396);
            this.Name = "ATMLSelectionCheckListForm";
            this.Text = "Selection Check List";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelect;
        private controls.HelpLabel lblCheckList;
        private System.Windows.Forms.ListView lvCheckList;
        private controls.HelpLabel lblSelectionLabel;
    }
}