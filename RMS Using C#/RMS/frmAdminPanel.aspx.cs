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
    public partial class frmAdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDepartments();
                FillGenders();
                GetDataFromDatabase();
                ViewState["Action"] = "Insert";
                ViewState["Id"] = null;
                if (Request.QueryString["FirstName"] != null)
                {
                    Label1.Text = Request.QueryString["FirstName"] + " " + Request.QueryString["LastName"];    
                }
                GridView1.SelectRow(0);
                for (int i = 1; i <= GridView1.Rows.Count; i++)
                {
                    GridView1.SelectedRow.Cells[0].Text = i.ToString();
                    GridView1.SelectRow(i);
                }
             }
        }

        private void GetDataFromDatabase()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spSelectResources", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("Message",SqlDbType.VarChar,50)
            };
            parameters[0].Direction = ParameterDirection.Output;
            foreach (SqlParameter parameter in parameters)
            {
                da.SelectCommand.Parameters.Add(parameter);
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
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
            txtAddress.Text = "";
            ddlDepartment.SelectedIndex = 0;
            btnCancel.Text = "Insert";
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (ViewState["Action"].ToString() == "Insert")
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand("spInsertResource",con);
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
                        new SqlParameter("Password",txtFirstName.Text + "@123"),
                        new SqlParameter("DateOfBirth",txtDateOfBirth.Text),
                        new SqlParameter("Salary",100000),
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
                GetDataFromDatabase();
                con.Close();
                Clear();
            }
            else if (ViewState["Action"].ToString() == "Update")
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand("spUpdateResource", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("Id",ViewState["Id"].ToString()),
                        new SqlParameter("FirstName",txtFirstName.Text),
                        new SqlParameter("LastName",txtLastName.Text),
                        new SqlParameter("Gender",ddlGender.SelectedItem.Text),
                        new SqlParameter("ContactNumber",txtContactNumber.Text),
                        new SqlParameter("AadharId",txtAadharId.Text),
                        new SqlParameter("EmailId",txtEmailId.Text),
                        new SqlParameter("Username",txtUsername.Text),
                        new SqlParameter("Password",txtFirstName.Text + "@123"),
                        new SqlParameter("DateOfBirth",txtDateOfBirth.Text),
                        new SqlParameter("Salary",100000),
                        new SqlParameter("Address",txtAddress.Text),
                        new SqlParameter("DepartmentId",ddlDepartment.SelectedValue),
                        new SqlParameter("Message",SqlDbType.VarChar,50),
                    };
                parameters[13].Direction = ParameterDirection.Output;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('" + parameters[13].Value.ToString() + "')</script>");
                GetDataFromDatabase();
                con.Close();
                ViewState["Id"] = null;
                ViewState["Action"] = "Insert";
                btnInsert.Text = "Insert";
                Clear();
            }
        }

        protected string GetFullName(string Id)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("select FirstName,LastName from Resource where Id = " + Id, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString() + " " + ds.Tables[0].Rows[0][1].ToString();
        }

        protected string GetDepartmentName(string DepartmentId)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("select Name from Department where Id = " + DepartmentId, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insrt")
            {
                ViewState["Action"] = "Update";
                ViewState["Id"] = e.CommandArgument.ToString();
                txtFirstName.Focus();
                btnInsert.Text = "Update";
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlDataAdapter da = new SqlDataAdapter("select * from Resource where Id = " + ViewState["Id"].ToString(), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                txtFirstName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0][2].ToString();
                ddlGender.SelectedIndex = ds.Tables[0].Rows[0][3].ToString().Trim() == "Male" ? 1 : 2;
                txtContactNumber.Text = ds.Tables[0].Rows[0][4].ToString();
                txtAadharId.Text = ds.Tables[0].Rows[0][5].ToString();
                txtEmailId.Text = ds.Tables[0].Rows[0][6].ToString();
                txtUsername.Text = ds.Tables[0].Rows[0][7].ToString();
                txtDateOfBirth.Text = ds.Tables[0].Rows[0][9].ToString();
                txtDateOfBirth.Text = string.Format("{0:dd/MM/yyyy}", txtDateOfBirth.Text);
                txtAddress.Text = ds.Tables[0].Rows[0][11].ToString();
                ddlDepartment.SelectedValue = ds.Tables[0].Rows[0][12].ToString();
            }
            else if (e.CommandName == "Dlt")
            {
                ViewState["Id"] = e.CommandArgument.ToString();
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand("spDeleteResource", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("Id",ViewState["Id"].ToString()),
                    new SqlParameter("Message",SqlDbType.VarChar,50)
                };
                parameters[1].Direction = ParameterDirection.Output;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('" + parameters[1].Value.ToString() + "')</script>");
                con.Close();
                ViewState["Id"] = null;
                GetDataFromDatabase();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
             Response.Redirect("frmLogin.aspx");
        }

       
    }
}