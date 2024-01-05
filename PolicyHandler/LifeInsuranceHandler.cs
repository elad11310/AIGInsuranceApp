using AIGInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AIGInsuranceApp.PolicyHandler
{
    internal class LifeInsuranceHandler : IPolicyDetails
    {
        private List<string> selectedHobbies;
        private string selectedProfession = string.Empty;
        public LifeInsuranceHandler()
        {
        }
        public void AddUIFields(Form form)
        {

            Label hobbiesLabel = new Label();
            hobbiesLabel.Text = "Hobbies";

            AddController(hobbiesLabel, form);


            Button hobbiesBtn = new Button();
            hobbiesBtn.Text = "Select Hobbies";
            hobbiesBtn.Width = 150;


            AddController(hobbiesBtn, form);


            Form popupForm = new Form();
            popupForm.Text = hobbiesBtn.Text;
            popupForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            popupForm.StartPosition = FormStartPosition.Manual;


            // Add hobbies from db
            ListBox hobbiesListBox = new ListBox();
            hobbiesListBox.SelectionMode = SelectionMode.MultiSimple;
            hobbiesListBox.Items.Add("Reading");
            hobbiesListBox.Items.Add("Gardening");
            hobbiesListBox.Items.Add("Hiking");



            AddController(hobbiesListBox, popupForm);


            Button confirmButton = new Button();
            confirmButton.Text = "Confirm Selection";
            confirmButton.Width = 120;

            AddController(confirmButton, popupForm);

            popupForm.Controls.Add(hobbiesListBox);
            popupForm.Controls.Add(confirmButton);


            HandleButtonClick(hobbiesBtn, () =>
            {
                if (!popupForm.Visible)
                {
                    popupForm.Location = new Point(hobbiesBtn.Left, hobbiesBtn.Bottom);
                    hobbiesListBox.Size = new Size(hobbiesBtn.Width, 100);
                    hobbiesListBox.Location = new Point(70, 50);
                    confirmButton.Location = new Point(hobbiesListBox.Left, hobbiesListBox.Bottom + 20);
                    popupForm.Show();
                }
                else
                {
                    popupForm.Hide();
                }
            });

            HandleButtonClick(confirmButton, () =>
            {
                selectedHobbies = new List<string>();
                foreach (var item in hobbiesListBox.SelectedItems)
                {
                    selectedHobbies.Add(item.ToString());
                }

                popupForm.Hide();
            });

            popupForm.Deactivate += (sender, e) =>
            {
                popupForm.Hide();
            };


            // read from db 
            ComboBox professionList = new ComboBox();

            professionList.Items.Add("Reading");
            professionList.Items.Add("Gardening");
            professionList.Items.Add("Hiking");


            Label professionLabel = new Label();
            professionLabel.Text = "Profession";

            AddController(professionLabel, form, isFirstTime: false);
            AddController(professionList, form, isFirstTime: false);

            // Subscribe to the ItemCheck event or perform any other setup here
            professionList.SelectedIndexChanged += new EventHandler((sender, e) => SelectedIndexChanged(
            sender,
            e,
            professionList,
            ref selectedProfession));
        }

        public string CalculatePolicy()
        {
            return "";
        }



        private void AddController(Control control, Form form, bool isFirstTime = true)
        {
            Control lastControl;

            // Find the last control added to the form 

            if (form.Controls.Count == 0)
            {
                form.Controls.Add(control);
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
                control.Width = 135;
                control.Location = new Point(lastControl.Location.X, lastControl.Location.Y + 40);
            }

            // Add the control to the specified form
            form.Controls.Add(control);


        }
        private void SelectedIndexChanged(object sender, EventArgs e, ComboBox comboBox, ref string selectedVariable)
        {
            if (comboBox.SelectedIndex != -1)
            {
                selectedVariable = comboBox.SelectedItem.ToString();

            }
        }

        private void HandleButtonClick(Button button, Action onClickAction)
        {
            button.Click += (sender, e) =>
            {
                onClickAction?.Invoke();
            };
        }
    }
}
