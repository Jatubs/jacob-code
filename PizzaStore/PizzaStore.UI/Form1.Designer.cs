namespace PizzaStore.UI
{
    partial class Form1
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
            this.SubmitUserPass = new System.Windows.Forms.Button();
            this.Usernamefield = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SubmitUserPass
            // 
            this.SubmitUserPass.Location = new System.Drawing.Point(247, 260);
            this.SubmitUserPass.Name = "SubmitUserPass";
            this.SubmitUserPass.Size = new System.Drawing.Size(100, 23);
            this.SubmitUserPass.TabIndex = 2;
            // 
            // Usernamefield
            // 
            this.Usernamefield.Location = new System.Drawing.Point(247, 216);
            this.Usernamefield.Name = "Usernamefield";
            this.Usernamefield.Size = new System.Drawing.Size(100, 20);
            this.Usernamefield.TabIndex = 1;
            this.Usernamefield.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Usernamefield_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 425);
            this.Controls.Add(this.Usernamefield);
            this.Controls.Add(this.SubmitUserPass);
            this.Name = "Form1";
            this.Text = "PizzaStore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitUserPass;
        private System.Windows.Forms.TextBox Usernamefield;
    }
}

