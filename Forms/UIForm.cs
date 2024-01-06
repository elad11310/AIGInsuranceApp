using AIGInsuranceApp.Forms;
using AIGInsuranceApp.Models;
using System;
using System.Windows.Forms;

namespace AIGInsuranceApp
{
    public partial class UIForm : Form
    {
        public UIForm()
        {
            InitializeComponent();


        }

        private void LifeInsuranceButton_Click(object sender, EventArgs e)
        {


            // Hide UIForm
            this.Hide();

            DetailsForm detailsForm = new DetailsForm(new LifeInsurancePolicyDetails());
            detailsForm.FormClosed += DetailsForm_FormClosed;
            detailsForm.Show();

        }

        private void HomeInsuranceButton_Click(object sender, EventArgs e)
        {
            // Hide UIForm
            this.Hide();

            DetailsForm detailsForm = new DetailsForm(new HomeApartmentPolicyDetails());
            detailsForm.FormClosed += DetailsForm_FormClosed;
            detailsForm.Show();
        }


        private void DetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Close();
            }
        }
    }
}
