using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    public static class SampleData
    {
        public static List<Customer> Customers = new()
        {
            new Customer { Id = 1, Name = "FrieslandCampina", Country = "NL" },
            new Customer { Id = 2, Name = "Heineken", Country = "NL" },
            new Customer { Id = 3, Name = "Nabuurs Logistics", Country = "NL" },
            new Customer { Id = 4, Name = "Nestle", Country = "DE" },
            new Customer { Id = 5, Name = "Danone", Country = "FR" },
            new Customer { Id = 6, Name = "Unilever", Country = "UK" },
        };

        public static List<Order> Orders = new()
        {
            new Order { Id = 1001, CustomerId = 1, OrderDate = new DateTime(2025,10,10), Status = "Delivered" },
            new Order { Id = 1002, CustomerId = 2, OrderDate = new DateTime(2025,10,11), Status = "Pending" },
            new Order { Id = 1003, CustomerId = 2, OrderDate = new DateTime(2025,10,13), Status = "Delivered" },
            new Order { Id = 1004, CustomerId = 3, OrderDate = new DateTime(2025,10,13), Status = "Cancelled" },
            new Order { Id = 1005, CustomerId = 4, OrderDate = new DateTime(2025,10,14), Status = "Delivered" },
            new Order { Id = 1006, CustomerId = 5, OrderDate = new DateTime(2025,10,14), Status = "Pending" },
            new Order { Id = 1007, CustomerId = 1, OrderDate = new DateTime(2025,10,15), Status = "Pending" },
        };

        public static List<OrderLine> OrderLines = new()
        {
            new OrderLine { Id = 1, OrderId = 1001, Product = "Milk 1L", Quantity = 100, Price = 1.20m },
            new OrderLine { Id = 2, OrderId = 1001, Product = "Cheese 500g", Quantity = 50, Price = 3.50m },
            new OrderLine { Id = 3, OrderId = 1002, Product = "Beer Crate", Quantity = 30, Price = 12.00m },
            new OrderLine { Id = 4, OrderId = 1003, Product = "Beer Crate", Quantity = 40, Price = 11.80m },
            new OrderLine { Id = 5, OrderId = 1004, Product = "Transport Box", Quantity = 10, Price = 5.00m },
            new OrderLine { Id = 6, OrderId = 1005, Product = "Chocolate", Quantity = 200, Price = 2.10m },
            new OrderLine { Id = 7, OrderId = 1006, Product = "Yogurt 250g", Quantity = 300, Price = 0.80m },
            new OrderLine { Id = 8, OrderId = 1007, Product = "Milk 1L", Quantity = 200, Price = 1.10m },
            new OrderLine { Id = 9, OrderId = 1007, Product = "Butter 250g", Quantity = 100, Price = 1.80m },
        };
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Country { get; set; } = "";
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "";
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Product { get; set; } = "";
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;
    }
}

