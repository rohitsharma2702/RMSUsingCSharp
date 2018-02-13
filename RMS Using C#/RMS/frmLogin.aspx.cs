using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RMS
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spLogin",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("Username",txtUsername.Text),
                new SqlParameter("Password",txtPassword.Text),
                new SqlParameter("Message",SqlDbType.VarChar,50)
            };
            parameters[2].Direction = ParameterDirection.Output;
            foreach (SqlParameter parameter in parameters)
            {
                da.SelectCommand.Parameters.Add(parameter);
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0)
            {
                CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                con = new SqlConnection(CS);
                da = new SqlDataAdapter("select FirstName,LastName from Resource where Username = '" + txtUsername.Text + "'", con);
                ds = new DataSet();
                da.Fill(ds);
                Response.Redirect("frmAdminPanel.aspx?FirstName=" + ds.Tables[0].Rows[0][0].ToString() + "&LastName=" + ds.Tables[0].Rows[0][1].ToString());
            }
            else 
            {
                Response.Write("<script>alert('" + parameters[2].Value.ToString() + "')</script>");
            }
            
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmForgotPassword.aspx");
        }
    }
}