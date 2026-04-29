using System;
namespace quiz
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int RemainingStock;
        public string Category;

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id, -5} {Name, -15} {Price, -10} {RemainingStock, -10} {Category, 10}");
        }
        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
        }
        public bool HasEnoughStock(int qty)
        {
            return qty <= RemainingStock;
        }
        public void DeductStock(int qty)
        {
            RemainingStock -= qty;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Product[] product = new Product[] {
            new Product
            {
                Id=1,
                Name="Mouse",
                Price=350,
                RemainingStock=50,
                Category="Accessories"
            },
            new Product
            {
                Id=2,
                Name="Keyboard",
                Price=800,
                RemainingStock=30,
                Category="Accessories"
            },
            new Product
            {
                Id=3,
                Name="Headset",
                Price=1200,
                RemainingStock=20,
                Category="Audio"
            },
            new Product
            {
                Id=4,
                Name="Flash Drive",
                Price=500,
                RemainingStock=15,
                Category="Storage"
            },
            new Product
            {
                Id=5,
                Name="Monitor",
                Price=6500,
                RemainingStock=10,
                Category="Display"
            }
            };

            int[] cartIds = new int[10];
            int[] cartQty = new int[10];
            double[] cartSub = new double[10];
            int cartCount = 0;

            
            int optionSelect;

            do
{
    Console.WriteLine("\n----- STORE MENU -----");
    Console.WriteLine("ID    Name            Price      Stock      Category");

    for (int i = 0; i < product.Length; i++)
    {
        product[i].DisplayProduct();
    }

    Console.WriteLine("\n1 - Add Product");
    Console.WriteLine("2 - Manage Cart");
    Console.WriteLine("3 - Search by Name");
    Console.WriteLine("4 - Search by Category");
    Console.WriteLine("5 - Checkout");

    Console.Write("Enter choice: ");

    while (!int.TryParse(Console.ReadLine(), out optionSelect))
    {
        Console.Write("Invalid input! Enter again: ");
    }

    switch (optionSelect)
    {
        case 1:

    Console.Write("Enter product ID: ");
    int id;

    if (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("Invalid ID!");
        break;
    }

    if (id < 1 || id > product.Length)
    {
        Console.WriteLine("Product not found!");
        break;
    }

    Product selected = product[id - 1];

    Console.Write("Enter quantity: ");
    int qty;

    if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
    {
        Console.WriteLine("Invalid quantity!");
        break;
    }

    if (!selected.HasEnoughStock(qty))
    {
        Console.WriteLine("Not enough stock!");
        break;
    }

    bool exists = false;

    for (int i = 0; i < cartCount; i++)
    {
        if (cartIds[i] == id)
        {
            cartQty[i] += qty;
            cartSub[i] = product[id - 1].GetItemTotal(cartQty[i]);
            exists = true;
            break;
        }
    }

    if (!exists)
    {
        cartIds[cartCount] = id;
        cartQty[cartCount] = qty;
        cartSub[cartCount] = selected.GetItemTotal(qty);
        cartCount++;
    }

    selected.DeductStock(qty);
    Console.WriteLine("Item added!");

    break;


        case 3:
        
            string name = Console.ReadLine().ToLower();

            for (int i = 0; i < product.Length; i++)
                if (product[i].Name.ToLower().Contains(name))
                    product[i].DisplayProduct();

            break;
        

        case 4:
        
            string cat = Console.ReadLine().ToLower();

            for (int i = 0; i < product.Length; i++)
                if (product[i].Category.ToLower().Contains(cat))
                    product[i].DisplayProduct();

            break;
        

    }

} while (optionSelect != 5);

            
            

        }
    }
}
