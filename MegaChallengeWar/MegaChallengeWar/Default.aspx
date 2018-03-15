<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeWar.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        body {
            background-color: #292929;
            color: #f9f9f9;
            font-family: Helvetica, Arial, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <br />
            Do You Want To Start A War?<br />
            <br />
            <asp:Button ID="PlayButton" runat="server" OnClick="PlayButton_Click" Text="Play 'War'" />
            <br />
            <br />
            <asp:Image ID="MilkShake" runat="server" ImageUrl="~/i-drink-your-milkshake.jpg" Visible="False" />
            <br />
            <br />
            <asp:Label ID="ResultOfGame" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="RecordButton" runat="server" OnClick="RecordButton_Click" Text="View Game Record" />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
