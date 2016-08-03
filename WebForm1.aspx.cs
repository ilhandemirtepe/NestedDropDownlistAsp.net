using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DropFor
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        NestedDropdownListEntities dbEntity = new NestedDropdownListEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var country = from c in dbEntity.Continent select 
                                  new { 
                                      c.ContinentID,
                                      c.ContinentName 
                                  };
                ddlkita.DataSource = country.ToList();
                ddlkita.DataValueField = "ContinentID";
                ddlkita.DataTextField = "ContinentName";
                ddlkita.DataBind();
                ddlkita.Items.Insert(0, "--kıta seç--");
            }
        }

        protected void ddlkita_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ulkeNumber = Convert.ToInt16(ddlkita.SelectedValue.ToString());
            var state = from s in dbEntity.Country where s.ContinentID.Equals(ulkeNumber) select 
                            new {
                                s.CountryID, 
                                s.CountryName 
                            };
            ddlulke.DataSource = state.ToList();
            ddlulke.Enabled = true;
            ddlulke.DataValueField = "CountryID";
            ddlulke.DataTextField = "CountryName";
            ddlulke.DataBind();
            ddlulke.Items.Insert(0, "--ulke seç--");
        }

        protected void ddlulke_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sehirNumber = Convert.ToInt16(ddlulke.SelectedValue.ToString());
            var city = from c in dbEntity.City where c.CountryID.Equals(sehirNumber) select
                           new 
                           {
                               c.CityID,
                               c.CityName 
                           };
            ddlsehir.DataSource = city.ToList();
            ddlsehir.Enabled = true;
            ddlsehir.DataValueField = "CityID";
            ddlsehir.DataTextField = "CityName";
            ddlsehir.DataBind();
            ddlsehir.Items.Insert(0, "--şehir seç--");
        }

        protected void ddlsehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKita.Text = ddlkita.SelectedItem.Text;
            lblŞehir.Text = ddlsehir.SelectedItem.Text;
            lblUlke.Text = ddlulke.SelectedItem.Text;

        }
    }
}