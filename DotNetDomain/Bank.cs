using System;
using DotNetDomain.Contracts;

namespace DotNetDomain
{
    public class Bank : IMessageContainer
    {
        public int Id { get; set; }
        
        public decimal Cash { get; set; }
        public Message Message { get; set; }
        
        public string Name { get; set; }
        
        public string Location { get; set; }
        
        public Bank Parent { get; set; }
        int? IMessageContainer.MessageId  => this.Message.Id;
    }
}