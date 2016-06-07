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

            context.Records.AddOrUpdate(x => x.Id,
                new Record()
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    EVP = emp1,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp4,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat1
                },
                new Record()
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    EVP = emp2,
                    SVP = emp1,
                    VP = emp3,
                    ED = emp4,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat2
                },
                new Record()
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    EVP = emp3,
                    SVP = emp2,
                    VP = emp1,
                    ED = emp4,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat1
                },
                new Record()
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    EVP = emp4,
                    SVP = emp2,
                    VP = emp3,
                    ED = emp1,
                    GL_CLT_CD = "",
                    EndTime = DateTime.Now,
                    POC = "",
                    LastModifiedDate = DateTime.Now,
                    GoLiveDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Status = stat3
                });
                //new Record()
                //{
                //    Id = 1,
                //    StartTime = DateTime.Now,
                //    EVP = new Employee() { Id = 2 },
                //    SVP = new Employee() { Id = 1 },
                //    VP = new Employee() { Id = 3 },
                //    ED = new Employee() { Id = 4 },
                //    GL_CLT_CD = "",
                //    EndTime = DateTime.Now,
                //    POC = "",
                //    LastModifiedDate = DateTime.Now,
                //    GoLiveDate = DateTime.Now,
                //    CloseDate = DateTime.Now,
                //    Status = new Status() { Id = 2 }
                //},
                //new Record()
                //{
                //    Id = 1,
                //    StartTime = DateTime.Now,
                //    EVP = new Employee() { Id = 3 },
                //    SVP = new Employee() { Id = 2 },
                //    VP = new Employee() { Id = 1 },
                //    ED = new Employee() { Id = 4 },
                //    GL_CLT_CD = "",
                //    EndTime = DateTime.Now,
                //    POC = "",
                //    LastModifiedDate = DateTime.Now,
                //    GoLiveDate = DateTime.Now,
                //    CloseDate = DateTime.Now,
                //    Status = new Status() { Id = 2 }
                //},
                //new Record()
                //{
                //    Id = 1,
                //    StartTime = DateTime.Now,
                //    EVP = new Employee() { Id = 4 },
                //    SVP = new Employee() { Id = 2 },
                //    VP = new Employee() { Id = 3 },
                //    ED = new Employee() { Id = 1 },
                //    GL_CLT_CD = "",
                //    EndTime = DateTime.Now,
                //    POC = "",
                //    LastModifiedDate = DateTime.Now,
                //    GoLiveDate = DateTime.Now,
                //    CloseDate = DateTime.Now,
                //    Status = new Status() { Id = 1 }
                //}
                //);
        }
    }
}
