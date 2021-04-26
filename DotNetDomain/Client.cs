using DotNetDomain.Contracts;

namespace DotNetDomain
{
    public class Client : IBankContainer
    {
        public int Id { get; set; }

        public Bank Bank { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
        
        int? IBankContainer.BankID => this.Bank.Id;
    }
}