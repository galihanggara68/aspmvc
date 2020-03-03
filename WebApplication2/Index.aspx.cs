using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<ListItem> lists = new List<ListItem>();
                lists.Add(new ListItem("+", "+"));
                lists.Add(new ListItem("-", "-"));
                lists.Add(new ListItem("*", "*"));
                lists.Add(new ListItem("/", "/"));
                lists.Add(new ListItem("%", "%"));

                ddSize.Items.AddRange(lists.ToArray());
            }
        }

        protected void btnCount_Click(object sender, EventArgs e)
        {
            int v1 = int.Parse(num1.Text);
            int v2 = int.Parse(num2.Text);
            int result = 0;
            switch(ddSize.SelectedValue)
            {
                case "+":
                    result = v1 + v2;
                    break;
                case "-":
                    result = v1 - v2;
                    break;
                case "*":
                    result = v1 * v2;
                    break;
                case "/":
                    result = v1 / v2;
                    break;
                case "%":
                    result = v1 % v2;
                    break;
            }
            lblResult.Text = result+"";
            lblResult.ForeColor = (result < 0) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
    }
}