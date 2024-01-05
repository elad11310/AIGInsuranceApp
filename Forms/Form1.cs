using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGInsuranceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UIButton_Click(object sender, EventArgs e)
        {
            // Create an instance of UI form
            UIForm uiForm = new UIForm();

            // Subscribe to the FormClosed event of UIForm
            uiForm.FormClosed += UIForm_FormClosed;

            // Hide Form1 and show UIForm
            this.Hide();
            uiForm.Show();
        }

        private void ExcelButton_Click(object sender, EventArgs e)
        {

        }


        private void UIForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When UIForm is closed, close Form1 (exit the application)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // The form was closed by the user clicking the "X" button
                // Close Form1 (exit the application)
              //  this.Close();
            }
        }
    }
}
