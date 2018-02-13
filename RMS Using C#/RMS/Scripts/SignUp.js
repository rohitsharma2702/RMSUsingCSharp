/// <reference path="jquery-2.2.3.js" />


$(document).ready(function () {

    var firstName = $('#txtFirstName');
    var lastName = $('#txtLastName');
    var contactNumber = $('#txtContactNumber');
    var aadharId = $('#txtAadharId');
    var emailId = $('#txtEmailId');
    var username = $('#txtUsername');
    var password = $('#txtPassword');
    var dateOfBirth = $('#txtDateOfBirth');
    var salary = $('#txtSalary');
    var address = $('#txtAddress');

    var create = $('#btnCreate');

    create.click(function () {
        if (firstName.val() == '') {
            alert('Please Enter FirstName...');
            return false;
        }
        else if (lastName.val() == '') {
            alert('Please Enter LastName...');
            return false;
        }
        else if ($('#ddlGender option:selected').val() == '') {
            alert('Please Select Gender...');
            return false;
        }
        else if (contactNumber.val() == '') {
            alert('Please Enter Contact Number...');
            return false;
        }
        else if (aadharId.val() == '') {
            alert('Please Enter Aadhar-Id...');
            return false;
        }
        else if (emailId.val() == '') {
            alert('Please Enter Email-Id...');
            return false;
        }
        else if (username.val() == '') {
            alert('Please Enter Username...');
            return false;
        }
        else if (password.val() == '') {
            alert('Please Enter Password...');
            return false;
        }
        else if (dateOfBirth.val() == '') {
            alert('Please Enter Date of Birth...');
            return false;
        }
        else if (salary.val() == '') {
            alert('Please Enter Salary...');
            return false;
        }
        else if (address.val() == '') {
            alert('Please Enter Address...');
            return false;
        }
        else if ($('#ddlDepartment option:selected').val() == '') {
            alert('Please Select Department...');
            return false;
        }
        return true;
    });


});

