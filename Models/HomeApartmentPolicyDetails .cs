using AIGInsuranceApp.StaticData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGInsuranceApp.Models
{
    public class HomeApartmentPolicyDetails : BasePolicyDetails
    {
        public List<HomeDetails> homeDetailsList = new List<HomeDetails>();
        private string selectedHomeType = string.Empty;
        private const int XOFFSET = 40;
        private const int YOFFSET = 40;
        private TextBox homeAgeTextBox;
        private TextBox homeSizeTextBox;

        public HomeApartmentPolicyDetails()
        {
            
            string homeDetailStr = Helper.ReadFromFile(Helper.GetFilePath("Resources", "home_types.json"));
            InitHomeDetails(homeDetailStr);
            BasicPrice = 15;
        }

        public int SizeSquareMeter { get; set; }

        public HomeDetails HomeDetails { get; set; }

        public int HomeAge { get; set; }

        private void InitHomeDetails(string homeDetailStr)
        {
            homeDetailsList = JsonConvert.DeserializeObject<List<HomeDetails>>(homeDetailStr);
        }


        protected override void AddUIFields(Form form)
        {

            Label homeTypeLabel = new Label();
            homeTypeLabel.Text = "Home Type:";

            AddController(homeTypeLabel, form, XOFFSET, YOFFSET);


            ComboBox homeTypeList = new ComboBox();
            homeTypeList.Items.AddRange(
                homeDetailsList
               .Select(h => h.HomeType.ToString())
               .ToArray());


            AddController(homeTypeList, form, XOFFSET, YOFFSET);

            Label homeAgeLabel = new Label();
            homeAgeLabel.Text = "Home Age:";


            AddController(homeAgeLabel, form, XOFFSET, YOFFSET,false);


            homeAgeTextBox = new TextBox();
            homeAgeTextBox.KeyPress += NumericInputValidation;

            AddController(homeAgeTextBox, form, XOFFSET, YOFFSET,false);

            Label homeSizeLabel = new Label();
            homeSizeLabel.Text = "Home Size:";

            AddController(homeSizeLabel, form, XOFFSET, YOFFSET, false);



            homeSizeTextBox = new TextBox();
            homeSizeTextBox.KeyPress += NumericInputValidation;

            AddController(homeSizeTextBox, form, XOFFSET, YOFFSET, false);

            // Subscribe to the ItemCheck 
            homeTypeList.SelectedIndexChanged += new EventHandler((sender, e) => SelectedIndexChanged(
            sender,
            e,
            homeTypeList,
            ref selectedHomeType));

        }

        protected override void CalculatePolicy(bool UIRequest)
        {
            int daysForPolicy = (EndDate - StartDate).Days;
            // Only in case of UI
            if (UIRequest)
            {
                HomeDetails = homeDetailsList.Where(o => o.HomeType.ToString() == selectedHomeType).FirstOrDefault();
                HomeAge = Int16.Parse(homeAgeTextBox.Text);
                SizeSquareMeter = Int16.Parse(homeSizeTextBox.Text);
            }
            PolicyPrice = daysForPolicy * BasicPrice
                + daysForPolicy * (HomeDetails.PriceSquareMeter* SizeSquareMeter)
                + daysForPolicy * GetPriceByAge(BasicPrice, HomeAge);
        }
    }
}

