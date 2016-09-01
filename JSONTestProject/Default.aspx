<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Male Gender</h2>
    <asp:Literal ID="ltMale" runat="server"></asp:Literal>
    </div>
    
    <br /><br /><br />
    <div>
        <h2>Female Gender</h2>
    <asp:Literal ID="ltFemale" runat="server"></asp:Literal>
    </div>
    
        <br /><br /><br />
    <div>
        <h2>Unknown Gender</h2>
    <asp:Literal ID="ltUnknown" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
