using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class EmailTesting
    {
        static void Main(string[] args)
        {

            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {

                Credentials = new NetworkCredential("ff35833ed45ac5", "b70c1983a939f6"),
                EnableSsl = true
            };

            client.Send("basusingg@gmail.com", "mksingh223391@gmail.com", "Hello world", "testbody");
            Console.WriteLine("Sent");

            Console.ReadLine();
        }
    }
}