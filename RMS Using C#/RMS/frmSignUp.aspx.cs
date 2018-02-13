using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RMS
{
    public partial class frmSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDepartments();
                FillGenders();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("spInsertResource", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("FirstName",txtFirstName.Text),
                        new SqlParameter("LastName",txtLastName.Text),
                        new SqlParameter("Gender",ddlGender.SelectedItem.Text),
                        new SqlParameter("ContactNumber",txtContactNumber.Text),
                        new SqlParameter("AadharId",txtAadharId.Text),
                        new SqlParameter("EmailId",txtEmailId.Text),
                        new SqlParameter("Username",txtUsername.Text),
                        new SqlParameter("Password",txtPassword.Text),
                        new SqlParameter("DateOfBirth",txtDateOfBirth.Text),
                        new SqlParameter("Salary",txtSalary.Text),
                        new SqlParameter("Address",txtAddress.Text),
                        new SqlParameter("DepartmentId",ddlDepartment.SelectedValue),
                        new SqlParameter("Message",SqlDbType.VarChar,50),
                    };
            parameters[12].Direction = ParameterDirection.Output;
            foreach (SqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('" + parameters[12].Value.ToString() + "')</script>");
            con.Close();
            Clear();
        }

        protected void FillGenders()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("select Id,Type from Gender", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlGender.DataSource = ds.Tables[0];
            ddlGender.DataTextField = "Type";
            ddlGender.DataValueField = "Id";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("Please Select Gender", ""));
        }

        protected void FillDepartments()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("select Id,Name from Department", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlDepartment.DataSource = ds.Tables[0];
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataValueField = "Id";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Please Select Department", ""));
        }



        private void Clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlGender.SelectedIndex = 0;
            txtContactNumber.Text = "";
            txtAadharId.Text = "";
            txtEmailId.Text = "";
            txtUsername.Text = "";
            txtDateOfBirth.Text = "";
            txtSalary.Text = "";
            txtAddress.Text = "";
            ddlDepartment.SelectedIndex = 0;
        }


    }
}