using bizcard.online.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace bizcard.online.Framework
{
    public static class TemplateService 
    {
        public static string SendBizCard(ApplicationUser user)
        {
            string html = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/BizcardTemplate.html"));

            html = html.Replace("<firstname>", user.FirstName);
            html = html.Replace("<lastname>", user.LastName);
            html = html.Replace("<worktitle>", user.Title.ToString());
            html = html.Replace("<address1>", user.Address1);
            html = html.Replace("<address2>", user.Address2);
            html = html.Replace("<city>", user.City);
            html = html.Replace("<state>", user.State);
            html = html.Replace("<postalcode>", user.PostalCode.ToString());
            html = html.Replace("<directnumber>", user.DirectNumber);
            html = html.Replace("<businessnumber>", user.BusinessNumber.ToString());
            html = html.Replace("<faxnumber>", user.FaxNumber.ToString());
            html = html.Replace("<phonenumber>", user.PhoneNumber);
            html = html.Replace("<businessemail>", user.BusinessEmail.ToString());
            html = html.Replace("<website>", user.Website.ToString());
            html = html.Replace("<logo>", user.ImageName.ToString());
            return html;
            
        }

        public static string SendCard(string imageurl, string message)
        {
            string html = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/CardTemplate.html"));

            html = html.Replace("<logo>", imageurl.ToString());
            html = html.Replace("<message>", message.ToString());
            return html;

        }
    }
}
