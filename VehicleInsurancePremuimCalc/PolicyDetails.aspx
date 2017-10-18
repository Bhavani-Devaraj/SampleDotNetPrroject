<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyDetails.aspx.cs" Inherits="VehicleInsurancePremiumCalculator.PolicyDetails" %>

<!DOCTYPE html>
<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.16/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.16/themes/humanity/jquery-ui.css"
        rel="stylesheet" type="text/css"/>
<script type="text/javascript">
    $(document).ready(function () {
        $("#txtPolicyStartDate").datepicker({
            defaultDate: "-1y",
            dateFormat: "dd-mm-yy",
            buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif',
            yearRange: "c-80:c+40",
            inline: true,
            showAnim: 'fadeIn',
            changeMonth: true,
            changeYear: true,
            minDate: "-120y",
            maxDate: "-1d",
           
        });

        $("#txtDateOfBirth").datepicker({
            defaultDate: "-1y",
            dateFormat: "dd-mm-yy",
            buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif',
            yearRange: "c-80:c+40",
            inline: true,
            showAnim: 'fadeIn',
            changeMonth: true,
            changeYear: true,
            minDate: "-120y",
            maxDate:"-21y",
        });

       
    });
</script>
<script type= "text/javascript">
 function validate()
            {
            if ((document.getElementById("<%=txtPolicyStartDate.ClientID%>").value).length == 0) 
                {
                alert('Policy Start Date should not be empty...');
                document.getElementById("<%=txtPolicyStartDate.ClientID%>").focus();
            return false;
            }

     if ((document.getElementById("<%=txtDateOfBirth.ClientID%>").value).length == 0) {
         alert('DOB should not be empty...');
         document.getElementById("<%=txtDateOfBirth.ClientID%>").focus();
         return false;
     }
            }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 505px" id="divPremiumAmount">
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 30px; top: 33px; position: absolute; width: 111px; height: 18px" Text="Policy Start Date"></asp:Label>
            <asp:TextBox ID="txtPolicyStartDate" runat="server" style="z-index: 1; left: 135px; top: 15px; position: relative; width: 146px" ></asp:TextBox>
&nbsp;
             <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 20px; top: 81px; position: absolute; width: 119px" Text="Driver Details" BackColor="#003399"></asp:Label>
             <button type="button" name="ButtonClaims" runat="server" onserverclick="ClaimButton_Click" style="z-index: 1; left: 431px; top: 144px; position: absolute; width: 134px;" id="btnAddClaims" > Add Claims</button>
           

       
            <asp:Label ID="lblMessage" runat="server" style="z-index: 1; left: 11px; top: 294px; position: absolute; width: 407px" Text="Message: " Font-Bold="True" ForeColor="#CC0000"></asp:Label>
           
            <asp:Label ID="lblPremiumAmount" runat="server" style="z-index: 1; left: 11px; top: 212px; position: absolute; width: 407px" Text="Premium Amount : 500" Font-Bold="True" ForeColor="#33CC33"></asp:Label>
          
            <asp:Table ID="DriverClaimsTable" runat="server" style="position: relative; top: 286px; left: 0px; width: 401px; height: 49px" BackColor="#6699FF" BorderColor="#3333CC" BorderStyle="Groove" Font-Names="Arial" GridLines="Horizontal">
            </asp:Table>
           

            <asp:gridview ID="Gridview2" runat="server" ShowFooter="True"

            AutoGenerateColumns="False" onrowcreated="Gridview2_RowCreated" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="Gridview2_SelectedIndexChanged" style="margin-top: 248px; position: relative; top: -160px; left: 423px;" Height="112px" Width="401px">

            <Columns>

            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

            <asp:TemplateField HeaderText="ClaimDescription">

                <ItemTemplate>

                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                </ItemTemplate>

            </asp:TemplateField>

           <asp:TemplateField HeaderText="ClaimDate">

                <ItemTemplate>

                     <asp:TextBox ID="TextBox2" runat="server"  ></asp:TextBox>
                     
                </ItemTemplate>

                <FooterStyle HorizontalAlign="Right" />

                <FooterTemplate>

                 <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row"

                        onclick="ButtonAdd_Click" />

                </FooterTemplate>

            </asp:TemplateField>

                 <asp:TemplateField>

                <ItemTemplate>

                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Remove</asp:LinkButton>

                </ItemTemplate>

            </asp:TemplateField>

            </Columns>

                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />

        </asp:gridview>


       
            <button type="button" name="Button1" runat="server"  onserverclick="Button1_Click" style="z-index: 1; left: 10px; top: 251px; position: absolute; width: 170px;" id="btnAddDriver" > Add Driver Details to Policy</button>
            <asp:TextBox ID="txtDateOfBirth" runat="server"  style="z-index: 1; left: 431px; top: 102px; position: absolute; width: 133px" TabIndex="3" ></asp:TextBox>
&nbsp;
            <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 389px; top: 104px; position: absolute" Text="DOB"></asp:Label>
            <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 20px; top: 144px; position: absolute; width: 82px" Text="Occupation"></asp:Label>
            <asp:ListBox ID="lstOccupation" runat="server" style="z-index: 1; left: 107px; top: 135px; position: absolute; width: 119px" TabIndex="4">
                <asp:ListItem Selected="True">Chauffeur</asp:ListItem>
                <asp:ListItem>Accountant</asp:ListItem>
            </asp:ListBox>
            <asp:TextBox ID="txtDriverName" runat="server"  style="z-index: 1; left: 105px; top: 106px; position: absolute; width: 248px; right: 595px;" TabIndex="1"></asp:TextBox>
           <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 26px; top: 107px; position: absolute; height: 19px" Text="Name"></asp:Label>
           <button type="button" name="btnCalcPremium" runat="server"  onserverclick="btnCalcPremium_Click" style="z-index: 1; left: 190px; top: 251px; position: absolute; width: 120px;" id="btnCalcPremium" >Calculate Premuim</button>
           <button type="button" name="btnReset" runat="server"  onserverclick="btnReset_Click" style="z-index: 1; left: 320px; top: 251px; position: absolute; width: 60px;" id="Button1" >Reset</button>
                          <asp:TextBox ID="TxtPolicyStartDatehidden" visible="false" runat="server" style="z-index: 1; left: 135px; top: 435px; position: relative; width: 146px" ></asp:TextBox>
&nbsp;
            <asp:TextBox ID="TxtDOBhidden" visible="false" runat="server" style="z-index: 1; left: 235px; top: 435px; position: relative; width: 146px" ></asp:TextBox>
&nbsp;
              </div>
    </form>
</body>
</html>
