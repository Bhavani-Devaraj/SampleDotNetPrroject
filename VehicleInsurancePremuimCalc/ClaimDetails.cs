using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsurancePremiumCalculator
{
    public class ClaimDetails

    {

        private int RowNumber ;
        private string ClaimDescription;
        private DateTime ClaimDate;


            public int rownumber
            {
                get{ return RowNumber;}
                set { RowNumber = value;}
            }

        public string claimdescription
        {
            get{ return ClaimDescription;}
            set { ClaimDescription = value;}
        }


        public DateTime claimDate

            {
                get { return ClaimDate; }
                set { ClaimDate = value; }
            }
    
    }



}
