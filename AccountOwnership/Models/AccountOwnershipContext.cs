using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountOwnership.Models
{
    public class AccountOwnershipContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AccountOwnershipContext() : base("name=AccountOwnershipContext")
        {
            Database.SetInitializer<AccountOwnershipContext>(null);
        }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Record> Records { get; set; }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Client> Clients { get; set; }

    }
}
