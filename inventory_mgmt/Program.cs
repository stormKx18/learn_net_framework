using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public Product(string name, double price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: ${Price:F2}, Stock: {Stock}";
    }
}

class InventoryManager
{
    private List<Product> products = new List<Product>();

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Inventory Management System ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View Inventory");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    ViewInventory();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.Clear();
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product price: ");
        if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
        {
            Console.WriteLine("Invalid price! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        Console.Write("Enter stock quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
        {
            Console.WriteLine("Invalid stock quantity! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        products.Add(new Product(name, price, stock));
        Console.WriteLine("Product added successfully! Press Enter to return...");
        Console.ReadLine();
    }

    private void UpdateStock()
    {
        Console.Clear();
        if (products.Count == 0)
        {
            Console.WriteLine("No products available! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        ViewInventory();
        Console.Write("Enter product name to update: ");
        string name = Console.ReadLine();

        Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            Console.WriteLine("Product not found! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        Console.Write("Enter stock change (+ to add, - to remove): ");
        if (!int.TryParse(Console.ReadLine(), out int change))
        {
            Console.WriteLine("Invalid input! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        if (product.Stock + change < 0)
        {
            Console.WriteLine("Stock cannot be negative! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        product.Stock += change;
        Console.WriteLine("Stock updated successfully! Press Enter to return...");
        Console.ReadLine();
    }

    private void ViewInventory()
    {
        Console.Clear();
        if (products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
        }
        else
        {
            Console.WriteLine("=== Product Inventory ===");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    private void RemoveProduct()
    {
        Console.Clear();
        if (products.Count == 0)
        {
            Console.WriteLine("No products available! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        ViewInventory();
        Console.Write("Enter product name to remove: ");
        string name = Console.ReadLine();

        Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product == null)
        {
            Console.WriteLine("Product not found! Press Enter to return...");
            Console.ReadLine();
            return;
        }

        products.Remove(product);
        Console.WriteLine("Product removed successfully! Press Enter to return...");
        Console.ReadLine();
    }
}

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();
        manager.Run();
    }
}