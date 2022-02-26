namespace Crypto
{
    partial class Form_Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Loading));
            this.button_Close = new System.Windows.Forms.Button();
            this.label_loading_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(12, 12);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(22, 23);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "X";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label_loading_text
            // 
            this.label_loading_text.AutoSize = true;
            this.label_loading_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(11)))));
            this.label_loading_text.Location = new System.Drawing.Point(9, 204);
            this.label_loading_text.Name = "label_loading_text";
            this.label_loading_text.Size = new System.Drawing.Size(35, 13);
            this.label_loading_text.TabIndex = 1;
            this.label_loading_text.Text = "label1";
            // 
            // Form_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(373, 226);
            this.Controls.Add(this.label_loading_text);
            this.Controls.Add(this.button_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Loading";
            this.Activated += new System.EventHandler(this.Form_Loading_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_loading_text;
    }
}