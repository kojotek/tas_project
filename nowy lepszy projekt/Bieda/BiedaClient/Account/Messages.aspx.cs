using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BiedaClient.Account
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();


            List<string> msg = new List<string>(client.getMessages(Context.User.Identity.GetUserName()));

            bool switcher = true;
            List<KeyValuePair<string, string>> pary = new List<KeyValuePair<string, string>>();
            string helper = "";

            Panel1.Visible = false;
            NoMessage.Visible = true;

            foreach (string s in msg)
            {
                if (switcher)
                {
                    helper = s;
                }
                else
                {
                    pary.Add(new KeyValuePair<string, string>(helper, s));
                }
                switcher = !switcher;

                Panel1.Visible = true;
                NoMessage.Visible = false;
            }

            bool sw = true;

            foreach (KeyValuePair<string, string> p in pary)
            {
                TableCell c = new TableCell();
                c.Width = 200;
                c.Text = p.Key;
                TableCell c2 = new TableCell();
                c2.Text = p.Value;
                c2.Width = 600;
                TableRow r = new TableRow();
                r.Controls.Add(c);
                r.Controls.Add(c2);
                if (sw) { r.BackColor = System.Drawing.Color.FromName("#FFBC79"); }
                else { r.BackColor = System.Drawing.Color.FromName("#FF9D3C"); }
                sw = !sw;
                Table2.Controls.Add(r);
            }

        }
    }
}