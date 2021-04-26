using DotNetDomain.Contracts;

namespace DotNetDomain.Models
{
    public interface BankUpdateModel : IBankContainer, IMessageContainer
    {
        public int Id { get; set; }
        
        public decimal Cash { get; set; }
        public Message Message { get; set; }
        
        public string Name { get; set; }
        
        public string Location { get; set; }
        
        public Bank Parent { get; set; }
        public int? MessageId { get; set; }
    }
}