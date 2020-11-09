using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMock
{
    public class Message
    {
        public Message()
        {

        }

        public Message(long Id, string Title, string Body ){
            this.Id = Id;
            this.Title = Title;
            this.Body = Body;
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
