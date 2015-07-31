/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class TestDescriptionTsfLibraryControl
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
            if( disposing && ( components != null ) )
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
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtTSFLibraryId = new System.Windows.Forms.TextBox();
            this.edtTSFLibraryName = new System.Windows.Forms.TextBox();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtTSFLibrarySchemaURL = new System.Windows.Forms.TextBox();
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtTSFLibraryDocumentURL = new System.Windows.Forms.TextBox();
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "TestDescription.Id";
            this.label1.Location = new System.Drawing.Point(49, 17);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // edtTSFLibraryId
            // 
            this.edtTSFLibraryId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTSFLibraryId.Location = new System.Drawing.Point(71, 14);
            this.edtTSFLibraryId.Name = "edtTSFLibraryId";
            this.edtTSFLibraryId.Size = new System.Drawing.Size(319, 20);
            this.edtTSFLibraryId.TabIndex = 1;
            // 
            // edtTSFLibraryName
            // 
            this.edtTSFLibraryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTSFLibraryName.Location = new System.Drawing.Point(71, 39);
            this.edtTSFLibraryName.Name = "edtTSFLibraryName";
            this.edtTSFLibraryName.Size = new System.Drawing.Size(319, 20);
            this.edtTSFLibraryName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "TestDescription.Name";
            this.label2.Location = new System.Drawing.Point(30, 42);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // edtTSFLibrarySchemaURL
            // 
            this.edtTSFLibrarySchemaURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTSFLibrarySchemaURL.Location = new System.Drawing.Point(71, 64);
            this.edtTSFLibrarySchemaURL.Name = "edtTSFLibrarySchemaURL";
            this.edtTSFLibrarySchemaURL.Size = new System.Drawing.Size(319, 20);
            this.edtTSFLibrarySchemaURL.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "TestDescription.Schema";
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Schema:";
            // 
            // edtTSFLibraryDocumentURL
            // 
            this.edtTSFLibraryDocumentURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTSFLibraryDocumentURL.Location = new System.Drawing.Point(71, 89);
            this.edtTSFLibraryDocumentURL.Name = "edtTSFLibraryDocumentURL";
            this.edtTSFLibraryDocumentURL.Size = new System.Drawing.Size(319, 20);
            this.edtTSFLibraryDocumentURL.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "TestDescription.Document";
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Document:";
            // 
            // TestDescriptionTsfLibraryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.edtTSFLibraryDocumentURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtTSFLibrarySchemaURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtTSFLibraryName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtTSFLibraryId);
            this.Controls.Add(this.label1);
            this.Name = "TestDescriptionTsfLibraryControl";
            this.Size = new System.Drawing.Size(402, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.HelpLabel label1;
        private System.Windows.Forms.TextBox edtTSFLibraryId;
        private System.Windows.Forms.TextBox edtTSFLibraryName;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private System.Windows.Forms.TextBox edtTSFLibrarySchemaURL;
        private ATMLCommonLibrary.controls.HelpLabel label3;
        private System.Windows.Forms.TextBox edtTSFLibraryDocumentURL;
        private ATMLCommonLibrary.controls.HelpLabel label4;
    }
}
