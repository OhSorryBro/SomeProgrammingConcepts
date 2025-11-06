using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SomeProgrammingConcepts.ΛExpressions;

namespace SomeProgrammingConcepts
{
    internal class Class1
    {
        public static void Run()
        {
            //Exercise L11 – Nested Report (Warehouses and Products)
            //You are given:
            var warehouses = new[]
            {
                new { WarehouseId = 1, Name = "Heijen" },
                new { WarehouseId = 2, Name = "Katwijk" },
                new { WarehouseId = 3, Name = "Hedel" },
            };

            var products = new[]
            {
                new { ProductId = 1, Name = "Milk",  Category = "Dairy" },
                new { ProductId = 2, Name = "Cheese", Category = "Dairy" },
                new { ProductId = 3, Name = "Beer",  Category = "Beverage" },
                new { ProductId = 4, Name = "Chips", Category = "Snack" },
            };

            var stock = new[]
            {
                new { WarehouseId = 1, ProductId = 1, Qty = 100 },
                new { WarehouseId = 1, ProductId = 2, Qty = 50 },
                new { WarehouseId = 1, ProductId = 3, Qty = 200 },
                new { WarehouseId = 2, ProductId = 2, Qty = 75 },
                new { WarehouseId = 2, ProductId = 3, Qty = 150 },
                new { WarehouseId = 3, ProductId = 4, Qty = 300 },
            };

            //Task:
            //Build a structure:
            //            {
            //              WarehouseName: "...",
            //              Categories: [
            //                   {
            //                      Category: "...",
            //                      Products: ["Milk", "Cheese", ... ],
            //                      TotalQty: ...
            //                      },
            //                      ...
            //              ],
            //              GrandTotalQty: ...
            //              }
            //        Requirements:
            //            Join warehouses, stock, and products.
            //            Group by warehouse → category.
            //            Sort products alphabetically.
            //            Sort warehouses by GrandTotalQty descending.


            var ProductsStock = stock.Join(
                products,
                StockKey => StockKey.ProductId,
                ProductsKey => ProductsKey.ProductId,
                (StockKey, ProductsKey) => new
                {
                    Category = ProductsKey.Category,
                    ProductName = ProductsKey.Name,
                    Qty = StockKey.Qty,
                    ProductId = StockKey.ProductId,
                    WarehouseId = StockKey.WarehouseId
                });

            var GroupingProductsStock = ProductsStock
                .GroupBy(x => new { x.WarehouseId, x.Category })
                .Select(x => new
                {
                    Products = x.Select(y => y.ProductName).Distinct().OrderBy(p=>p),
                    TotalQty = x.Sum(y => y.Qty),
                    WarehouseId = x.Key.WarehouseId,
                    Category = x.Key.Category
                });

            var GroupingWarehouse = GroupingProductsStock
                .GroupBy(g => g.WarehouseId)
                .Select(x => new
                {
                    WarehouseId = x.Key,
                    Categories = x.Select(c=> new
                    {
                        category = c.Category,
                        Products = c.Products,
                        TotalQty = c.TotalQty
                    }),
                    GrandTotalQty = x.Sum(x => x.TotalQty)
                })
                .Join(warehouses,
                GroupingProductsStockKey => GroupingProductsStockKey.WarehouseId,
                warehousesKey => warehousesKey.WarehouseId,
                (GroupingProductsStockKey, warehousesKey) => new
                {
                    WarehouseName = warehousesKey.Name,
                    Categories = GroupingProductsStockKey.Categories,
                    GrandTotalQty = GroupingProductsStockKey.GrandTotalQty
                }).OrderByDescending(x => x.GrandTotalQty);


            //Exercise L12 – Orders by Region (Multi-level Grouping)
            var regions = new[]
                {
                    new { RegionId = 1, Name = "North" },
                    new { RegionId = 2, Name = "South" },
                };

            var customers = new[]
                {
                    new { CustomerId = 1, RegionId = 1, Name = "FrieslandCampina" },
                    new { CustomerId = 2, RegionId = 1, Name = "Heineken" },
                    new { CustomerId = 3, RegionId = 2, Name = "Nabuurs" },
                };

            var orders = new[]
                {
                    new { OrderId = 1001, CustomerId = 1, Value = 1200m },
                    new { OrderId = 1002, CustomerId = 2, Value = 800m },
                    new { OrderId = 1003, CustomerId = 2, Value = 600m },
                    new { OrderId = 1004, CustomerId = 3, Value = 1500m },
                };
            //Task:
            //Build a report:
            //{
            //        RegionName: "...",
            //        Customers:
            //            [
            //              {
            //                  CustomerName: "...",
            //                  Orders: [ { OrderId, Value }, ... ],
            //                  TotalValue: ...
            //              },
            //              ...
            //            ],
            //            RegionTotalValue: ...
            //         }
            //Requirements:
            //Group customers by region.
            //Sort customers by TotalValue descending.
            //Sort regions by RegionTotalValue descending.

            var OrdersCustomers = customers.Join(
                orders,
                CustomersKey => CustomersKey.CustomerId,
                OrdersKey => OrdersKey.CustomerId,
                (CustomersKey, OrdersKey) => new
                {
                    CustomerName = CustomersKey.Name,
                    CustomerID = CustomersKey.CustomerId,
                    Value = OrdersKey.Value,
                    OrderID = OrdersKey.OrderId,
                    RegionId = CustomersKey.RegionId
                });

            var OrdersCustomersGrouped = OrdersCustomers
                .GroupBy(x => new { x.CustomerID, x.CustomerName, x.RegionId })
                .Select(x => new
                {
                    CustomerName = x.Key.CustomerName,
                    Orders = x.Select(o => new { o.OrderID, o.Value }).OrderByDescending(o => o.Value),
                    TotalValue = x.Sum(o => o.Value),
                    RegionId = x.Key.RegionId
                }).OrderByDescending(c => c.TotalValue);






            //Exercise L13 – Complex Invoice Report
            //You are given:
            var suppliers = new[]
                {
                    new { SupplierId = 1, Name = "FreshFarms" },
                    new { SupplierId = 2, Name = "GreenGrow" }
                };

            var invoices = new[]
                {
                    new { InvoiceId = 9001, SupplierId = 1 },
                    new { InvoiceId = 9002, SupplierId = 1 },
                    new { InvoiceId = 9003, SupplierId = 2 }
                };

            var lines = new[]
                {
                    new { InvoiceId = 9001, Product = "Milk", Qty = 10, Price = 1.2m },
                    new { InvoiceId = 9001, Product = "Cheese", Qty = 5, Price = 3.5m },
                    new { InvoiceId = 9002, Product = "Apple", Qty = 20, Price = 0.8m },
                    new { InvoiceId = 9003, Product = "Banana", Qty = 15, Price = 0.6m },
                    new { InvoiceId = 9003, Product = "Milk", Qty = 10, Price = 1.3m },
                };
        //Task:
        //Build a structure:
        //{
        //    SupplierName: "...",
        //    Invoices: [
        //      {
        //        InvoiceId: ...,
        //        Products: ["Milk", "Cheese", ... ],
        //        TotalValue: ...
        //      },
        //      ...
        //      ],
        //      GrandTotalValue: ...
        //}

        //  Requirements:
        //      Group lines by InvoiceId → calculate totals and unique product names.
        //      Join with invoices and then with suppliers.
        //      Sort invoices by TotalValue descending.
        //      Sort suppliers by GrandTotalValue descending.




    }
}
}
