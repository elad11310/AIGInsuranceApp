using AIGInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using AIGInsuranceApp.StaticData;
using System.ComponentModel;
using System.Threading;

namespace AIGInsuranceApp
{
    public partial class MainForm : Form
    {
        public MainForm()
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

            // Hide Main Form and show UIForm
            this.Hide();
            uiForm.Show();
        }

        private void ExcelButton_Click(object sender, EventArgs e)
        {
            string filePath = Helper.GetFilePath("Resources", "policies.xlsx");
            var listOfPolices = ReadExcelData(filePath);
            List<string> policyPrices = new List<string>();
            int i = 1;

            foreach (var _policy in listOfPolices)
            {


                _policy.Calculate(UIRequest: false);

                if (_policy is LifeInsurancePolicyDetails)
                {
                    // Checking if it's not over 75%

                    LifeInsurancePolicyDetails lifeInstance = (LifeInsurancePolicyDetails)_policy;

                    float risk = lifeInstance.Profession.Risk + lifeInstance.Hobbies.Sum(o => o.Risk);
                    if (risk >= lifeInstance.RiskPolicyLimit)
                    {
                        MessageBox.Show($"You can't get insurance  for policy number {i++}, The risk is {risk * 100}%");
                        policyPrices.Add("-1");
                    }
                    else
                    {
                        MessageBox.Show($"The price for this policy number {i++} is {_policy.PolicyPrice:F3}$");
                        policyPrices.Add(_policy.PolicyPrice.ToString());
                    }
                }
                else
                {
                    MessageBox.Show($"The price for this policy number {i++} is {_policy.PolicyPrice:F3}$");
                    policyPrices.Add(_policy.PolicyPrice.ToString());
                }



            }
            WriteExcelData(filePath, policyPrices);
        }





        private void WriteExcelData(string filePath, List<string> policyPrices)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            // Assuming the data is on the first sheet
            Worksheet worksheet = workbook.Sheets[1];

            var range = worksheet.UsedRange;

            int rows = range.Rows.Count;
            int columns = range.Columns.Count;
            // Assuming the header row is the first row
            int headerRow = 1;
            int policyPriceColumn = FindColumnByHeader(worksheet, headerRow, "PolicyPrice");

