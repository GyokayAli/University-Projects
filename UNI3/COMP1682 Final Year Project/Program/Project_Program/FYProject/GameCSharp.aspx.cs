﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYProject
{
    public partial class GameCSharp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Members");
        }
    }
}