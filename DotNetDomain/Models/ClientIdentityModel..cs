using System;
using System.Linq;
using DotNetDomain.Contracts;

namespace DotNetDomain.Models
{
    public class ClientIdentityModel : IClientIdentity
    {
        public int Id { get; }

        public ClientIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}