/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class SingleLimitControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbComparitor = new System.Windows.Forms.ComboBox();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // collectionControl
            // 
            this.collectionControl.Size = new System.Drawing.Size(532, 468);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(536, 472);
            // 
            // indexArrayControl
            // 
            this.indexArrayControl.Size = new System.Drawing.Size(532, 468);
            // 
            // cmbComparitor
            // 
            this.cmbComparitor.FormattingEnabled = true;
            this.cmbComparitor.Location = new System.Drawing.Point(288, 3);
            this.cmbComparitor.Name = "cmbComparitor";
            this.cmbComparitor.Size = new System.Drawing.Size(149, 21);
            this.cmbComparitor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "SingleLimitControl.Comparitor";
            this.label1.Location = new System.Drawing.Point(223, 6);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comparitor";
            // 
            // SingleLimitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbComparitor);
            this.MinimumSize = new System.Drawing.Size(541, 517);
            this.Name = "SingleLimitControl";
            this.Size = new System.Drawing.Size(559, 517);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.cmbValueType, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cmbComparitor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbComparitor;
        private ATMLCommonLibrary.controls.HelpLabel label1;
    }
}
