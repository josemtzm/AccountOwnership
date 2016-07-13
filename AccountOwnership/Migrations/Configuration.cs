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
            Status stat1 = new Status() { Id = 1, Desc = "Active" };
            Status stat2 = new Status() { Id = 2, Desc = "Inactive" };
            
            context.Status.AddOrUpdate(x => x.Id, stat1, stat2);

            Employee emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Snow", Kronos = 1234567 };
            Employee emp2 = new Employee { Id = 2, FirstName = "Ned", LastName = "Stark", Kronos = 7654321 };
            Employee emp3 = new Employee { Id = 3, FirstName = "Tyron", LastName = "Lanister", Kronos = 7777777 };
            Employee emp4 = new Employee { Id = 4, FirstName = "Daenerys", LastName = "Targaryen", Kronos = 1111111 };
            Employee emp5 = new Employee { Id = 5, FirstName = "John", LastName = "Smith", Kronos = 7654321 };
            Employee emp6 = new Employee { Id = 6, FirstName = "Joan", LastName = "Grace", Kronos = 7412589  };
            Employee emp7 = new Employee { Id = 7, FirstName = "James", LastName = "Ava", Kronos = 3698521  };
            Employee emp8 = new Employee { Id = 8, FirstName = "Ryan", LastName = "Madison", Kronos = 4561238 };

            context.Employees.AddOrUpdate(x => x.Id, emp1, emp2, emp3, emp4, emp5, emp6, emp7, emp8);

            Client cli1 = new Client { Id = 1, Parent = null, Name = "Accenture", GL_CLT_CD = "TL01", Active = true};
            Client cli2 = new Client { Id = 2, Parent = cli1, Name = "Accenture MX", GL_CLT_CD = "22202", Active = true };
            Client cli3 = new Client { Id = 3, Parent = cli2, Name = "Accenture CDMX", GL_CLT_CD = "3003", Active = true };

            context.Clients.AddOrUpdate(x => x.Id, cli1,cli2, cli3);

            context.Records.AddOrUpdate(x => x.Id,
                new Record()
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    Client = cli2,
                    EVP = emp1,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    TAM = emp5,
                    Finance = emp6,
                    eWFM = emp7,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat1
                },
                new Record()
                {
                    Id = 2,
                    StartTime = DateTime.Now,
                    Client = cli2,
                    EVP = emp2,
                    SVP = emp1,
                    VP = emp3,
                    ED = emp4,
                    TAM = emp5,
                    Finance = emp6,
                    eWFM = emp7,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat2
                },
                new Record()
                {
                    Id = 3,
                    StartTime = DateTime.Now,
                    Client = cli3,
                    EVP = emp3,
                    SVP = emp2,
                    VP = emp1,
                    ED = emp4,
                    TAM = emp5,
                    Finance = emp6,
                    eWFM = emp7,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat1
                },
                new Record()
                {
                    Id = 4,
                    StartTime = DateTime.Now,
                    Client = cli2,
                    EVP = emp4,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp1,
                    TAM = emp5,
                    Finance = emp6,
                    eWFM = emp7,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat2
                },
                new Record()
                {
                    Id = 5,
                    StartTime = DateTime.Now,
                    Client = cli2,
                    EVP = emp5,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    TAM = emp1,
                    Finance = emp6,
                    eWFM = emp7,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat1
                },
                new Record()
                {
                    Id = 6,
                    StartTime = DateTime.Now,
                    Client = cli3,
                    EVP = emp6,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    TAM = emp5,
                    Finance = emp1,
                    eWFM = emp7,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat2
                },
                new Record()
                {
                    Id = 7,
                    StartTime = DateTime.Now,
                    Client = cli3,
                    EVP = emp7,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    TAM = emp5,
                    Finance = emp6,
                    eWFM = emp1,
                    POC = emp8,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat1
                },
                new Record()
                {
                    Id = 8,
                    StartTime = DateTime.Now,
                    Client = cli2,
                    EVP = emp8,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    TAM = emp5,
                    Finance = emp6,
                    eWFM = emp7,
                    POC = emp1,
                    EndTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat2
                });
        }
    }
}
