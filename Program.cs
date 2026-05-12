using System;
namespace quiz
{
    class Product
{
    private int id;
    private string name;
    private double price;
    private int remainingStock;
    private string category;

    public void displayProduct()
    {
        Console.WriteLine($"{getId(),-5} {getName(),-15} {getPrice(),-10} {getRemainingStock(),-10} {getCategory(),10}");
    }

    public double getItemTotal(int quantity)
    {
        return getPrice() * quantity;
    }

    public bool hasEnoughStock(int qty)
    {
        return qty <= getRemainingStock();
    }

    public void deductStock(int qty)
    {
        setRemainingStock(getRemainingStock() - qty);
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public int getId()
    {
        return id;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }

    public double getPrice()
    {
        return price;
    }

    public void setRemainingStock(int remainingStock)
    {
        this.remainingStock = remainingStock;
    }

    public int getRemainingStock()
    {
        return remainingStock;
    }

    public void setCategory(string category)
    {
        this.category = category;
    }

    public string getCategory()
    {
        return category;
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            Product[] product = new Product[5];

            product[0] = new Product();
            product[0].setId(1);
            product[0].setName("Mouse");
            product[0].setPrice(350);
            product[0].setRemainingStock(50);
            product[0].setCategory("Accessories");

            product[1] = new Product();
            product[1].setId(2);
            product[1].setName("Keyboard");
            product[1].setPrice(800);
            product[1].setRemainingStock(30);
            product[1].setCategory("Accessories");

            product[2] = new Product();
            product[2].setId(3);
            product[2].setName("Headset");
            product[2].setPrice(1200);
            product[2].setRemainingStock(20);
            product[2].setCategory("Audio");

            product[3] = new Product();
            product[3].setId(4);
            product[3].setName("Flash Drive");
            product[3].setPrice(500);
            product[3].setRemainingStock(15);
            product[3].setCategory("Storage");

            product[4] = new Product();
            product[4].setId(5);
            product[4].setName("Monitor");
            product[4].setPrice(6500);
            product[4].setRemainingStock(10);
            product[4].setCategory("Display");
            
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
        product[i].displayProduct();
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

    if (!selected.hasEnoughStock(qty))
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
            cartSub[i] = product[id - 1].getItemTotal(cartQty[i]);
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
    cartSub[cartCount] = selected.getItemTotal(qty);
    cartCount++;
    }

    selected.deductStock(qty);
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

                    Console.WriteLine($"{product[cartIds[i] - 1].getName()} x{cartQty[i]}");
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
                        product[removeId - 1].setRemainingStock(
                        product[removeId - 1].getRemainingStock() + cartQty[i]
                        );
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
                        found=true;
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
                            if (!product[updateId - 1].hasEnoughStock(difference))
                            {
                                Console.WriteLine("Not enough stock!");
                                break;
                            }

                            product[updateId - 1].deductStock(difference);
                        }
                        else if (difference < 0)
                        {
                            product[updateId - 1].setRemainingStock(
                            product[updateId - 1].getRemainingStock() + Math.Abs(difference)
                            );
                        }

                        cartQty[i] = newQty;
                        cartSub[i] = product[updateId - 1].getItemTotal(newQty);

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
                if (product[j].getId() == cartIds[i])
                {
                    product[j].setRemainingStock(
                    product[j].getRemainingStock() + cartQty[i]
                    );
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
              if(product[i].getName().ToLower().Contains(name))
            {
              product[i].displayProduct();
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
                if(product[i].getCategory().ToLower().Contains(cat))
                {
                product[i].displayProduct();
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
                    total += product[cartIds[i] - 1].getItemTotal(cartQty[i]); 
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
                    
                    Console.WriteLine($"\n Grand Total: PHP {total}");
                    Console.WriteLine($"Discount 10%: PHP {discount}");
                    Console.WriteLine($"Final Total: PHP {finalTotal}");
                    
                    double payment;

                    while (true)
                    {
                        Console.Write("Enter payment: PHP ");
                        
                        if (!double.TryParse(Console.ReadLine(), out payment))
                            continue;
                        
                        if (payment < finalTotal){
                            Console.WriteLine("Insufficient Payment!");
                            continue;
                        }
                        
                        Console.WriteLine($"Change: PHP {payment - finalTotal}");
                        break; 
                    }
                    if (historyIndex < history.Length)
                    {
                        history[historyIndex] = finalTotal;
                        historyIndex++;
                    }

                    string showHistory;

                    Console.Write("\nView order history? (Y/N): ");
                    showHistory = Console.ReadLine().ToUpper().Trim();
                    while (showHistory != "Y" && showHistory != "N")
                    {
                      Console.Write("Type only 'Y' (yes) or 'N' (no): ");
                      showHistory = Console.ReadLine().ToUpper().Trim();
                    }

                    if (showHistory == "Y")
                    {
    
                    Console.WriteLine("\n--- ORDER HISTORY ---");
    
                    for (int i = 0; i < historyIndex; i++)
                    {
        
                   Console.WriteLine($"Receipt #{i + 1:D4}: {history[i]}");
                    }
                    }



                    Console.WriteLine("\n--- LOW STOCK ALERT ---");
                    for (int i = 0; i < product.Length; i++)
                    {
                        if (product[i].getRemainingStock() <= 5)
                        {
                            Console.WriteLine($"{product[i].getName()} low stock: {product[i].getRemainingStock()}");
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
            Console.WriteLine("Thank you for Shopping!");
            
            

        }
    }
}
