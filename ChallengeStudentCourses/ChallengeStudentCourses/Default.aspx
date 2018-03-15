<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeStudentCourses.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="studentCreateButton" runat="server" OnClick="studentCreateButton_Click" Text="Generate Student" />
        <br />
        <asp:Label ID="studentCountLabel" runat="server" Text="0 students"></asp:Label>
        <br />
        <br />
    
        <asp:Button ID="assignment1Button" runat="server" OnClick="assignment1Button_Click" Text="Assignment 1" />
        <br />
        <br />
        <asp:Button ID="assignment2Button" runat="server" OnClick="assignment2Button_Click" Text="Assignment 2" />
        <br />
        <br />
        <asp:Button ID="assignment3Button" runat="server" OnClick="assignment3Button_Click" Text="Assignment 3" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
