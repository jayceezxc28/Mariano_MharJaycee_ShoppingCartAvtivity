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

            
            int receiptNo = 0;
            double[] history = new double[25];
            int historyIndex = 0;
            string orderAgain="Y";

            do{
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
    Console.WriteLine("2 - Cart Menu");
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
    if (cartCount >= cartIds.Length)
    {
        Console.WriteLine("Cart is full!");
        break;
    }

    cartIds[cartCount] = id;
    cartQty[cartCount] = qty;
    cartSub[cartCount] = selected.GetItemTotal(qty);
    cartCount++;
    }

    selected.DeductStock(qty);
    Console.WriteLine("Item added!");

    break;

            case 2:

    int cartOption;

    do
    {
        Console.WriteLine("\n----- CART MENU -----");
        Console.WriteLine("1 - View Cart");
        Console.WriteLine("2 - Remove Item");
        Console.WriteLine("3 - Update Quantity");
        Console.WriteLine("4 - Clear Cart");
        Console.WriteLine("5 - Exit");

        Console.Write("Enter choice: ");

        while (!int.TryParse(Console.ReadLine(), out cartOption))
        {
            Console.Write("Invalid input! Enter again: ");
        }

        switch (cartOption)
        {
            
            case 1:
            
                Console.WriteLine("\n--- CART ITEMS ---");

                bool hasItems = false;

                for (int i = 0; i < cartCount; i++)
                {
                    if (cartIds[i] == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"{product[cartIds[i] - 1].Name} x{cartQty[i]}");
                    hasItems = true;
                }

                if (!hasItems)
                {
                    Console.WriteLine("Cart is empty.");
                }

                break;
            

            
            case 2:
            
                Console.Write("Enter product ID to remove: ");
                int removeId;

                if (!int.TryParse(Console.ReadLine(), out removeId))
                {
                    Console.WriteLine("Invalid input!");
                    break;
                }

                bool removed = false;

                for (int i = 0; i < cartCount; i++)
                {
                    if (cartIds[i] == removeId)
                    {
                        product[removeId - 1].RemainingStock += cartQty[i];

                        cartIds[i] = 0;
                        cartQty[i] = 0;
                        cartSub[i] = 0;

                        Console.WriteLine("Item removed!");
                        removed = true;
                        break;
                    }
                }

                if (!removed)
                {
                    Console.WriteLine("Item not found in cart.");
                }

                break;
            

            
            case 3:
            
                Console.Write("Enter product ID: ");
                int updateId;

                if (!int.TryParse(Console.ReadLine(), out updateId))
                {
                    Console.WriteLine("Invalid input!");
                    break;
                }

                bool found = false;

                for (int i = 0; i < cartCount; i++)
                {
                    if (cartIds[i] == updateId)
                    {
                        Console.Write("Enter new quantity: ");
                        int newQty;

                        if (!int.TryParse(Console.ReadLine(), out newQty) || newQty <= 0)
                        {
                            Console.WriteLine("Invalid quantity!");
                            break;
                        }

                        int oldQty = cartQty[i];
                        int difference = newQty - oldQty;

                        if (difference > 0)
                        {
                            if (!product[updateId - 1].HasEnoughStock(difference))
                            {
                                Console.WriteLine("Not enough stock!");
                                break;
                            }

                            product[updateId - 1].DeductStock(difference);
                        }
                        else if (difference < 0)
                        {
                            product[updateId - 1].RemainingStock += (-difference);
                        }

                        cartQty[i] = newQty;
                        cartSub[i] = product[updateId - 1].GetItemTotal(newQty);

                        Console.WriteLine("Quantity updated!");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Item not found in cart.");
                }

                break;

                case 4:

    bool mayLaman = false;

    for (int i = 0; i < cartIds.Length; i++)
    {
        if (cartIds[i] != 0)
        {
            mayLaman = true;
            break;
        }
    }

    if (!mayLaman)
    {
        Console.WriteLine("\n-- Cart is empty --");
        break;
    }

    string confirmClear;

    Console.WriteLine("\nAre you sure? This will clear all items in your cart.");
    Console.Write("Y/N: ");
    confirmClear = Console.ReadLine().ToUpper().Trim();

    while (confirmClear != "Y" && confirmClear != "N")
    {
        Console.Write("Type only Y or N: ");
        confirmClear = Console.ReadLine().ToUpper().Trim();
    }

    if (confirmClear == "Y")
    {
        for (int i = 0; i < cartIds.Length; i++)
        {
            if (cartIds[i] == 0)
            {
                continue;
            }

            for (int j = 0; j < product.Length; j++)
            {
                if (product[j].Id == cartIds[i])
                {
                    product[j].RemainingStock += cartQty[i];
                    break;
                }
            }

            cartIds[i] = 0;
            cartQty[i] = 0;
            cartSub[i] = 0;
        }

        Console.WriteLine("\nCart cleared successfully!");
    }

    break;
            
            

            case 5:
                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }

    } while (cartOption != 5);

    break;



        case 3:
        
            bool foundName = false;
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine().ToLower();

            for (int i = 0; i < product.Length; i++)
            {
              if(product[i].Name.ToLower().Contains(name))
            {
              product[i].DisplayProduct();
              foundName = true;
            }
            }
            if (!foundName)
            {
              Console.WriteLine("Product not found.");
            }

            break;
        

        case 4:
        
            bool foundCategory = false;
            Console.Write("Enter Category: ");
            string cat = Console.ReadLine().ToLower();

            for (int i = 0; i < product.Length; i++){
                if(product[i].Category.ToLower().Contains(cat))
                {
                product[i].DisplayProduct();
                foundCategory = true;
                }
            }
            if(!foundCategory)
               {
               Console.WriteLine("Category not found.");
               }

            break;
        

    }

} while (optionSelect != 5);
                double total = 0;
                bool hasCheckoutItems = false;

                for (int i = 0; i < cartCount; i++) 
                {
                    if (cartIds[i] == 0) continue;
                    hasCheckoutItems = true;
                    total += product[cartIds[i] - 1].GetItemTotal(cartQty[i]); 
                }
                if (!hasCheckoutItems)
                {
                    Console.WriteLine("\nNo items to checkout."); 
                }
                else {
                    Console.WriteLine("\n----- RECEIPT -----");
                    
                    receiptNo++;
                    Console.WriteLine($"Receipt #{receiptNo:D4}");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    
                    double discount = 0;
                    if (total >= 5000)
                        discount = total * 0.10;

                    double finalTotal = total - discount;
                    
                    Console.WriteLine($"\nFinal Total: {finalTotal}");
                    
                    double payment;

                    while (true)
                    {
                        Console.Write("Enter payment: ");
                        
                        if (!double.TryParse(Console.ReadLine(), out payment))
                            continue;
                        
                        if (payment < finalTotal)
                            continue;
                        
                        Console.WriteLine($"Change: {payment - finalTotal}");
                        break; 
                    }
                    if (historyIndex < history.Length)
                    {
                        history[historyIndex] = finalTotal;
                        historyIndex++;
                    }

                    Console.WriteLine("\n--- ORDER HISTORY ---");
                    for (int i = 0; i < historyIndex; i++)
                    {
                        Console.WriteLine($"Receipt #{i + 1:D4}: {history[i]}"); 
                    }

                    Console.WriteLine("\n--- LOW STOCK ALERT ---");
                    for (int i = 0; i < product.Length; i++)
                    {
                        if (product[i].RemainingStock <= 5)
                        {
                            Console.WriteLine($"{product[i].Name} low stock: {product[i].RemainingStock}");
                        }
                    }
                }
                Console.Write("\nShop again? (Y/N): ");
                orderAgain = Console.ReadLine().ToUpper().Trim();
                
                while (orderAgain != "Y" && orderAgain != "N")
                {
                    Console.Write("Type only 'Y' or 'N': ");
                    orderAgain = Console.ReadLine().ToUpper().Trim(); 
                }

                
            }while(orderAgain=="Y");
            Console.WriteLine("Thank you!");
            
            

        }
    }
}
