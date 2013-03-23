<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Advisor.aspx.cs" Inherits="Default2" %>


<script language="C#" runat="server">
    void cmd(Object sender, EventArgs e) 
    {
        
    }
    </script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" style="height: 318px">

    <div class="post" id="post-5">
    <div class="post-title">
        
            <center>
                <h2>
                    Book An Advisor
                </h2>   
              
                
            </center>
        </div>



                     <div align="right">
                       
                                 <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="128px" 
                                     AutoPostBack="True">
                                 </asp:DropDownList>
                         
                              &nbsp;    &nbsp;    &nbsp;    &nbsp;

                              </div>


                    <br />
<br />
        <asp:Table ID="myTable" runat="server" Width="720px" 
  ForeColor="#FFCC99" Font-Size="Smaller" HorizontalAlign="Left" style="border-collapse:collapse;"> 
    <asp:TableRow ID="myTR" runat="server" Width="720px"  BackColor="#6E6E6E" ForeColor="White" BorderWidth="0">
       
        		<asp:TableCell></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label11" runat="server" Text="Department" style="text-align:center" Width="100px"  Font-Size="Small" Font-Bold="True"></asp:Label> </asp:TableCell>
		<asp:TableCell><asp:Label ID="Label1" runat="server" Text="Label" style="text-align:center" Width="100px"  Font-Size="Small" Font-Bold="True"></asp:Label> <br />     <asp:Label ID="Label6" runat="server" Text="Label" style="text-align:center" Width="100px"  Font-Size="Small"></asp:Label>     </asp:TableCell>
		<asp:TableCell><asp:Label ID="Label2" runat="server" Text="Label" style="text-align:center" Width="100px"  Font-Size="Small" Font-Bold="True"></asp:Label> <br />     <asp:Label ID="Label7" runat="server" Text="Label" style="text-align:center" Width="100px"   Font-Size="Small"></asp:Label>     </asp:TableCell>
		<asp:TableCell><asp:Label ID="Label3" runat="server" Text="Label" style="text-align:center" Width="100px"   Font-Size="Small" Font-Bold="True"></asp:Label> <br />     <asp:Label ID="Label8" runat="server" Text="Label" style="text-align:center" Width="100px"  Font-Size="Small"></asp:Label>     </asp:TableCell>
		<asp:TableCell><asp:Label ID="Label4" runat="server" Text="Label" style="text-align:center" Width="100px"  Font-Size="Small" Font-Bold="True"></asp:Label> <br />     <asp:Label ID="Label9" runat="server" Text="Label" style="text-align:center" Width="100px"   Font-Size="Small"></asp:Label>     </asp:TableCell>
		<asp:TableCell><asp:Label ID="Label5" runat="server" Text="Label" style="text-align:center" Width="100px"  Font-Size="Small" Font-Bold="True"></asp:Label> <br />     <asp:Label ID="Label10" runat="server" Text="Label" style="text-align:center" Width="100px"   Font-Size="Small"></asp:Label>     </asp:TableCell>	
    </asp:TableRow>
</asp:Table>  

</div>



    </form>
</asp:Content>

