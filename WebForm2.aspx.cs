using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDropDownListExample
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlContinents.AppendDataBoundItems = true;
                String strConnString = ConfigurationManager.ConnectionStrings["baglan"].ConnectionString;
                String strQuery = "select ContinentID, ContinentName from Continent";
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlContinents.DataSource = cmd.ExecuteReader();
                    ddlContinents.DataTextField = "ContinentName";
                    ddlContinents.DataValueField = "ContinentID";
                    ddlContinents.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        protected void ddlContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem("--Select Country--", ""));
            ddlCity.Items.Clear();
            ddlCity.Items.Add(new ListItem("--Select City--", ""));
            ddlCountry.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager.ConnectionStrings["baglan"].ConnectionString;
            String strQuery = "select CountryID, CountryName from Country " + "where ContinentID=@ContinentID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ContinentID",
            ddlContinents.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlCountry.DataSource = cmd.ExecuteReader();
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                if (ddlCountry.Items.Count > 1)
                {
                    ddlCountry.Enabled = true;
                }
                else
                {
                    ddlCountry.Enabled = false;
                    ddlCity.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add(new ListItem("--Select City--", ""));
            ddlCity.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager.ConnectionStrings["baglan"].ConnectionString;
            String strQuery = "select CityID, CityName from City " +"where CountryID=@CountryID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@CountryID", ddlCountry.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlCity.DataSource = cmd.ExecuteReader();
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityID";
                ddlCity.DataBind();
                if (ddlCity.Items.Count > 1)
                {
                    ddlCity.Enabled = true;
                }
                else
                {
                    ddlCity.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
                      lblResults.Text = "You Selected " +
                      ddlContinents.SelectedItem.Text + " -----> " +
                      ddlCountry.SelectedItem.Text + " -----> " +
                      ddlCity.SelectedItem.Text;
        }
    }
}