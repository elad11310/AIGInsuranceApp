using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGInsuranceApp.Models
{
    public class Occupation
    {


        public string Name { get; set; }
        public float Risk { get; set; }

        public OccupationType OccupationType { get; set; }


    }
}
