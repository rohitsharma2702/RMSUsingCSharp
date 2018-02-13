<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdminPanel.aspx.cs" Inherits="RMS.frmAdminPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            
            <div id="AdminTitle">
                WELCOME&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <div style="text-align: right">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
                </div>
            </div>

            <div style="width: 672px; height: 153px; left: 250px; position: absolute; top: 70px;">
                <fieldset>
                    <legend style="font-weight: bold">Admin Panel
                    </legend>
                    <table style="width: 834px">

                        <tr>
                            <td colspan="4"></td>
                        </tr>

                        <tr>
                            <td style="text-align: center">First Name</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="217px"></asp:TextBox></td>
                            <td style="text-align: center">Last Name</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtLastName" runat="server" Width="236px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="text-align: center">Gender</td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="ddlGender" runat="server" Height="20px" Width="157px">
                                </asp:DropDownList></td>
                            <td style="text-align: center">Contact Number</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtContactNumber" runat="server" Width="237px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="text-align: center">AADHAR ID</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtAadharId" runat="server" Width="220px"></asp:TextBox></td>
                            <td style="text-align: center">Email ID</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtEmailId" runat="server" Width="236px"></asp:TextBox></td>
                        </tr>
                        <act:ToolkitScriptManager ID="tsm1" runat="server"></act:ToolkitScriptManager>
            <act:CalendarExtender ID="ce1" runat="server" TargetControlID="txtDateOfBirth" Format="dd/MMM/yyyy"></act:CalendarExtender>            
                        <tr>
                            <td style="text-align: center">Username</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtUsername" runat="server" Width="220px"></asp:TextBox></td>
                            <td style="text-align: center">Date of Birth</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtDateOfBirth" runat="server" Width="236px"></asp:TextBox></td>
                        </tr>
                        
                        <tr>
                            <td style="text-align: center">Address</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtAddress" runat="server" Width="220px"></asp:TextBox></td>
                            <td style="text-align: center">Department</td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="ddlDepartment" runat="server" Height="20px" Width="216px"></asp:DropDownList></td>
                        </tr>

                        <tr>
                            <td colspan="4"></td>
                        </tr>

                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="79px" OnClick="btnInsert_Click" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>

            <div style="top:395px;position:absolute;left:150px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbFullName" runat="server" CommandName="Insrt" CommandArgument='<%# Eval("Id") %>'>
                              <%# GetFullName(Eval("Id").ToString()) %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                    <asp:BoundField DataField="AadharId" HeaderText="AADHAR ID" />
                    <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="lblDepartment" runat="server" CommandArgument='<%# Eval("DepartmentId") %>'>
                                <%# GetDepartmentName(Eval("DepartmentId").ToString()) %>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDeleteResource" runat="server" OnClientClick="return confirm('Are You Sure You Want To Delete The Resource ?')" CommandName="Dlt" CommandArgument='<%# Eval("Id") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
              </asp:GridView></div>
        </div>

        <link href="StyleSheet1.css" rel="stylesheet" />
        <script src="Scripts/jquery-2.2.3.js"></script>
        <script src="Scripts/JavaScript1.js"></script>
        <script src="Scripts/AdminPanel.js"></script>

    </form>
</body>
</html>
