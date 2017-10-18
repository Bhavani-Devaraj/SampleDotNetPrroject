using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace VehicleInsurancePremiumCalculator
{
    public partial class PolicyDetails : System.Web.UI.Page
    {

        
       
        protected void Page_Load(object sender, EventArgs e)
        {


             if (!this.IsPostBack)
            {
               InitializeGlobalvalues();
               this.btnCalcPremium.Disabled = true;
               this.btnAddDriver.Disabled = false;
              
            }


}

        //Initailaze all Global values
        private void InitializeGlobalvalues()
        {
            List<DriverDetails> DriverLists = new List<DriverDetails>();
            Session["DriverLists"] = DriverLists;
            SetDriverClaimsTableInitialRow();
        }

        //Initailaze Table whihc will diaply all the Claimdetails with Driver Names in Table after adding to Policy
        private void SetDriverClaimsTableInitialRow()
        {

            DataTable DriverClaimdt = new DataTable();
            DataRow dr = null;
            DriverClaimdt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            DriverClaimdt.Columns.Add(new DataColumn("DriverName", typeof(string)));
            DriverClaimdt.Columns.Add(new DataColumn("DriverOccupation", typeof(string)));
            DriverClaimdt.Columns.Add(new DataColumn("DriverDateOfBirth", typeof(string)));
            DriverClaimdt.Columns.Add(new DataColumn("ClaimDescription", typeof(string)));
            DriverClaimdt.Columns.Add(new DataColumn("ClaimDate", typeof(string)));
            dr = DriverClaimdt.NewRow();
            Session["DriverClaimDetails"] = DriverClaimdt;
           
        }

        //Display all the Claimdetails with Driver Names in Table after adding to Policy
        private void SetDriverClaimsTableFilledRow()
        {


            //Store the DataTable in session
            DataTable DriverClaimDetails = new DataTable();
            DriverClaimDetails = (DataTable)Session["DriverClaimDetails"];

            TableHeaderRow tRowCol = new TableHeaderRow();
            this.DriverClaimsTable.Rows.Add(tRowCol);

            TableCell tCellHeader1 = new TableCell();
            tCellHeader1.Text = "RowNumber";
            tRowCol.Cells.Add(tCellHeader1);

            TableCell tCellHeader2 = new TableCell();
            tCellHeader2.Text = "DriverName";
            tRowCol.Cells.Add(tCellHeader2);

            TableCell tCellHeader3 = new TableCell();
            tCellHeader3.Text = "ClaimDescription";
            tRowCol.Cells.Add(tCellHeader3);

            TableCell tCellHeader4 = new TableCell();
            tCellHeader4.Text = "ClaimDate";
            tRowCol.Cells.Add(tCellHeader4);

              List<DriverDetails> DriverLists = (List<DriverDetails>)Session["DriverLists"];


              for (int i = 0; i < DriverClaimDetails.Rows.Count; i++)
              {
                  TableRow tRow = new TableRow();
                  this.DriverClaimsTable.Rows.Add(tRow);

                  TableCell tCell = new TableCell();
                  tCell.Text = Convert.ToString(i + 1);
                  tRow.Cells.Add(tCell);

                  TableCell tCell1 = new TableCell();
                  tCell1.Text = DriverClaimDetails.Rows[i]["DriverName"].ToString();
                  tRow.Cells.Add(tCell1);

                  TableCell tCell2 = new TableCell();
                  tCell2.Text = DriverClaimDetails.Rows[i]["ClaimDescription"].ToString();
                  tRow.Cells.Add(tCell2);

                  TableCell tCell3 = new TableCell();
                  tCell3.Text = DriverClaimDetails.Rows[i]["ClaimDate"].ToString();
                  tRow.Cells.Add(tCell3);
              }
           
        }

        //Add newly entered Driver details to the Policy
        public void Button1_Click(object sender, EventArgs e)
        
      {
          this.btnCalcPremium.Disabled = false;
              if((Request.Form[txtPolicyStartDate.UniqueID]) == string.Empty )
                {
                    this.lblMessage.Text = "Please fill in Required Columns.";
                    return;
                }

                if((Request.Form[this.txtDateOfBirth.UniqueID]) == string.Empty )
                {
                    this.lblMessage.Text = "Please fill in Required Columns.";
                    return;
                }

                if(txtDriverName.Text == string.Empty )
                {
                    this.lblMessage.Text = "Please fill in Required Columns.";
                    return;
                }
                
       
          

            int rowcnt =0;
            DataTable Claimdt = new DataTable();
            Claimdt = (DataTable)Session["ClaimDetails"];

            List<DriverDetails> objListDriver = (List<DriverDetails>)Session["DriverLists"];

            DriverDetails obj = new DriverDetails();
          
            obj.driverName = this.txtDriverName.Text;
            obj.occupation = this.lstOccupation.Text;
            obj.dateofbirth = this.txtDateOfBirth.Text;

            obj.claimcount = Gridview2.Rows.Count;

            DataTable DriverClaimDetails = new DataTable();
            DriverClaimDetails = (DataTable)Session["DriverClaimDetails"];

            if (Gridview2.Rows.Count > 0 )
            {
                for (rowcnt = 0; rowcnt < Gridview2.Rows.Count; rowcnt++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview2.Rows[rowcnt].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview2.Rows[rowcnt].Cells[2].FindControl("TextBox2");


                    obj.claimlist.Add(new ClaimDetails { rownumber = rowcnt + 1, claimdescription = box1.Text.ToString(), claimDate = Convert.ToDateTime(box2.Text) });

                    DataRow dr = null;
                    dr = DriverClaimDetails.NewRow();
                    dr["RowNumber"] = DriverClaimDetails.Rows.Count;
                    dr["DriverName"] = this.txtDriverName.Text;
                    dr["DriverOccupation"] = this.lstOccupation.Text;
                    dr["DriverDateOfBirth"] = this.txtDateOfBirth.Text;
                    dr["ClaimDescription"] = box1.Text;
                    dr["ClaimDate"] = box2.Text;
                    DriverClaimDetails.Rows.Add(dr);
                    
                  }
            }
            else
            {
                DataRow dr = null;
                dr = DriverClaimDetails.NewRow();
                dr["RowNumber"] = DriverClaimDetails.Rows.Count;
                dr["DriverName"] = this.txtDriverName.Text;
                dr["DriverOccupation"] = this.lstOccupation.Text;
                dr["DriverDateOfBirth"] = this.txtDateOfBirth.Text;
                dr["ClaimDescription"] =String.Empty;
                dr["ClaimDate"] = String.Empty;
                DriverClaimDetails.Rows.Add(dr);
            }
    

          
         
            //Store the DataTable in session
            Session["DriverClaimDetails"] = DriverClaimDetails;
            

    //Method to display Driver with Claim Details as Table data
            SetDriverClaimsTableFilledRow();



            objListDriver.Add(obj);
            Session["DriverLists"] = objListDriver;


               //Reset Driver Details
            this.txtDriverName.Text = null;
            this.txtDateOfBirth.Text =null;

            if (Claimdt != null)
            {
                for (int i = Claimdt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = Claimdt.Rows[i];
                    Claimdt.Rows.Remove(dr);

                }
            }
           
            Gridview2.DataSource = Claimdt;
            Gridview2.DataBind();
            this.Gridview2.Visible = false;


            if (objListDriver.Count == 5)
            {
                this.lblMessage.Text = "Insurance can have Maximun 5 Drivers only.";
                this.btnAddDriver.Disabled = true;
                this.btnAddClaims.Disabled = true;
                return;
            }
           
         }

        //enable Gridview to enter Claims details
        public void ClaimButton_Click(object sender, EventArgs e)
        {

    DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ClaimDescription", typeof(string)));
            dt.Columns.Add(new DataColumn("ClaimDate", typeof(string)));
           
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["ClaimDescription"] = string.Empty;
            dr["ClaimDate"] = string.Empty;
            dt.Rows.Add(dr);

        //Store the DataTable in ViewState
            Session["ClaimDetails"] = dt;

            if (Session["TotalClaimDetails"] == null)
            {
                Session["TotalClaimDetails"] = dt;
            }

            Gridview2.DataSource = dt;
            Gridview2.DataBind();
            this.Gridview2.Visible = true;


            //Method to display Driver with Claim Details as Table data
            SetDriverClaimsTableFilledRow();

            }

        //When Cliams gridview created event
        protected void Gridview2_RowCreated(object sender, GridViewRowEventArgs e)

        {

            if (e.Row.RowType == DataControlRowType.DataRow)

            {

                DataTable dt = (DataTable)Session["ClaimDetails"];


                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");

                if (lb != null)

                {

                    if (dt.Rows.Count > 1)

                    {

                        if (e.Row.RowIndex == dt.Rows.Count - 1)

                        {

                            lb.Visible = false;

                        }

                    }

                    else

                    {

                        lb.Visible = false;

                    }

                }

            }

        }

        //Calls to Add New row inside Grid
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            int TotClaimsAdded = 0;

            DataTable DriverClaimDetails = (DataTable)Session["DriverClaimDetails"];

            if ( DriverClaimDetails.Rows.Count >0)
            {

                for (int rowcnt = 0; rowcnt < DriverClaimDetails.Rows.Count; rowcnt++)
                {
                    if (DriverClaimDetails.Rows[rowcnt]["ClaimDescription"].ToString() != String.Empty)
                    {
                        TotClaimsAdded = TotClaimsAdded + 1;
                    }
                }

                TotClaimsAdded = TotClaimsAdded + Gridview2.Rows.Count;
            
            }
           
            if (TotClaimsAdded == 5)
            {
                lblMessage.Text = "Only Maximum 5 Claims can be added this Policy";
                SetDriverClaimsTableFilledRow();
                return;
            }

            AddNewRowToGrid();
            //Method to display Driver with Claim Details as Table data
            SetDriverClaimsTableFilledRow();

            //Check if Total count of Claims for this policy reached its limit for this Policy

        }

        //Add New Rows to fill Claims
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (Session["ClaimDetails"] != null)
            {
                DataTable dtClaimDetails = (DataTable)Session["ClaimDetails"];
                DataRow drCurrentRow = null;
              
                if (dtClaimDetails.Rows.Count > 0 && dtClaimDetails.Rows.Count < 5 )
                {
                    for (int i = 1; i <= dtClaimDetails.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                       
                        drCurrentRow = dtClaimDetails.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtClaimDetails.Rows[i - 1]["ClaimDescription"] = box1.Text;
                        dtClaimDetails.Rows[i - 1]["ClaimDate"] = box2.Text;
                     
                        rowIndex++;
                    }
                    dtClaimDetails.Rows.Add(drCurrentRow);
                    Session["ClaimDetails"] = dtClaimDetails;

                    Gridview2.DataSource = dtClaimDetails;
                    Gridview2.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        //Set back to previosuly entered data in grid
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (Session["ClaimDetails"] != null)
            {
                DataTable dt = (DataTable)Session["ClaimDetails"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                       
                        box1.Text = dt.Rows[i]["ClaimDescription"].ToString();
                        box2.Text = dt.Rows[i]["ClaimDate"].ToString();
                       
                        rowIndex++;
                    }
                }
            }
        }

        //Function to Remove rows form Grid
        protected void LinkButton1_Click(object sender, EventArgs e)

        {

            LinkButton lb = (LinkButton)sender;

            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            int rowID = gvRow.RowIndex + 1;

            if (Session["ClaimDetails"] != null)

            {

                DataTable dt = (DataTable)Session["ClaimDetails"];

                if (dt.Rows.Count > 1)

                {

                    if (gvRow.RowIndex < dt.Rows.Count - 1)

                    {

                        //Remove the Selected Row data

                        dt.Rows.Remove(dt.Rows[rowID]);

                    }

                }

                //Store the current data in ViewState for future reference

                Session["ClaimDetails"] = dt;

                //Re bind the GridView for the updated data

                Gridview2.DataSource = dt;

                Gridview2.DataBind();

                SetDriverClaimsTableFilledRow();


            }



            //Set Previous Data on Postbacks

            SetPreviousData();

        }

        protected void Gridview2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public double FnPremuimCalculator(double PremuimAmt,double PercVal)
        {
            double calculatedAmt;

            calculatedAmt = (PremuimAmt / 100) * PercVal;
            return calculatedAmt;
         }

    //Calculate Premium Policy
        public void btnCalcPremium_Click(object sender, EventArgs e)
        {
            
            double InitialPremiumAmount = 500;
            double CurrentPremiumAmount = 0;
            int DriverAgeAtPolicyStartDate = 0;
            int ClaimsAgeAtPolicyStartDate = 0;
            double PercVal = 10;
            string DriverOccupation = "";
            DateTime DriverDOB = new DateTime();
            DateTime ClaimDate;
            DateTime PolicyStartDate;
            String polictdate = txtPolicyStartDate.Text;
            TxtPolicyStartDatehidden.Text = txtPolicyStartDate.Text.ToString();
            PolicyStartDate = Convert.ToDateTime(TxtPolicyStartDatehidden.Text);

            CurrentPremiumAmount = InitialPremiumAmount;

          // Loop thru Driver details to calaculate Premuim Amount based on Occupation
              List<DriverDetails> DriverLists = (List<DriverDetails>)Session["DriverLists"];

                      for (int i = 0; i < DriverLists.Count; i++)
            {
                DriverOccupation = DriverLists[i].occupation.ToString();
                //DriverDOB = Convert.ToDateTime(DriverLists[i].dateofbirth.ToString());
                if (DriverOccupation == "Accountant") //Decrease the Premium Amount by 10%
                {
                    PercVal = 10;
                    CurrentPremiumAmount = CurrentPremiumAmount - FnPremuimCalculator(CurrentPremiumAmount, PercVal);
                }
                if (DriverOccupation == "Chauffeur") //Increase the Premium Amount by 10%
                {
                    PercVal = 10;
                    CurrentPremiumAmount = CurrentPremiumAmount + FnPremuimCalculator(CurrentPremiumAmount, PercVal);
                }
            }

            // Loop thru Driver details to calaculate Premuim Amount based on Driver Age at Start of Policy
            for (int i = 0; i < DriverLists.Count; i++)
            {
             
                TxtDOBhidden.Text = Convert.ToString(DriverLists[i].dateofbirth);
                DriverDOB = Convert.ToDateTime(TxtPolicyStartDatehidden.Text);

          
                DriverAgeAtPolicyStartDate = ((PolicyStartDate.Date - DriverDOB.Date).Days)/365;

                if (DriverAgeAtPolicyStartDate >= 21 && DriverAgeAtPolicyStartDate <= 25) //Increase the premium by 20% when Driver Age is between 21-25 at Policy Start Date
                {
                    PercVal = 20;
                    CurrentPremiumAmount = CurrentPremiumAmount + FnPremuimCalculator(CurrentPremiumAmount, PercVal);
                }
                if (DriverAgeAtPolicyStartDate >= 26 && DriverAgeAtPolicyStartDate <= 75) //Decrease the premium by 10% when Driver Age is between 21-25 at Policy Start Date
                {
                    PercVal = 10;
                    CurrentPremiumAmount = CurrentPremiumAmount - FnPremuimCalculator(CurrentPremiumAmount, PercVal);
                }
            }


           DataTable DriverClaimDetails = new DataTable();
           DriverClaimDetails = (DataTable)Session["DriverClaimDetails"];

            //Calculate Premuim Amount based on Driver Claims
            for (int rowcnt = 0; rowcnt < DriverClaimDetails.Rows.Count; rowcnt++)
            {
                if (DriverClaimDetails.Rows[rowcnt]["ClaimDate"].ToString() != String.Empty)
                {
                    ClaimDate = Convert.ToDateTime(DriverClaimDetails.Rows[rowcnt]["ClaimDate"].ToString());
                    ClaimsAgeAtPolicyStartDate = ((PolicyStartDate.Date - ClaimDate.Date).Days) / 365;

                    if (ClaimsAgeAtPolicyStartDate <= 1) //Increase the Premium Amount by 20% if Claim Date is Less than a Year
                    {
                        PercVal = 20;
                        CurrentPremiumAmount = CurrentPremiumAmount + FnPremuimCalculator(CurrentPremiumAmount, PercVal);
                    }
                    if (ClaimsAgeAtPolicyStartDate >= 2 && ClaimsAgeAtPolicyStartDate <= 5) //Increase the Premium Amount by 10%
                    {
                        PercVal = 10;
                        CurrentPremiumAmount = CurrentPremiumAmount + FnPremuimCalculator(CurrentPremiumAmount, PercVal);
                    }

                }
            
             
            }

            //Method to display Driver with Claim Details as Table data
            SetDriverClaimsTableFilledRow();

            this.lblPremiumAmount.Text = "Premium Amount for this Policy is: " + CurrentPremiumAmount;


        }

        //Reset Policy
        public void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("PolicyDetails");
        }
    }
}