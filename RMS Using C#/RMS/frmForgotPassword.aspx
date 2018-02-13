<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmForgotPassword.aspx.cs" Inherits="RMS.frmForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div id="ForgotPasswordTitle">
            GET YOUR PASSWORD RECOVERED
        </div>
        <br /><br />

        <div style="width:672px; height: 153px; left:350px;position:absolute; top: 110px;">
            <fieldset>
                <legend style="font-weight:bold"> 
                  Password Recovery Panel
                </legend>
                  <table style="width:666px">
                       <tr>
                <td colspan="2"></td>
            </tr>
                     
            <tr>
                <td style="text-align:center">Please Enter Your Username</td><td class="auto-style1">
                    <asp:TextBox ID="txtUsername" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                      <tr>
                <td colspan="2"></td>
            </tr>
                      <tr>
                <td colspan="2"></td>
            </tr>
                            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnGetPassword" runat="server" Text="Get Your Password" Width="138px" OnClick="btnGetPassword_Click" />
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
