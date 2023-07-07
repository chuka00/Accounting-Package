/*using AccountManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            SeedCustomers(context);
            SeedInvoices(context);
            SeedPayments(context);
        }

        private static void SeedCustomers(ApplicationDbContext context)
        {
            if (context.Customers.Any())
            {
                return; // Database has already been seeded
            }

            var customers = new List<Customer>
        {
            new Customer { Name = "John Doe", Address = "123 Main St", Email = "john@example.com", PhoneNumber = "555-1234" },
            new Customer { Name = "Jane Smith", Address = "456 Elm St", Email = "jane@example.com", PhoneNumber = "555-5678" }
        };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void SeedInvoices(ApplicationDbContext context)
        {
            if (context.Invoices.Any())
            {
                return; // Database has already been seeded
            }

            var invoices = new List<Invoice>
        {
            new Invoice { CustomerId = 1, InvoiceDate = DateTime.Now.AddDays(-30), Amount = 1000 },
            new Invoice { CustomerId = 1, InvoiceDate = DateTime.Now.AddDays(-15), Amount = 500 },
            new Invoice { CustomerId = 2, InvoiceDate = DateTime.Now.AddDays(-20), Amount = 750 }
        };

            context.Invoices.AddRange(invoices);
            context.SaveChanges();
        }

        private static void SeedPayments(ApplicationDbContext context)
        {
            if (context.Payments.Any())
            {
                return; // Database has already been seeded
            }

            var payments = new List<Payment>
        {
            new Payment { InvoiceId = 1, PaymentDate = DateTime.Now.AddDays(-25), Amount = 500 },
            new Payment { InvoiceId = 2, PaymentDate = DateTime.Now.AddDays(-10), Amount = 250 },
            new Payment { InvoiceId = 2, PaymentDate = DateTime.Now.AddDays(-5), Amount = 200 }
        };

            context.Payments.AddRange(payments);
            context.SaveChanges();
        }


        *//*    public class SeedData
    {

        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            ToDoListDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<ToDoListDbContext>();

            if (!await context.Users.AnyAsync())
            {
              await  context.Users.AddRangeAsync(UsersWithToDos());
              await context.SaveChangesAsync();
            }


        }


        private static IEnumerable<User> UsersWithToDos()
        {
            return new List<User>()
            {
                new User()
                {
                    FullName = "John Doe",
                    Email = "john.doe@domain.com",
                    Password = "123445678",
                    TodoList = new List<Todo>()
                    {
                        new Todo
                        {
                            Title = "Build Project",
                            Description = "Building a project",
                            Priority = Priority.High,
                            DueDate = DateTime.Now.AddDays(3)

                        },

                        new Todo
                        {
                            Title = "Build Project2",
                            Description = "Building a project2",
                            Priority = Priority.Low,
                            DueDate = DateTime.Now,
                            IsDone = true

                        },
                        new Todo
                        {
                            Title = "Build Project3",
                            Description = "Building a project3",
                            DueDate = DateTime.Now.AddDays(23)

                        }
                    }

                },
                new User()
                {
                    
                    FullName = "Chizoba Doe",
                    Email = "chizoba.doe@domain.com",
                    Password = "123445678",
                    TodoList = new List<Todo>()
                    {
                        new Todo
                        {
                            Title = "Start Project",
                            Description = "Starting a project",
                            DueDate = DateTime.Now.AddDays(3)

                        },

                        new Todo
                        {
                           
                            Title = "Plan Project2",
                            Description = "Planing a project2",
                            Priority = Priority.High,
                            DueDate = DateTime.Now.AddDays(9),

                        },
                        new Todo
                        {
                            Title = "Deliver Project3",
                            Description = "Delivering a project3",
                            DueDate = DateTime.Now,
                            IsDone = true

                        }
                    }

                }
            };
        }


    }
*//*
    }

}
*/