            if (policyPriceColumn != -1)
            {
                // Write data to the "PolicyPrice" column starting from row 2
                int startRow = 2;
                int rowCount = policyPrices.Count;
                int k = 0;
                for (int i = startRow; i < startRow + rowCount; i++)
                {
                    // Set value in the "PolicyPrice" column for each row
                    worksheet.Cells[i, policyPriceColumn].Value2 = policyPrices[k++];

                }

                // Save changes and close the workbook
                workbook.Save();
                workbook.Close();
                excelApp.Quit();
            }



        }


        // Function to find the column number by its header value
        public int FindColumnByHeader(Worksheet worksheet, int headerRow, string headerValue)
        {
            int lastColumn = worksheet.Cells[headerRow, worksheet.Columns.Count].End(XlDirection.xlToLeft).Column;

            for (int col = 1; col <= lastColumn; col++)
            {
                string cellValue = worksheet.Cells[headerRow, col].Value2?.ToString();
                if (cellValue != null && cellValue.Equals(headerValue, System.StringComparison.OrdinalIgnoreCase))
                {
                    return col;
                }
            }

            return -1; // Column not found
        }

        private void UIForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Close();
            }
        }




        public List<BasePolicyDetails> ReadExcelData(string filePath)
        {
            var policies = new List<BasePolicyDetails>();

            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var workbook = excelApp.Workbooks.Open(filePath);
            var worksheet = (Worksheet)workbook.Sheets[1];
            var range = worksheet.UsedRange;

            int rows = range.Rows.Count;
            int columns = range.Columns.Count;

            for (int i = 2; i <= rows; i++)
            {
                int j = 1;
                string policyName = ((Range)range.Cells[i, j++]).Value2?.ToString();

                if (!string.IsNullOrEmpty(policyName))
                {
                    BasePolicyDetails policy = null;

                    switch (policyName)
                    {
                        case "LifeInsurance":

                            policy = new LifeInsurancePolicyDetails();
                            LifeInsurancePolicyDetails lifeInstance = (LifeInsurancePolicyDetails)policy;

                            lifeInstance.Hobbies = new List<Occupation>();

                            // Fetching all the hobbies and profession 
                            for (int k = j; k <= range.Columns.Count; k++)
                            {
                                string columnName = ((Range)range.Cells[1, k]).Value2?.ToString();

                                // Fetching profession
                                if (columnName != null && columnName.Equals(OccupationType.Profession.ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    lifeInstance.Profession = lifeInstance.occupationsList
                                    .Where(o => o.Name == ((Range)range.Cells[i, k]).Value2?.ToString()
                                    && o.OccupationType == OccupationType.Profession).FirstOrDefault();
                                }

                                if (columnName != null && columnName.Equals(OccupationType.Hobby.ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    lifeInstance.Hobbies.Add(lifeInstance.occupationsList
                                      .Where(o => o.Name == ((Range)range.Cells[i, k]).Value2?.ToString()
                                      && o.OccupationType == OccupationType.Hobby).FirstOrDefault());
                                }
                            }


                            break;
                        case "HomeInsurance":
                            policy = new HomeApartmentPolicyDetails();
                            HomeApartmentPolicyDetails homeInstance = (HomeApartmentPolicyDetails)policy;
                            homeInstance.HomeDetails = new HomeDetails();

                            // Fetching all the home details
                            for (int k = j; k <= range.Columns.Count; k++)
                            {
                                string columnName = ((Range)range.Cells[1, k]).Value2?.ToString();
                                if (columnName != null && columnName.Equals("SizeSquareMeter", StringComparison.OrdinalIgnoreCase))
                                {
                                    homeInstance.SizeSquareMeter = Int16.Parse(((Range)range.Cells[i, k]).Value2?.ToString());
                                }

                                if (columnName != null && columnName.Equals("HomeAge", StringComparison.OrdinalIgnoreCase))
                                {
                                    homeInstance.HomeAge = Int16.Parse(((Range)range.Cells[i, k]).Value2?.ToString());
                                }

                                if (columnName != null && columnName.Equals("HomeType", StringComparison.OrdinalIgnoreCase))
                                {

                                    homeInstance.HomeDetails = homeInstance.homeDetailsList
                                        .Where(home => home.HomeType.ToString() == ((Range)range.Cells[i, k]).Value2?.ToString())
                                        .FirstOrDefault();
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    // Fetching basic policy details
                    policy.FirstName = ((Range)range.Cells[i, j++]).Value2?.ToString();
                    policy.LastName = ((Range)range.Cells[i, j++]).Value2?.ToString();
                    policy.IdentityNumber = ((Range)range.Cells[i, j++]).Value2?.ToString();
                    policy.Gender = (Gender)Enum.Parse(typeof(Gender), ((Range)range.Cells[i, j++]).Value2?.ToString());
                    policy.StartDate = DateTime.FromOADate(Double.Parse(((Range)range.Cells[i, j++]).Value2?.ToString()));
                    policy.EndDate = DateTime.FromOADate(Double.Parse(((Range)range.Cells[i, j++]).Value2?.ToString()));
                    policy.Age = Byte.Parse(((Range)range.Cells[i, j++]).Value2?.ToString());
                    policy.Address = new Address()
                    {
                        Apartment = ((Range)range.Cells[i, j++]).Value2?.ToString(),
                        ApartmentNumber = ((Range)range.Cells[i, j++]).Value2?.ToString(),
                        City = ((Range)range.Cells[i, j++]).Value2?.ToString(),
                        Street = ((Range)range.Cells[i, j++]).Value2?.ToString(),
                        Floor = ((Range)range.Cells[i, j++]).Value2?.ToString()

                    };



                    policies.Add(policy);
                }
            }

            workbook.Close();
            excelApp.Quit();

            return policies;
        }

    }
}
