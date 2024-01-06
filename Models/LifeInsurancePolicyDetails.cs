using AIGInsuranceApp.StaticData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGInsuranceApp.Models
{
    public class LifeInsurancePolicyDetails : BasePolicyDetails
    {
        private List<Occupation> selectedHobbies;
        private string selectedProfession = string.Empty;
        private const int XOFFSET = 40;
        private const int YOFFSET = 40;
        public List<Occupation> occupationsList = new List<Occupation>();
        public LifeInsurancePolicyDetails()
        {

            string occupationStr = Helper.ReadFromFile(Helper.GetFilePath("Resources", "occupations.json"));
            InitOccupations(occupationStr);
            BasicPrice = 10;
        }

        public List<Occupation> Hobbies { get; set; }

        public Occupation Profession { get; set; }

        public float RiskPolicyLimit { get; set; } = 0.75f;

        private void InitOccupations(string occupationsJson)
        {
            occupationsList = JsonConvert.DeserializeObject<List<Occupation>>(occupationsJson);
        }


        protected override void AddUIFields(Form form)
        {

            Label hobbiesLabel = new Label();
            hobbiesLabel.Text = "Hobbies";

            AddController(hobbiesLabel, form, XOFFSET, YOFFSET);


            Button hobbiesBtn = new Button();
            hobbiesBtn.Text = "Select Hobbies";
            hobbiesBtn.Width = 150;


            AddController(hobbiesBtn, form, XOFFSET, YOFFSET);


            Form popupForm = new Form();
            popupForm.Text = hobbiesBtn.Text;
            popupForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            popupForm.StartPosition = FormStartPosition.Manual;


            ListBox hobbiesListBox = new ListBox();
            hobbiesListBox.SelectionMode = SelectionMode.MultiSimple;
            hobbiesListBox.Items.AddRange(
                occupationsList.
                Where(o => o.OccupationType == OccupationType.Hobby)
               .Select(o => o.Name)
               .ToArray());




            AddController(hobbiesListBox, popupForm, XOFFSET, YOFFSET);


            Button confirmButton = new Button();
            confirmButton.Text = "Confirm Selection";
            confirmButton.Width = 120;

            AddController(confirmButton, popupForm, XOFFSET, YOFFSET);

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
                selectedHobbies = new List<Occupation>();
                foreach (var item in hobbiesListBox.SelectedItems)
                {
                    selectedHobbies.Add(
                        occupationsList
                        .Where(o => o.Name == item.ToString())
                        .FirstOrDefault());
                }

                popupForm.Hide();
            });

            popupForm.Deactivate += (sender, e) =>
            {
                popupForm.Hide();
            };


            ComboBox professionList = new ComboBox();
            professionList.Items.AddRange(
                occupationsList.
                Where(o => o.OccupationType == OccupationType.Profession)
               .Select(o => o.Name)
               .ToArray());


            Label professionLabel = new Label();
            professionLabel.Text = "Profession";

            AddController(professionLabel, form, XOFFSET, YOFFSET, isFirstTime: false);
            AddController(professionList, form, XOFFSET, YOFFSET, isFirstTime: false);

            // Subscribe to the ItemCheck 
            professionList.SelectedIndexChanged += new EventHandler((sender, e) => SelectedIndexChanged(
            sender,
            e,
            professionList,
            ref selectedProfession));
        }

        protected override void CalculatePolicy(bool UIRequest)
        {
            int daysForPolicy = (EndDate - StartDate).Days;
            // Only in case it's from UI
            if (UIRequest)
            {
                Hobbies = selectedHobbies;
                Profession = occupationsList.Where(o => o.Name == selectedProfession).FirstOrDefault();
            }

            PolicyPrice = daysForPolicy * BasicPrice
                + daysForPolicy * ((Profession.Risk + Hobbies.Sum(o => o.Risk)) * BasicPrice)
                + daysForPolicy * GetPriceByAge(BasicPrice, Age);


        }
    }
}

