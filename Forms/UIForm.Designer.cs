namespace AIGInsuranceApp
{
    partial class UIForm
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
            this.HomeInsuranceButton = new System.Windows.Forms.Button();
            this.LifeInsuranceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HomeInsuranceButton
            // 
            this.HomeInsuranceButton.Location = new System.Drawing.Point(400, 209);
            this.HomeInsuranceButton.Name = "HomeInsuranceButton";
            this.HomeInsuranceButton.Size = new System.Drawing.Size(108, 33);
            this.HomeInsuranceButton.TabIndex = 1;
            this.HomeInsuranceButton.Text = "Home Insurance";
            this.HomeInsuranceButton.UseVisualStyleBackColor = true;
            this.HomeInsuranceButton.Click += new System.EventHandler(this.HomeInsuranceButton_Click);
            // 
            // LifeInsuranceButton
            // 
            this.LifeInsuranceButton.Location = new System.Drawing.Point(195, 209);
            this.LifeInsuranceButton.Name = "LifeInsuranceButton";
            this.LifeInsuranceButton.Size = new System.Drawing.Size(108, 33);
            this.LifeInsuranceButton.TabIndex = 2;
            this.LifeInsuranceButton.Text = "Life Insurance";
            this.LifeInsuranceButton.UseVisualStyleBackColor = true;
            this.LifeInsuranceButton.Click += new System.EventHandler(this.LifeInsuranceButton_Click);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LifeInsuranceButton);
            this.Controls.Add(this.HomeInsuranceButton);
            this.Name = "UIForm";
            this.Text = "UIForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button HomeInsuranceButton;
        private System.Windows.Forms.Button LifeInsuranceButton;
    }
}