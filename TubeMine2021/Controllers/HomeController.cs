using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tubemine2020.Controllers;
using TubeMine2021.Models;

namespace TubeMine2021.Controllers
{
    public class HomeController : Controller
    {

        private readonly tubemineOPEEntities dbope = new tubemineOPEEntities();
       


        [Route("~/en/")]
        public ActionResult Index(string LanguageCode = "en")
        {
            return View();


        }


        [Route("~/ar/")]
        public ActionResult Index_AR()
        {
            return View();


        }

        [Route("~/ar/contactus-thanks")]
        public ActionResult contactusthanksar()
        {
            return View();

        }


        [Route("~/en/contactus-thanks")]
        public ActionResult contactusthanksen()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/ar/contact-us")]
        public ActionResult Contactus(tbl_Requests_Contacts contact, string langName)
        {
            contact.RequestDate = DateTime.Now;
            dbope.tbl_Requests_Contacts.Add(contact);
            dbope.SaveChanges();
            #region mail
            MailHelper objSendMail = new MailHelper();
            string body =
            @"<table  style='border:1px solid #ccc;text-align: left;border-collapse: collapse;width: 100%;'>
                    <tbody>";

            body +=
            @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Customer Name: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerName + @" </td>
                    </tr>";

            body +=
            @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Email: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerEmail + @" </td>
                    </tr>";

            body +=
            @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Mobile Number: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerPhone + @" </td>
                    </tr>";

            body +=
           @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Message: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerMessage + @" </td>
                    </tr>";
            body += @"</tbody></table> ";

            objSendMail.SendMail("do-not-reply@tubemine.net", "ahmed.taha@titegypt.com", "Tubemine Online Contact request", body);
            objSendMail.SendMail("do-not-reply@tubemine.net", "info@tubemine.net", "Website Contact request", body);

            //MailHelper objthanksSendMail = new MailHelper();
            //string body1 = @"<div'>Thank you for your contact us<br/>We will contact with you as soon as possible.</div>";

            // objthanksSendMail.SendMail("do-not-reply@tubemine.net", contact.CustomerEmail, " Contact request", body1);


            #endregion

            return Redirect("~/ar/contactus-thanks");
            /*------------------recaptcha----------------------------------*/
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LcTB7sUAAAAAKhC_5CIhKaAJYKUtgJ0JiziydvR";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var ob = JObject.Parse(result);
            var status = (bool)ob.SelectToken("success");
            try
            {


                if (ModelState.IsValid && status == true)
                {




                }


                return View("Contactus", contact);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/en/contact-us")]
        public ActionResult ContactusEN(tbl_Requests_Contacts contact, string langName = "en")
        {
            contact.RequestDate = DateTime.Now;
            dbope.tbl_Requests_Contacts.Add(contact);
            dbope.SaveChanges();
            #region mail
            MailHelper objSendMail = new MailHelper();
            string body =
            @"<table  style='border:1px solid #ccc;text-align: left;border-collapse: collapse;width: 100%;'>
                    <tbody>";

            body +=
            @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Customer Name: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerName + @" </td>
                    </tr>";

            body +=
            @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Email: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerEmail + @" </td>
                    </tr>";

            body +=
            @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Mobile Number: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerPhone + @" </td>
                    </tr>";

            body +=
           @"<tr style='border: 1px solid #ccc;text-align: left;padding: 15px;'>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;width:200px;background-color:#ddd;'>Message: </td>
                    <td style='border: 1px solid #ccc;text-align: left;padding: 15px;'> " + contact.CustomerMessage + @" </td>
                    </tr>";
            body += @"</tbody></table> ";

            objSendMail.SendMail("do-not-reply@tubemine.net", "ahmed.taha@titegypt.com", "Tubemine Online Contact request", body);
            objSendMail.SendMail("do-not-reply@tubemine.net", "info@tubemine.net", "Website Contact request", body);
            //MailHelper objthanksSendMail = new MailHelper();
            //string body1 = @"<div'>Thank you for your contact us<br/>We will contact with you as soon as possible.</div>";

            //objthanksSendMail.SendMail("do-not-reply@tubemine.net", contact.CustomerEmail, " Contact request", body1);


            #endregion

            return Redirect("~/en/contactus-thanks");
            /*------------------recaptcha----------------------------------*/
            //var response = Request["g-recaptcha-response"];
            //string secretKey = "6LcTB7sUAAAAAKhC_5CIhKaAJYKUtgJ0JiziydvR";
            //var client = new WebClient();
            //var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            //var ob = JObject.Parse(result);
            //var status = (bool)ob.SelectToken("success");
            //try
            //{


            //    if (ModelState.IsValid && status == true)
            //    {




            //    }


            //    return View("Contactus", contact);
            //}
            //catch (Exception e)
            //{
            //    return Content(e.ToString());
            //}
        }



        // GET: /Error/HttpError404
        public ActionResult HttpError404(string message)
        {
            return View("SomeView", message);
        }


    }
}