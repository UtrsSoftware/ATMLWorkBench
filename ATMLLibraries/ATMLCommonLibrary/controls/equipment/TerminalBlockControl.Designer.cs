/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.equipment
{
    partial class TerminalBlockControl
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
            this.InterfaceportList = new ATMLCommonLibrary.controls.common.PortListControl();
            this.TestEQTerminalBlocksInterface = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // InterfaceportList
            // 
            this.InterfaceportList.ListName = null;
            this.InterfaceportList.Location = new System.Drawing.Point(12, 200);
            this.InterfaceportList.Margin = new System.Windows.Forms.Padding(0);
            this.InterfaceportList.Name = "InterfaceportList";
            this.InterfaceportList.SchemaTypeName = null;
            this.InterfaceportList.ShowFind = false;
            this.InterfaceportList.Size = new System.Drawing.Size(465, 169);
            this.InterfaceportList.TabIndex = 12;
            this.InterfaceportList.TargetNamespace = null;
            // 
            // TestEQTerminalBlocksInterface
            // 
            this.TestEQTerminalBlocksInterface.AutoSize = true;
            this.TestEQTerminalBlocksInterface.HelpMessageKey = null;
            this.TestEQTerminalBlocksInterface.Location = new System.Drawing.Point(10, 183);
            this.TestEQTerminalBlocksInterface.Name = "TestEQTerminalBlocksInterface";
            this.TestEQTerminalBlocksInterface.RequiredField = false;
            this.TestEQTerminalBlocksInterface.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestEQTerminalBlocksInterface.Size = new System.Drawing.Size(49, 13);
            this.TestEQTerminalBlocksInterface.TabIndex = 13;
            this.TestEQTerminalBlocksInterface.Text = "Interface";
            // 
            // TestEquipmentTerminalBlocksTerminalBlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TestEQTerminalBlocksInterface);
            this.Controls.Add(this.InterfaceportList);
            this.Name = "TestEquipmentTerminalBlocksTerminalBlockControl";
            this.Size = new System.Drawing.Size(507, 392);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.edtIncrementBy, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.edtReplacementChar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.edtCount, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.edtBaseIndex, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.InterfaceportList, 0);
            this.Controls.SetChildIndex(this.TestEQTerminalBlocksInterface, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.PortListControl InterfaceportList;
        private HelpLabel TestEQTerminalBlocksInterface;
    }
}
