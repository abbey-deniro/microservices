using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Controllers
{
    [ApiController]
    [Route("email")]
    public class EmailController : ControllerBase
    {
        // private readonly ItemDB _db;

        // public CatalogController(ILogger<CatalogController> logger, ItemDB db)
        // {
        //     _db = db;
        // }

        [HttpPost("testJson")]
        public string testJson(Dictionary<string,int> json)
        {
            //Console.WriteLine(json);
            return "yo";
        }


        [HttpPost("test")]
        public string SendEmail()
        {
            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.office365.com");

                    // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                // put email and password
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("email", "password");
                mySmtpClient.Credentials = basicAuthenticationInfo;
                mySmtpClient.EnableSsl = true;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("dagonzalez@student.neumont.edu", "Yo");
                MailAddress to = new MailAddress("dandan1523@outlook.com", "Daniel");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                // MailAddress replyTo = new MailAddress("reply@example.com");
                // myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "Test message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
                return "email sent";
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}