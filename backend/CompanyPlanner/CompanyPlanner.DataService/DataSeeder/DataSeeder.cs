using CompanyPlanner.DataService.DBContext;
using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.DataService.DataSeeder
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    Id = 1,
                    Name = "Alice Example",
                    Images = [
                        new CustomerImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAD0lEQVR42mP8z8BQz0AEYBxVSFQAAAEpSURBVAjXY2AgDQAAADAAAceqhY4AAAAASUVORK5CYII=",
                            Id = 4,
                            CustomerId = 1,
                        }
                    ]
                });
                context.Customers.Add(new Customer
                {
                    Id = 2,
                    Name = "Bob Sample",
                    Images = [
                        new CustomerImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAn8B9XrKfR8AAAAASUVORK5CYII=",
                            Id = 1,
                            CustomerId = 2,
                        },
                        new CustomerImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8HwQACfsD/ULs1XsAAAAASUVORK5CYII=",
                            Id = 2,
                            CustomerId = 2,
                        },
                        new CustomerImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAD0lEQVR42mP8z8BQz0AEYBxVSFQAAAEpSURBVAjXY2AgDQAAADAAAceqhY4AAAAASUVORK5CYII=",
                            Id = 3,
                            CustomerId = 2,
                        }
                    ]
                });
                context.SaveChanges();
            }

            if (!context.Leads.Any())
            {
                context.Leads.Add(new Lead
                {
                    CompanyName = "Acme Corp",
                    Images = [
                        new LeadImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAn8B9XrKfR8AAAAASUVORK5CYII=",
                            Id = 1,
                            LeadId = 1,
                        },
                        new LeadImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8HwQACfsD/ULs1XsAAAAASUVORK5CYII=",
                            Id = 2,
                            LeadId = 1,
                        },
                        new LeadImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAD0lEQVR42mP8z8BQz0AEYBxVSFQAAAEpSURBVAjXY2AgDQAAADAAAceqhY4AAAAASUVORK5CYII=",
                            Id = 3,
                            LeadId = 1,
                        }
                    ]
                });
                context.Leads.Add(new Lead
                {
                    CompanyName = "Beta Inc",
                    Images = [
                        new LeadImage(){
                            Base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAn8B9XrKfR8AAAAASUVORK5CYII=",
                            Id = 4,
                            LeadId = 2,
                        },
                    ]
                });
                context.SaveChanges();
            }
        }
    }
}
