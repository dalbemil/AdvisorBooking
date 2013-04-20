<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Test2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            height: 572px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        AdvisorID:<asp:Label ID="lblAdvisorID" runat="server" Text="Label"></asp:Label>
&nbsp;</p>
    <p>
        Date:
        <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        StudentID:<asp:Label ID="lblStudentID" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        1. public int[] getAdvisorIDs()
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        2. public string getAdvisorImage(int advisor_Id)<asp:DropDownList 
            ID="DropDownList2" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        3. public string getName(int advisor_Id)<asp:DropDownList ID="DropDownList3" 
            runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        4. public string getDepartment(int advisor_Id)<asp:DropDownList 
            ID="DropDownList4" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        5. public string getMonday(int advisor_Id)<asp:DropDownList ID="DropDownList5" 
            runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
        6. public string getTuesday(int advisor_Id)<asp:DropDownList ID="DropDownList6" 
            runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        <br />
        7. public string getWednesday(int advisor_Id)<asp:DropDownList 
            ID="DropDownList7" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <br />
        8. public string getThursday(int advisor_Id)<asp:DropDownList 
            ID="DropDownList8" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
        <br />
        9. public string getFriday(int advisor_Id)<asp:DropDownList ID="DropDownList9" 
            runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
        <br />
        10. public DateTime[] getSlots(int advisor_Id, string date)<asp:DropDownList 
            ID="DropDownList10" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
        <br />
        11. public DateTime[] getTaken(int advisor_Id, string date)<asp:DropDownList 
            ID="DropDownList11" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
        <br />
        12. public DateTime[] getAvailability(DateTime[] advisorAllSlots, DateTime[] 
        taken)<asp:DropDownList ID="DropDownList12" runat="server" Height="16px" 
            Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
        <br />
        13. public string[] getDaysAvailable(int id)<asp:DropDownList 
            ID="DropDownList13" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
        <br />
        14. public int getAvailableID(int advisor_Id, string date)<asp:DropDownList 
            ID="DropDownList14" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
        <br />
        15. public bool getCheck(string stID)<asp:DropDownList ID="DropDownList15" 
            runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
        <br />
        16. public string[] getAdvisor2WeekSchedule()<asp:DropDownList 
            ID="DropDownList16" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
        <br />
        17. public string[] getAdvisor2WeekSchedule(int id)<asp:DropDownList 
            ID="DropDownList17" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
        <br />
        18. public int[] getStudentIds()<asp:DropDownList ID="DropDownList18" 
            runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
        <br />
        19. public void CancelAppointment(string stID)<asp:DropDownList 
            ID="DropDownList19" runat="server" Height="16px" Width="90px">
        </asp:DropDownList>
        <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <br />
    </p>
    </form>



    </body>
</html>
