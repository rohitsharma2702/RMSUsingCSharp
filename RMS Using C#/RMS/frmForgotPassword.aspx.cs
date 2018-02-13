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
    public partial class frmForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetPassword_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spRecoverPassword", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("Username",txtUsername.Text),
                new SqlParameter("Message",SqlDbType.VarChar,50)
            };
            parameters[1].Direction = ParameterDirection.Output;
            foreach (SqlParameter parameter in parameters)
            {
                da.SelectCommand.Parameters.Add(parameter);
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            Response.Write("<script>alert('" + parameters[1].Value.ToString() + "')</script>");
        }
    }
}