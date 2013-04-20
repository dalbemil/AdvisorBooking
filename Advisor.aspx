<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMasterPage.master"
    AutoEventWireup="true" CodeFile="Advisor.aspx.cs" Inherits="Default2" %>

<script language="C#" runat="server">
    void cmd(Object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server" style="height: 318px">

            <center>
                <h2 style="color: #99FF99">
                    <span style="color: #009933">Book An Advisor</span>
                </h2>
            </center>

> <div style="width:800px; margin:0 auto;">
     <asp:Table ID="myTable" runat="server" Width="820px" ForeColor="#FFCC99" Font-Size="Smaller"
            HorizontalAlign="Left" Style="border-collapse: collapse; display:block">
            <asp:TableRow ID="myTR" runat="server" Width="720px" BackColor="#6E6E6E" ForeColor="White"
                BorderWidth="0">
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Text="Department" Style="text-align: center"
                        Width="100px" Font-Size="Small" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDay1" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblDate1" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDay2" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblDate2" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDay3" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblDate3" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDay4" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblDate4" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDay5" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="lblDate5" runat="server" Text="Label" Style="text-align: center" Width="100px"
                        Font-Size="Small"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table></div>
        <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    
    </form>
  
</asp:Content>

