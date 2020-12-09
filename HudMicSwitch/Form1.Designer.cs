namespace HudMicSwitch
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
            this.btnTalk = new System.Windows.Forms.Button();
            this.btnBTW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTalk
            // 
            this.btnTalk.Location = new System.Drawing.Point(12, 12);
            this.btnTalk.Name = "btnTalk";
            this.btnTalk.Size = new System.Drawing.Size(274, 91);
            this.btnTalk.TabIndex = 0;
            this.btnTalk.Text = "Talk";
            this.btnTalk.UseVisualStyleBackColor = true;
            this.btnTalk.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBTW
            // 
            this.btnBTW.Location = new System.Drawing.Point(12, 109);
            this.btnBTW.Name = "btnBTW";
            this.btnBTW.Size = new System.Drawing.Size(274, 91);
            this.btnBTW.TabIndex = 1;
            this.btnBTW.Text = "Back to work";
            this.btnBTW.UseVisualStyleBackColor = true;
            this.btnBTW.Click += new System.EventHandler(this.btnBTW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 205);
            this.Controls.Add(this.btnBTW);
            this.Controls.Add(this.btnTalk);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnBTW;

        private System.Windows.Forms.Button btnTalk;

        #endregion
    }
}

