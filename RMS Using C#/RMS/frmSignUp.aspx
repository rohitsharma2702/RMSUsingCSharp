<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="RMS.frmSignUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                  Sign Up
                </legend>
                  <table style="width:666px">
                       <tr>
                <td colspan="2"></td>
            </tr>
                 
                      <tr>
                <td style="text-align:center">First Name</td><td class="auto-style1">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                      <tr>
                <td style="text-align:center">Last Name</td><td class="auto-style1">
                    <asp:TextBox ID="txtLastName" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                 
                      
                      <tr>
                <td style="text-align:center">Gender</td><td class="auto-style1">
                    <asp:DropDownList ID="ddlGender" runat="server">
                    </asp:DropDownList></td>
            </tr>
                      <tr>
                <td style="text-align:center">Contact Number</td><td class="auto-style1">
                    <asp:TextBox ID="txtContactNumber" runat="server" Width="236px"></asp:TextBox></td>
            </tr>                 
                      <tr>
                <td style="text-align:center">Aadhar ID</td><td class="auto-style1">
                    <asp:TextBox ID="txtAadharId" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                      <tr>
                <td style="text-align:center">Email ID</td><td class="auto-style1">
                    <asp:TextBox ID="txtEmailId" runat="server" Width="236px"></asp:TextBox></td>
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
                <td style="text-align:center">Date of Birth</td><td class="auto-style1">
                    <act:ToolkitScriptManager ID="tsm1" runat="server"></act:ToolkitScriptManager>
                    <act:CalendarExtender ID="ce1" runat="server" TargetControlID="txtDateOfBirth" Format="dd/MMM/yyyy"></act:CalendarExtender>
                    <asp:TextBox ID="txtDateOfBirth" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                      <tr>
                <td style="text-align:center">Salary</td><td class="auto-style1">
                    <asp:TextBox ID="txtSalary" runat="server" Width="236px"></asp:TextBox></td>
            </tr>
                 <tr>
                <td style="text-align:center">Address</td><td class="auto-style1">
                    <asp:TextBox ID="txtAddress" runat="server" Width="236px"></asp:TextBox></td>
            </tr>     

                                            <tr>
                <td style="text-align:center">Department</td><td class="auto-style1">
                    <asp:DropDownList ID="ddlDepartment" runat="server">
                    </asp:DropDownList></td>
            </tr>

                      <tr>
                <td colspan="2"></td>
            </tr>
                      <tr>
                <td colspan="2"></td>
            </tr>
                            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnCreate" runat="server" Text="Create Account" Width="122px" OnClick="btnCreate_Click" />
                                </td>
            </tr>
        </table>
            </fieldset>
        </div>
      
    </div>
        <link href="StyleSheet1.css" rel="stylesheet" />
        <script src="Scripts/jquery-2.2.3.js"></script>
        <script src="Scripts/SignUp.js"></script>
    </form>
</body>
</html>
