namespace VoiceMeeterTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(119, 9);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(423, 22);
            this.textBoxKey.TabIndex = 1;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(119, 37);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(423, 22);
            this.textBoxValue.TabIndex = 2;
            // 
            // labelKey
            // 
            this.labelKey.Location = new System.Drawing.Point(12, 9);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(80, 22);
            this.labelKey.TabIndex = 3;
            this.labelKey.Text = "Key";
            // 
            // labelValue
            // 
            this.labelValue.Location = new System.Drawing.Point(12, 37);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(80, 22);
            this.labelValue.TabIndex = 4;
            this.labelValue.Text = "Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 107);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxValue;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}
