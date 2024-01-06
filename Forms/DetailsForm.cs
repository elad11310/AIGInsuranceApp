using AIGInsuranceApp.Models;
using AIGInsuranceApp.StaticData;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGInsuranceApp.Forms
{
    public partial class DetailsForm : Form
    {
        private BasePolicyDetails _policy;
        private List<Gender> _genderList;
        private const int XOFFSET = 110;
        private const int YOFFSET = 40;
        private List<string> citiesList = new List<string>();
        private string API_KEY = string.Empty;
        private ComboBox streets;
        private Timer timer;
        private bool typedStreet = false;

        public DetailsForm(BasePolicyDetails policy)
        {
            InitializeComponent();
            _policy = policy;
            _genderList = new List<Gender> { Gender.Male, Gender.Female, };
            // Read API key
            API_KEY = Helper.ReadFromFile(Helper.GetFilePath("Resources", "api_key.txt"));
            InitAddressForm();



            // Initialize and set up the timer for user typing in street field
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;

        }



        private async Task InitCities()
        {

            // Need to make API call

            string baseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/json";

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("query", "cities+in+israel"),
                        new KeyValuePair<string, string>("key", API_KEY)
                    };
            string nextPageToken = string.Empty;
            do
            {
               
                var res = await Helper.MakeAPIRequest(baseUrl, parameters);
                if (!string.IsNullOrEmpty(res))
                {
                    JObject jsonObject = JObject.Parse(res);
                    if (jsonObject.ContainsKey("next_page_token"))
                    {
                        nextPageToken = jsonObject["next_page_token"].ToString();
                        if (!string.IsNullOrEmpty(nextPageToken))
                        {
                            parameters.Add(new KeyValuePair<string, string>("pagetoken", nextPageToken));
                        }

                    }
                    else
                    {
                        nextPageToken = string.Empty;
                    }
                   

                    // Accessing all the 'name' attributes
                    JArray results = (JArray)jsonObject["results"];
                    foreach (JToken result in results)
                    {
                        string name = (string)result["name"];
                        citiesList.Add(name);
                    }
                }

            } while (!string.IsNullOrEmpty(nextPageToken));


        }


        private async void InitAddressForm()
        {

            Form addressPopupForm = new Form
            {
                Text = "Fill Address",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.Manual
            };

            Label apartmentLabel = new Label
            {
                Text = "Apartment:",
                Location = new Point(10, 10)
            };

            _policy.AddController(apartmentLabel, addressPopupForm, XOFFSET, YOFFSET);


            TextBox apartmentInput = new TextBox();
            _policy.AddController(apartmentInput, addressPopupForm, XOFFSET, YOFFSET);


            Label apartmentNumberLabel = new Label
            {
                Text = "Apartment number:"
            };
            _policy.AddController(apartmentNumberLabel, addressPopupForm, XOFFSET, YOFFSET, false);


            TextBox apartmentNumberInput = new TextBox();
            _policy.AddController(apartmentNumberInput, addressPopupForm, XOFFSET, YOFFSET, false);

            Label cityLabel = new Label
            {
                Text = "City:"
            };
            _policy.AddController(cityLabel, addressPopupForm, XOFFSET, YOFFSET, false);

            // API call

            if (citiesList.Count == 0)
            {
                await InitCities();
            }


            ComboBox cities = new ComboBox();

            cities.Items.AddRange(citiesList.ToArray());
            _policy.AddController(cities, addressPopupForm, XOFFSET, YOFFSET, false);


            Label streetLabel = new Label
            {
                Text = "Street:"
            };

            _policy.AddController(streetLabel, addressPopupForm, XOFFSET, YOFFSET, false);


            streets = new ComboBox();
            streets.TextChanged += ComboBox_TextChanged;

            _policy.AddController(streets, addressPopupForm, XOFFSET, YOFFSET, false);



            Label floorLabel = new Label()
            {
                Text = "Floor"
            };

            _policy.AddController(floorLabel, addressPopupForm, XOFFSET, YOFFSET, false);

            TextBox floorInput = new TextBox();
            _policy.AddController(floorInput, addressPopupForm, XOFFSET, YOFFSET, false);


            Button confirmButton = new Button
            {
                Text = "Confirm"
            };

            _policy.AddController(confirmButton, addressPopupForm, XOFFSET, YOFFSET, false);



            _policy.HandleButtonClick(AddressBtn, () =>
            {
                if (!addressPopupForm.Visible)
                {

                    addressPopupForm.Location = new Point(AddressBtn.Left, AddressBtn.Bottom);
                    addressPopupForm.Size = new Size(300, 300);

                    addressPopupForm.Show();
                }
                else
                {
                    addressPopupForm.Hide();
                }
            });

            _policy.HandleButtonClick(confirmButton, () =>
            {

                _policy.Address = new Address()
                {
                    Apartment = apartmentInput.Text,
                    ApartmentNumber = apartmentNumberInput.Text,
                    Floor = floorInput.Text,
                    City = cities.SelectedItem.ToString(),
                    Street = streets.Text.ToString().TrimEnd(' ')

                };

                addressPopupForm.Hide();
            });

            addressPopupForm.Deactivate += (sender, e) =>
            {
                addressPopupForm.Hide();
            };

        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            // Allowing only numbers in the user identity number input
            IdInput.KeyPress += _policy.NumericInputValidation;
            // populating the gender list box with data
            GenderListBox.DataSource = _genderList;


            _policy.InitializeUIFields(this);


        }


        private async void Timer_Tick(object sender, EventArgs e)
        {
            string enteredText = streets.Text.Trim();

            // Make an API request based on the entered text
            if (!string.IsNullOrEmpty(enteredText) && typedStreet)
            {
                streets.Items.Clear();
                string baseUrl = "https://data.gov.il/api/3/action/datastore_search";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("resource_id", "1b14e41c-85b3-4c21-bdce-9fe48185ffca"),
                        new KeyValuePair<string, string>("limit", "50"),
                        new KeyValuePair<string, string>("q", enteredText)

                    };

                var res = await Helper.MakeAPIRequest(baseUrl, parameters);
                if (!string.IsNullOrEmpty(res))
                {
                    JObject jsonObject = JObject.Parse(res);

                    // Accessing all the 'name' attributes
                    JArray results = (JArray)jsonObject["result"]["records"];
                    foreach (JToken result in results)
                    {
                        string name = (string)result["street_name"];
                        if (!streets.Items.Contains(name))
                            streets.Items.Add(name);
                    }
                }
                typedStreet = false;

            }


        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            typedStreet = true;
            timer.Stop();
            timer.Start();

        }


        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            _policy.SetDefaultDetails(this);
            _policy.Calculate(UIRequest:true);

            if (_policy is LifeInsurancePolicyDetails)
            {
                // Checking if it's not over 75%

                LifeInsurancePolicyDetails lifeInstance = (LifeInsurancePolicyDetails)_policy;

                float risk = lifeInstance.Profession.Risk + lifeInstance.Hobbies.Sum(o => o.Risk);
                if (risk >= lifeInstance.RiskPolicyLimit)
                {
                    MessageBox.Show($"You can't get insurance , The risk is {risk * 100}%");
                }
                else
                {
                    MessageBox.Show($"The price for this policy is {_policy.PolicyPrice:F3}$");
                }
            }
            else
            {
                MessageBox.Show($"The price for this policy is {_policy.PolicyPrice:F3}$");
            }
        }


    }
}
