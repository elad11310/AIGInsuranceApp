namespace AIGInsuranceApp
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
            this.ExcelButton = new System.Windows.Forms.Button();
            this.UIButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExcelButton
            // 
            this.ExcelButton.Location = new System.Drawing.Point(464, 177);
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(109, 44);
            this.ExcelButton.TabIndex = 0;
            this.ExcelButton.Text = "Excel";
            this.ExcelButton.UseVisualStyleBackColor = true;
            this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
            // 
            // UIButton
            // 
            this.UIButton.Location = new System.Drawing.Point(194, 177);
            this.UIButton.Name = "UIButton";
            this.UIButton.Size = new System.Drawing.Size(109, 44);
            this.UIButton.TabIndex = 1;
            this.UIButton.Text = "UI";
            this.UIButton.UseVisualStyleBackColor = true;
            this.UIButton.Click += new System.EventHandler(this.UIButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UIButton);
            this.Controls.Add(this.ExcelButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExcelButton;
        private System.Windows.Forms.Button UIButton;
    }
}

