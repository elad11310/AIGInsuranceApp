namespace AIGInsuranceApp.Forms
{
    partial class DetailsForm
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
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.FirstNameInput = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.LastNameInput = new System.Windows.Forms.TextBox();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.IdInput = new System.Windows.Forms.TextBox();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.GenderListBox = new System.Windows.Forms.ListBox();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.CalculateBtn = new System.Windows.Forms.Button();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressBtn = new System.Windows.Forms.Button();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.AgeInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(156, 55);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.FirstNameLabel.TabIndex = 0;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // FirstNameInput
            // 
            this.FirstNameInput.Location = new System.Drawing.Point(380, 52);
            this.FirstNameInput.Name = "FirstNameInput";
            this.FirstNameInput.Size = new System.Drawing.Size(100, 20);
            this.FirstNameInput.TabIndex = 1;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(156, 106);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.LastNameLabel.TabIndex = 2;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // LastNameInput
            // 
            this.LastNameInput.Location = new System.Drawing.Point(380, 103);
            this.LastNameInput.Name = "LastNameInput";
            this.LastNameInput.Size = new System.Drawing.Size(100, 20);
            this.LastNameInput.TabIndex = 3;
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Location = new System.Drawing.Point(156, 155);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(44, 13);
            this.UserIdLabel.TabIndex = 4;
            this.UserIdLabel.Text = "User Id:";
            // 
            // IdInput
            // 
            this.IdInput.Location = new System.Drawing.Point(380, 152);
            this.IdInput.Name = "IdInput";
            this.IdInput.Size = new System.Drawing.Size(100, 20);
            this.IdInput.TabIndex = 5;
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(155, 201);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(45, 13);
            this.GenderLabel.TabIndex = 6;
            this.GenderLabel.Text = "Gender:";
            // 
            // GenderListBox
            // 
            this.GenderListBox.FormattingEnabled = true;
            this.GenderListBox.Location = new System.Drawing.Point(380, 201);
            this.GenderListBox.Name = "GenderListBox";
            this.GenderListBox.Size = new System.Drawing.Size(100, 30);
            this.GenderListBox.TabIndex = 9;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(380, 248);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(135, 20);
            this.StartDatePicker.TabIndex = 10;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(156, 248);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(58, 13);
            this.StartDateLabel.TabIndex = 11;
            this.StartDateLabel.Text = "Start Date:";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(155, 295);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(55, 13);
            this.EndDateLabel.TabIndex = 12;
            this.EndDateLabel.Text = "End Date:";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(380, 288);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(135, 20);
            this.EndDatePicker.TabIndex = 13;
            // 
            // CalculateBtn
            // 
            this.CalculateBtn.Location = new System.Drawing.Point(690, 55);
            this.CalculateBtn.Name = "CalculateBtn";
            this.CalculateBtn.Size = new System.Drawing.Size(75, 23);
            this.CalculateBtn.TabIndex = 14;
            this.CalculateBtn.Text = "Calculate";
            this.CalculateBtn.UseVisualStyleBackColor = true;
            this.CalculateBtn.Click += new System.EventHandler(this.CalculateBtn_Click);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(156, 332);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(45, 13);
            this.AddressLabel.TabIndex = 15;
            this.AddressLabel.Text = "Address";
            // 
            // AddressBtn
            // 
            this.AddressBtn.Location = new System.Drawing.Point(390, 325);
            this.AddressBtn.Name = "AddressBtn";
            this.AddressBtn.Size = new System.Drawing.Size(90, 27);
            this.AddressBtn.TabIndex = 16;
            this.AddressBtn.Text = "Set Address";
            this.AddressBtn.UseVisualStyleBackColor = true;
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(156, 369);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(29, 13);
            this.AgeLabel.TabIndex = 17;
            this.AgeLabel.Text = "Age:";
            // 
            // AgeInput
            // 
            this.AgeInput.Location = new System.Drawing.Point(380, 366);
            this.AgeInput.Name = "AgeInput";
            this.AgeInput.Size = new System.Drawing.Size(100, 20);
            this.AgeInput.TabIndex = 18;
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 629);
            this.Controls.Add(this.AgeInput);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.AddressBtn);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.CalculateBtn);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.GenderListBox);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.IdInput);
            this.Controls.Add(this.UserIdLabel);
            this.Controls.Add(this.LastNameInput);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameInput);
            this.Controls.Add(this.FirstNameLabel);
            this.Name = "DetailsForm";
            this.Text = "DetailsForm";
            this.Load += new System.EventHandler(this.DetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox FirstNameInput;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNameInput;
        private System.Windows.Forms.Label UserIdLabel;
        private System.Windows.Forms.TextBox IdInput;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.ListBox GenderListBox;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Button CalculateBtn;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Button AddressBtn;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.TextBox AgeInput;
    }
}