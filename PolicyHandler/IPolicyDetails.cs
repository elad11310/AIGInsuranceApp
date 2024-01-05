using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGInsuranceApp.Models
{
    public interface IPolicyDetails
    {

        string CalculatePolicy();

        void AddUIFields(Form form);

    }
}
