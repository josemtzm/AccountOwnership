namespace AccountOwnership.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AccountOwnership.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AccountOwnership.Models.AccountOwnershipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AccountOwnership.Models.AccountOwnershipContext context)
        {
            Status stat1 = new Status() { Id = 1, Desc = "Approved" };
            Status stat2 = new Status() { Id = 2, Desc = "Rejected" };
            Status stat3 = new Status() { Id = 3, Desc = "Pending" };

            context.Status.AddOrUpdate(x => x.Id,
                stat1, stat2, stat3
                );
            Employee emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Snow", Kronos = 1234567 };
            Employee emp2 = new Employee { Id = 2, FirstName = "Ned", LastName = "Stark", Kronos = 7654321 };
            Employee emp3 = new Employee { Id = 3, FirstName = "Tyron", LastName = "Lanister", Kronos = 7777777 };
            Employee emp4 = new Employee { Id = 4, FirstName = "Daenerys", LastName = "Targaryen", Kronos = 1111111 };
            context.Employees.AddOrUpdate(x => x.Id,
                emp1, emp2, emp3, emp4
                );

            Client cli1 = new Client { Id = 1, Code = 1234, IdParent = 0, Name = "Accenture" };
            Client cli2 = new Client { Id = 2, Code = 1234, IdParent = 1, Name = "Accenture MX" };
            Client cli3 = new Client { Id = 3, Code = 1234, IdParent = 2, Name = "Accenture CDMX" };
            context.Clients.AddOrUpdate(x => x.Id,
                cli1,cli2, cli3
               );

            context.Records.AddOrUpdate(x => x.Id,
                new Record()
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    EVP = emp1,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    Status = stat1,
                    Client = cli1,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now
                },
                new Record()
                {
                    Id = 2,
                    StartTime = DateTime.Now,
                    EVP = emp2,
                    SVP = emp1,
                    VP = emp3,
                    ED = emp4,
                    Status = stat1,
                    Client = cli1,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now
                },
                new Record()
                {
                    Id = 3,
                    StartTime = DateTime.Now,
                    EVP = emp3,
                    SVP = emp2,
                    VP = emp1,
                    ED = emp4,
                    Status = stat2,
                    Client = cli2,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now
                },
                new Record()
                {
                    Id = 4,
                    StartTime = DateTime.Now,
                    EVP = emp4,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp1,
                    Status = stat3,
                    Client = cli3,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now
                });
        }
    }
}
