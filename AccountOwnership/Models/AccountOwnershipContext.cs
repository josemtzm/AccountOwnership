using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        /// <summary>
        /// Extended DBContext method from Base Class to write errors in console when seed data to DB.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Record> Records { get; set; }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<AccountOwnership.Models.Client> Clients { get; set; }

    }
}
