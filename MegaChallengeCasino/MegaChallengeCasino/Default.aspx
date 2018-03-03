<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            font-weight: 700;
        }
        body {
            background-color: #272727;
            color: #f9f9f9;
            padding: 30px;
        }
        #Icons {
            padding: 40px 0px 20px 0px;
        }
        #Game {
            margin: 20px;
        }
        #Rules {
            padding: 20px 16px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center" id="Icons">
            <asp:Image ID="IconImage1" runat="server" Height="200px" />
            <asp:Image ID="IconImage2" runat="server" Height="200px" />
            <asp:Image ID="IconImage3" runat="server" Height="200px" />
        </div>
        <div style="text-align: center" id="Game">

            <span class="auto-style1">Your Bet:</span>
            <asp:TextBox ID="BetTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LeverButton" runat="server" Text="Pull The Lever!" OnClick="LeverButton_Click" />
            <br />
            <asp:Button ID="RestartButton" runat="server" OnClick="RestartButton_Click" Text="Lose All Your Money Again?!" />
            <br />
            <asp:Label ID="ErrorTextLabel" runat="server" CssClass="auto-style1" ForeColor="#CC0000"></asp:Label>
            <br class="auto-style1" />
            <asp:Label ID="BetResultLabel" runat="server" CssClass="auto-style1"></asp:Label>
            <br class="auto-style1" />
            <br class="auto-style1" />
            <span class="auto-style1">Player&#39;s Money:
            </span>
            <asp:Label ID="MoneyBalanceLabel" runat="server" CssClass="auto-style1"></asp:Label>

        </div>
        <div id="Rules">

            <br />
            Rules:<br />
            <br />
            1 Cherry&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x2 Your Bet<br />
            2 Cherries&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x3 Your Bet<br />
            3 Cherries&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x4 Your Bet<br />
            All 7&#39;s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x100 Your Bet<br />
            <br />
            However...<br />
            Any Bar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lose Entire Bet</div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
