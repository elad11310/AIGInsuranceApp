using AIGInsuranceApp.Forms;
using AIGInsuranceApp.Models;
using AIGInsuranceApp.PolicyHandler;
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
    public partial class UIForm : Form
    {
        public UIForm()
        {
            InitializeComponent();
             

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide UIForm
            this.Hide();

            // Show Form1 (assuming it's already instantiated)
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
           
            form1.Show();
            
        }

        private void LifeInsuranceButton_Click(object sender, EventArgs e)
        {
            // Hide UIForm
            this.Hide();

            DetailsForm detailsForm = new DetailsForm(new LifeInsurancePolicyDetails());
            detailsForm.Show();
        
        }

        private void HomeInsuranceButton_Click(object sender, EventArgs e)
        {

        }
    }
}
