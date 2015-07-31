namespace ATMLCommonLibrary.controls.connector
{
    partial class ConnectorConfigurationForm
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
            this.edtConfigurationName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.requiredFieldValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edtConfigurationName);
            this.panel1.Size = new System.Drawing.Size(464, 65);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(402, 83);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(321, 83);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 94);
            // 
            // edtConfigurationName
            // 
            this.edtConfigurationName.AttributeName = null;
            this.edtConfigurationName.DataLookupKey = null;
            this.edtConfigurationName.Location = new System.Drawing.Point(53, 24);
            this.edtConfigurationName.Name = "edtConfigurationName";
            this.edtConfigurationName.Size = new System.Drawing.Size(380, 20);
            this.edtConfigurationName.TabIndex = 0;
            this.edtConfigurationName.Value = null;
            this.edtConfigurationName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // requiredFieldValidator
            // 
            this.requiredFieldValidator.ControlToValidate = this.edtConfigurationName;
            this.requiredFieldValidator.ErrorMessage = "The Configuration Name is required.";
            this.requiredFieldValidator.ErrorProvider = this.errorProvider;
            this.requiredFieldValidator.Icon = null;
            this.requiredFieldValidator.InitialValue = null;
            this.requiredFieldValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConnectorConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 110);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConnectorConfigurationForm";
            this.Text = "Connector Configuration";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtConfigurationName;
        private System.Windows.Forms.Label label1;
        private validators.RequiredFieldValidator requiredFieldValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}