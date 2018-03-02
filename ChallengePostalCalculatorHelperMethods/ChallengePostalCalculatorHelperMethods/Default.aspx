<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengePostalCalculatorHelperMethods.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color: #292929;
            color: #f9f9f9;
            padding: 10px;
        }
        .heading{
            padding: 10px;
        }
        #input{
            padding: 0px 40px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="heading">Postage Calculator</h1>
        <div id="input">
            Width:&nbsp;
            <asp:TextBox ID="WidthTextBox" runat="server" AutoPostBack="True" OnTextChanged="Input_Changed"></asp:TextBox>
            <br />
            Height: <asp:TextBox ID="HeightTextBox" runat="server" AutoPostBack="True" OnTextChanged="Input_Changed"></asp:TextBox>
            <br />
            Depth:&nbsp;
            <asp:TextBox ID="DepthTextBox" runat="server" AutoPostBack="True" OnTextChanged="Input_Changed"></asp:TextBox>
            <br />
            <asp:Label ID="DepthLabel" runat="server" style="font-size: small"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:RadioButton ID="GroundRadioButton" runat="server" GroupName="ShippingMethod" OnCheckedChanged="Input_Changed" Text="Ground" AutoPostBack="True" />
            <br />
            <asp:RadioButton ID="AirRadioButton" runat="server" GroupName="ShippingMethod" OnCheckedChanged="Input_Changed" Text="Air" AutoPostBack="True" />
            <br />
            <asp:RadioButton ID="NextDayRadioButton" runat="server" GroupName="ShippingMethod" OnCheckedChanged="Input_Changed" Text="Next Day" AutoPostBack="True" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        </div>
    </form>
</body>
</html>
