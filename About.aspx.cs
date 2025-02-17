using MyFIrstAspnetTablesd.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFIrstAspnetTablesd
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Coading

            EmployeeDAL employeeDAL = new EmployeeDAL();
            //var getData = employeeDAL.GetData();
            var getData = employeeDAL.GetData();

            IdGridVIew.DataSource = getData;
            IdGridVIew.DataBind();

            //employeeDAL.SaveData();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var getData = TextBox1.Text;

            var a = 10;


        }
    }
}