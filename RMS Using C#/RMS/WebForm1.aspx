<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RMS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
        
        <script src="Scripts/jquery-2.2.3.js"></script>
        <script>
            $(document).ready(function () {

                $('#Button1').click(function () {
                    if ($('#DropDownList1 option:selected').val() == '') {
                        alert('Please Select');
                        return false;
                    }
                    alert('Index = ' + $('#DropDownList1 option:selected').index());
                    alert('Value = ' + $('#DropDownList1 option:selected').val());
                    alert('Text = ' + $('#DropDownList1 option:selected').text());
                    alert('Form Submitted');
                    return true;
                });

            });
        </script>

    </form>
</body>
</html>
