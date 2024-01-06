using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGInsuranceApp.Models
{
    public abstract class BasePolicyDetails
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string IdentityNumber { get; set; }
        public Gender Gender { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public byte Age { get; set; }

        public Address Address { get; set; }

        public double PolicyPrice { get; set; }


        // Basic price for a day and it may change due to the type of the policy
        public double BasicPrice { get; set; }


        protected abstract void CalculatePolicy(bool UIRequest);

        protected abstract void AddUIFields(Form form);


        public void InitializeUIFields(Form form)
        {
            AddUIFields(form);
        }

        public void Calculate(bool UIRequest)
        {
            CalculatePolicy(UIRequest);

        }


        public void NumericInputValidation(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and control keys (like backspace) in the TextBox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void SetDefaultDetails(Form form)
        {
            this.FirstName = form.Controls.Find("FirstNameInput", true).FirstOrDefault().Text;
            this.LastName = form.Controls.Find("LastNameInput", true).FirstOrDefault().Text;
            this.IdentityNumber = form.Controls.Find("IdInput", true).FirstOrDefault().Text;
            this.Gender = (Gender)Enum.Parse(typeof(Gender), form.Controls.Find("GenderListBox", true).FirstOrDefault().Text);
            this.Age = Byte.Parse(form.Controls.Find("AgeInput", true).FirstOrDefault().Text);
            DateTimePicker startDatePicker = form.Controls.Find("StartDatePicker", true).FirstOrDefault() as DateTimePicker;

            if (startDatePicker != null)
            {
                this.StartDate = startDatePicker.Value;
            }
            DateTimePicker endDatePicker = form.Controls.Find("EndDatePicker", true).FirstOrDefault() as DateTimePicker;

            if (endDatePicker != null)
            {
                this.EndDate = endDatePicker.Value;
            }




        }


        public void AddController(Control control, Form form, int XOffset, int YOffset, bool isFirstTime = true)
        {
            Control lastControl;

            // Find the last control added to the form 

            if (form.Controls.Count == 0)
            {
                form.Controls.Add(control);
                return;
            }

            if (control.GetType() == typeof(Label))
            {
                lastControl = isFirstTime ? form.Controls[1] : form.Controls[form.Controls.Count - 2];
            }
            else
            {
                lastControl = isFirstTime ? form.Controls[0] : form.Controls[form.Controls.Count - 2];
            }

            if (lastControl != null)
            {
                control.Width = 100;
                if (form.Controls.Count > 1)
                    control.Location = new Point(lastControl.Location.X, lastControl.Location.Y + YOffset);
                else
                    control.Location = new Point(lastControl.Location.X + XOffset, lastControl.Location.Y);
            }

            // Add the control to the specified form
            form.Controls.Add(control);


        }

        public void HandleButtonClick(Button button, Action onClickAction)
        {
            button.Click += (sender, e) =>
            {
                onClickAction?.Invoke();
            };
        }

        protected void SelectedIndexChanged(object sender, EventArgs e, ComboBox comboBox, ref string selectedVariable)
        {
            if (comboBox.SelectedIndex != -1)
            {
                selectedVariable = comboBox.SelectedItem.ToString();

            }
        }

     
        protected double GetPriceByAge(double basePrice, int age)
        {
            if (age > 0 && age <= 30)
            {
                return 0.2 * basePrice;
            }
            if (age > 30 && age <= 60)
            {
                return 0.4 * basePrice;
            }
            if (age > 60 && age <= 90)
            {
                return 0.6 * basePrice;
            }

            return -1;
        }

 
    }
}
