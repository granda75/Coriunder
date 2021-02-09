using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coriunder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOrderTotal.Text = "5Eur";
        }

        protected void btnPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentDetails.aspx");
        }
    }
}