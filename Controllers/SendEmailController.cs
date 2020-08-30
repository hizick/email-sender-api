using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace EmailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("working");


        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] Email email)
        {
            string status;
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(email.SenderName, email.AddressFrom));
                message.To.Add(new MailboxAddress("", email.AddressTo));
                message.Subject = email.Subject;

                message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = email.Body
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(email.SMTP, 465, true);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(email.Username, email.Password);

                    await client.SendAsync(message);
                    client.Disconnect(true);
                    status = "success";
                }
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            
            return Ok(status);
        }
    }
}
