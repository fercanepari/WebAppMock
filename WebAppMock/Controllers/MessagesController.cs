using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            string filePath = Environment.CurrentDirectory;

            string[] lines = System.IO.File.ReadAllLines(filePath + @"\messagesReceived.txt");

            var allMessages = new List<Message>();
            int i = 1;
            foreach (string line in lines)
            {

                var data = line.Split(";");
                Message msg = new Message(i, data[0], data[1]);
                allMessages.Add(msg);
                i++;
            }

            return allMessages.ToArray();
        }

        [HttpPost("add")]
        public IActionResult AddMessage(Message msg)
        {
            Message msgOrig = new Message();
            msgOrig = msg;

            string filePath = Environment.CurrentDirectory;
            Console.WriteLine(filePath);
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(filePath + @"\messagesReceived.txt"))
            {
                sw.WriteLine(String.Concat(msg.Title, ";", msg.Body));

            }

            return CreatedAtAction(nameof(AddMessage), msg);

        }
    }
}
