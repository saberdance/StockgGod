namespace Starter
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
            this.Inject = new System.Windows.Forms.Button();
            this.DragFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Inject
            // 
            this.Inject.Location = new System.Drawing.Point(159, 59);
            this.Inject.Name = "Inject";
            this.Inject.Size = new System.Drawing.Size(122, 53);
            this.Inject.TabIndex = 0;
            this.Inject.Text = "注入";
            this.Inject.UseVisualStyleBackColor = true;
            this.Inject.Click += new System.EventHandler(this.Inject_Click);
            // 
            // DragFile
            // 
            this.DragFile.AllowDrop = true;
            this.DragFile.AutoSize = true;
            this.DragFile.Font = new System.Drawing.Font("SimSun", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DragFile.Location = new System.Drawing.Point(24, 153);
            this.DragFile.Name = "DragFile";
            this.DragFile.Size = new System.Drawing.Size(377, 40);
            this.DragFile.TabIndex = 1;
            this.DragFile.Text = "拖动交易软件到此处";
            this.DragFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragFile_DragDrop);
            this.DragFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragFile_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 299);
            this.Controls.Add(this.DragFile);
            this.Controls.Add(this.Inject);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Inject;
        private System.Windows.Forms.Label DragFile;
    }
}

