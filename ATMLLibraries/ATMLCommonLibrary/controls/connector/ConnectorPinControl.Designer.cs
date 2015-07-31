/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.common
{
    partial class ConnectorPinControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtId = new System.Windows.Forms.TextBox();
            this.edtName = new System.Windows.Forms.TextBox();
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtBaseIndex = new System.Windows.Forms.TextBox();
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtCount = new System.Windows.Forms.TextBox();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIncrementBy = new System.Windows.Forms.TextBox();
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtReplacementCharacter = new System.Windows.Forms.TextBox();
            this.helpLabel6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ConnectorPin.ID";
            this.helpLabel1.Location = new System.Drawing.Point(4, 6);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(18, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "ID";
            // 
            // edtId
            // 
            this.edtId.Location = new System.Drawing.Point(74, 3);
            this.edtId.Name = "edtId";
            this.edtId.Size = new System.Drawing.Size(100, 20);
            this.edtId.TabIndex = 1;
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(74, 29);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(207, 20);
            this.edtName.TabIndex = 3;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "ConnectorPin.Name";
            this.helpLabel2.Location = new System.Drawing.Point(4, 32);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(35, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Name";
            // 
            // edtBaseIndex
            // 
            this.edtBaseIndex.Location = new System.Drawing.Point(74, 55);
            this.edtBaseIndex.Name = "edtBaseIndex";
            this.edtBaseIndex.Size = new System.Drawing.Size(37, 20);
            this.edtBaseIndex.TabIndex = 5;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "ConnectorPin.BaseIndex";
            this.helpLabel3.Location = new System.Drawing.Point(4, 58);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(60, 13);
            this.helpLabel3.TabIndex = 4;
            this.helpLabel3.Text = "Base Index";
            // 
            // edtCount
            // 
            this.edtCount.Location = new System.Drawing.Point(401, 3);
            this.edtCount.Name = "edtCount";
            this.edtCount.Size = new System.Drawing.Size(62, 20);
            this.edtCount.TabIndex = 7;
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "ConnectorPin.Count";
            this.helpLabel4.Location = new System.Drawing.Point(301, 6);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(35, 13);
            this.helpLabel4.TabIndex = 6;
            this.helpLabel4.Text = "Count";
            // 
            // edtIncrementBy
            // 
            this.edtIncrementBy.Location = new System.Drawing.Point(401, 29);
            this.edtIncrementBy.Name = "edtIncrementBy";
            this.edtIncrementBy.Size = new System.Drawing.Size(37, 20);
            this.edtIncrementBy.TabIndex = 9;
            // 
            // helpLabel5
            // 
            this.helpLabel5.AutoSize = true;
            this.helpLabel5.HelpMessageKey = "ConnectorPin.IncrementBy";
            this.helpLabel5.Location = new System.Drawing.Point(301, 32);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(69, 13);
            this.helpLabel5.TabIndex = 8;
            this.helpLabel5.Text = "Increment By";
            // 
            // edtReplacementCharacter
            // 
            this.edtReplacementCharacter.Location = new System.Drawing.Point(401, 55);
            this.edtReplacementCharacter.Name = "edtReplacementCharacter";
            this.edtReplacementCharacter.Size = new System.Drawing.Size(37, 20);
            this.edtReplacementCharacter.TabIndex = 11;
            // 
            // helpLabel6
            // 
            this.helpLabel6.AutoSize = true;
            this.helpLabel6.HelpMessageKey = "ConnectorPin.ReplacementChar";
            this.helpLabel6.Location = new System.Drawing.Point(301, 58);
            this.helpLabel6.Name = "helpLabel6";
            this.helpLabel6.RequiredField = false;
            this.helpLabel6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel6.Size = new System.Drawing.Size(95, 13);
            this.helpLabel6.TabIndex = 10;
            this.helpLabel6.Text = "Replacement Char";
            // 
            // ConnectorPinControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtReplacementCharacter);
            this.Controls.Add(this.helpLabel6);
            this.Controls.Add(this.edtIncrementBy);
            this.Controls.Add(this.helpLabel5);
            this.Controls.Add(this.edtCount);
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.edtBaseIndex);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtId);
            this.Controls.Add(this.helpLabel1);
            this.Name = "ConnectorPinControl";
            this.Size = new System.Drawing.Size(490, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private System.Windows.Forms.TextBox edtId;
        private System.Windows.Forms.TextBox edtName;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.TextBox edtBaseIndex;
        private HelpLabel helpLabel3;
        private System.Windows.Forms.TextBox edtCount;
        private HelpLabel helpLabel4;
        private System.Windows.Forms.TextBox edtIncrementBy;
        private HelpLabel helpLabel5;
        private System.Windows.Forms.TextBox edtReplacementCharacter;
        private HelpLabel helpLabel6;
    }
}
