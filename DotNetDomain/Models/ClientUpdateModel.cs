using DotNetDomain.Contracts;

namespace DotNetDomain.Models
{
    public class ClientUpdateModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public int? BankId { get; set; }
    }
}