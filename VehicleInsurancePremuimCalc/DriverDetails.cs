using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace VehicleInsurancePremiumCalculator

{
	public class DriverDetails
	{
	

        private string DriverName;
        private string Occupation ;
        private string DateOfBirth;
        private int ClaimCount;
        public List<ClaimDetails> claimlist = new List<ClaimDetails>();

       

        public string driverName
        {
            get { return DriverName; }
            set { DriverName = value; }
        }

        public string occupation
        {
            get { return Occupation; }
            set { Occupation = value; }
        }
        public string dateofbirth
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }


 public int claimcount
        {
            get { return ClaimCount; }
            set { ClaimCount = value; }
        }
    }
}
