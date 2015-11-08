using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace PdfResponse
{
    public partial class Home : System.Web.UI.Page
    {

        public delegate int CalculateDelegate(int a, int b);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string tempFile = ConfigurationManager.AppSettings["DocumentPath"].ToString();
            MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(tempFile));
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.AddHeader("Accept-Header", stream.Length.ToString());
            Response.AddHeader("Content-Length", stream.Length.ToString());
            Response.AddHeader("Expires", "0″");
            Response.AddHeader("Pragma", "cache");
            Response.AddHeader("Cache-Control", "private");
            Response.AddHeader("content-disposition", String.Format("inline;filename={0}", "IncrementLetter.pdf"));
            Response.ContentType = "application/pdf";
            Response.AddHeader("Accept-Ranges", "bytes");
            Response.BinaryWrite(stream.ToArray());
            Response.Flush();
            Response.End();
        }

        protected void btnCallDelegate_Click(object sender, EventArgs e)
        {
            CalculateDelegate cd = new CalculateDelegate(Calculate);
            int result = cd(10, 20);
            lblResult.Text = result.ToString();
        }

        private int Calculate(int a, int b)
        {
            return (a + b);
        }
    }
}