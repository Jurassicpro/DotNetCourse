using System;
using System.Linq;
using DotNetDomain.Contracts;
namespace DotNetDomain
{
    public class Message
    {
        public int Id { get; set; }

        public string info { get; }

        public Message(string info)
        {
            this.info = info;
        }

    }
    
}