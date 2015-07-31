/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.environmental
{
    partial class EnvironmentalElementsVibrationControl
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
            this.lblVelocity = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblDisplacement = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblFrequency = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.frequency = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.displacement = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.velocity = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.SuspendLayout();
            // 
            // lblVelocity
            // 
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.HelpMessageKey = "EnvironmentElementsVibrations.velocity";
            this.lblVelocity.Location = new System.Drawing.Point(29, 73);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.RequiredField = false;
            this.lblVelocity.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelocity.Size = new System.Drawing.Size(44, 13);
            this.lblVelocity.TabIndex = 17;
            this.lblVelocity.Text = "Velocity";
            // 
            // lblDisplacement
            // 
            this.lblDisplacement.AutoSize = true;
            this.lblDisplacement.HelpMessageKey = "EnvironmentElementsVibrations.displacement";
            this.lblDisplacement.Location = new System.Drawing.Point(3, 42);
            this.lblDisplacement.Name = "lblDisplacement";
            this.lblDisplacement.RequiredField = false;
            this.lblDisplacement.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplacement.Size = new System.Drawing.Size(71, 13);
            this.lblDisplacement.TabIndex = 16;
            this.lblDisplacement.Text = "Displacement";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.HelpMessageKey = "EnvironmentElementsVibrations.frequency";
            this.lblFrequency.Location = new System.Drawing.Point(17, 11);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.RequiredField = false;
            this.lblFrequency.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrequency.Size = new System.Drawing.Size(57, 13);
            this.lblFrequency.TabIndex = 15;
            this.lblFrequency.Text = "Frequency";
            // 
            // frequency
            // 
            this.frequency.Limit = null;
            this.frequency.Location = new System.Drawing.Point(76, 8);
            this.frequency.Margin = new System.Windows.Forms.Padding(0);
            this.frequency.Name = "frequency";
            this.frequency.SchemaTypeName = null;
            this.frequency.Size = new System.Drawing.Size(320, 24);
            this.frequency.TabIndex = 18;
            this.frequency.TargetNamespace = null;
            // 
            // displacement
            // 
            this.displacement.Limit = null;
            this.displacement.Location = new System.Drawing.Point(77, 39);
            this.displacement.Margin = new System.Windows.Forms.Padding(0);
            this.displacement.Name = "displacement";
            this.displacement.SchemaTypeName = null;
            this.displacement.Size = new System.Drawing.Size(320, 24);
            this.displacement.TabIndex = 19;
            this.displacement.TargetNamespace = null;
            // 
            // velocity
            // 
            this.velocity.Limit = null;
            this.velocity.Location = new System.Drawing.Point(76, 70);
            this.velocity.Margin = new System.Windows.Forms.Padding(0);
            this.velocity.Name = "velocity";
            this.velocity.SchemaTypeName = null;
            this.velocity.Size = new System.Drawing.Size(320, 24);
            this.velocity.TabIndex = 20;
            this.velocity.TargetNamespace = null;
            // 
            // EnvironmentalElementsVibrationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.displacement);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.lblDisplacement);
            this.Controls.Add(this.lblFrequency);
            this.Name = "EnvironmentalElementsVibrationControl";
            this.Size = new System.Drawing.Size(402, 99);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel lblVelocity;
        private HelpLabel lblDisplacement;
        private HelpLabel lblFrequency;
        private limit.LimitSimpleControl frequency;
        private limit.LimitSimpleControl displacement;
        private limit.LimitSimpleControl velocity;


    }
}
