<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PdfResponse.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button runat="server" ID="btnCallDelegate" Text="Call Delegate" OnClick="btnCallDelegate_Click"/>
        <br />
        Result: <asp:Label runat="server" ID="lblResult"></asp:Label>
    </div>
    </form>
</body>
</html>
