using DotNetDomain.Contracts;

namespace DotNetDomain.Models
{
    public class BankIdentityModel : IBankContainer
    {
        public int? BankID { get; }

        public BankIdentityModel(int BankID)
        {
            this.BankID = BankID;
        }
    }
}