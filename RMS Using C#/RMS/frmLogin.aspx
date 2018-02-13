<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="RMS.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 419px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div id="ProjectTitle">
            RESOURCE MANAGEMENT SYSTEM
        </div>
        <br /><br />

        <div style="width:672px; height: 153px; left:350px;position:absolute; top: 110px;">
            <fieldset>
                <legend style="font-weight:bold"> 
                  Login Panel
                </legend>
                  <table style="width:666px">
                       <tr>
                <td colspan="2"></td>
            </tr>
                     
            <tr>
                <td style="text-align:center">Username</td><td class="auto-style1">
                    <asp:TextBox ID="txtUsername" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                      <tr>
                <td style="text-align:center">Password</td><td class="auto-style1">
                    <asp:TextBox ID="txtPassword" runat="server" Width="236px" TextMode="Password"></asp:TextBox></td>
            </tr>
                      <tr>
                <td colspan="2"></td>
            </tr>
                            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="79px" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" OnClick="btnForgotPassword_Click" />
                                </td>
            </tr>
        </table>
            </fieldset>
        </div>
        

    </div>
        <link href="StyleSheet1.css" rel="stylesheet" />
        <script src="Scripts/jquery-2.2.3.js"></script>
        <script src="Scripts/JavaScript1.js"></script>
    </form>
</body>
</html>
