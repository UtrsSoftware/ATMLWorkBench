/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.controls
{
    partial class SoftwareInstanceControl
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
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.dteReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.itemDescriptionControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dteReleaseDate);
            this.panel2.Controls.Add(this.helpLabel2);
            this.panel2.Size = new System.Drawing.Size(459, 37);
            this.panel2.Controls.SetChildIndex(this.helpLabel1, 0);
            this.panel2.Controls.SetChildIndex(this.edtSerialNumber, 0);
            this.panel2.Controls.SetChildIndex(this.helpLabel2, 0);
            this.panel2.Controls.SetChildIndex(this.dteReleaseDate, 0);
            // 
            // documentReferenceControl
            // 
            this.documentReferenceControl.Size = new System.Drawing.Size(560, 373);
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.Size = new System.Drawing.Size(459, 336);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(459, 336);
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(237, 12);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(72, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Release Date";
            // 
            // dteReleaseDate
            // 
            this.dteReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteReleaseDate.Location = new System.Drawing.Point(315, 9);
            this.dteReleaseDate.Name = "dteReleaseDate";
            this.dteReleaseDate.ShowCheckBox = true;
            this.dteReleaseDate.ShowUpDown = true;
            this.dteReleaseDate.Size = new System.Drawing.Size(101, 20);
            this.dteReleaseDate.TabIndex = 3;
            // 
            // SoftwareInstanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SoftwareInstanceControl";
            this.Size = new System.Drawing.Size(459, 363);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.itemDescriptionControl.ResumeLayout(false);
            this.itemDescriptionControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteReleaseDate;
        private ATMLCommonLibrary.controls.HelpLabel helpLabel2;


    }
}
