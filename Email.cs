using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender
{
    public class Email
    {
        //String vFrom, String vTo, String vSubject, String vBody, String vSMTP, Int32 vPort, String vUserName, String vPassword
        public string AddressFrom { get; set; }
        public string  AddressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SMTP { get; set; }
        public int Port { get; set; }

        public string SenderName { get; set; }

        //to use for authentication
        public string Username { get; set; }
        public string Password { get; set; }

        public Email()
        {
            Port = 587;
        }
    }
}
