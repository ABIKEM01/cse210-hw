using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address addr2 = new Address("45 Market Rd", "Lagos", "Lagos State", "Nigeria");

    
        Customer cust1 = new Customer("John Doe", addr1);
        Customer cust2 = new Customer("Jane Smith", addr2);

        
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P1001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 25, 2));

        
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Phone", "P2001", 500, 1));
        order2.AddProduct(new Product("Charger", "P2002", 20, 3));

        
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}\n");

        
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}\n");
    }
}
