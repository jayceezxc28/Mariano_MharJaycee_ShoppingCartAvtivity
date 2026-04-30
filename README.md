QUIZ 2&3
Shopping Cart Program

Mariano, Mhar Jaycee T.

BSIT 1-2

AI Usage in This Project

I used AI in several parts of this project to help me improve and complete my shopping cart system.

I used AI mainly for understanding how to structure the cart system, handle user input validation, and implement features like checking product existence, stock availability, and quantity validation. I also asked for help in improving my logic for updating cart items, calculating subtotals, generating receipts, and applying discounts.

The prompts I asked included questions like how to properly use arrays for a cart system, how to use TryParse for input validation, how to avoid duplicate items in the cart, and how to compute totals and discounts in a structured way.

After using AI, I improved my program by organizing my code better, adding proper validation checks, fixing logic for updating existing cart items, and making the receipt and stock management more accurate and user-friendly.

Enhanced Shopping Cart Program AI Usage Part 2:
I used AI to improve several features in my shopping cart program while still developing, testing, and organizing the final code myself. First, I used AI to learn how to implement search functionality for both product names and categories without requiring exact spelling. This helped me understand how to use partial matching with Contains() and case-insensitive comparisons, making my search system more flexible and user-friendly. Next, I asked AI how to display the current date and time in C# so I could include it in my receipt system and meet the project requirements more effectively.
Prompts/questions I asked:

"How do I improve my cart system with remove, update quantity, and clear cart options?"
"How do I search through my product array by name or category without exact spelling? (*provided my code)"
"How do I print the current date and time in C#?"
"Is there any major bugs or logic issues in my shopping cart system?"

Enhanced Shopping Cart Program Features Part 2:
I improved my original program by turning it from a basic add-to-cart and checkout system into a more complete and interactive store management application. Instead of only letting users select products and immediately proceed to checkout, I added a full menu-driven system where users can now choose to add products, manage their cart, search for products by name, search by category, or checkout. This made the program feel more organized and realistic, similar to how an actual shopping system works.

I upgraded the Add Product feature by improving input validation for product IDs and quantities, making sure users cannot enter invalid values or purchase more than the available stock. I also added a feature where if a product is already in the cart, the program automatically updates its quantity instead of adding a duplicate entry. This made cart handling more efficient and user-friendly.

One of the biggest improvements I made was creating a Cart Management Menu. In my old version, users could only add products and checkout, but now they can view their cart, remove specific items, update item quantities, clear the entire cart with confirmation, or return to the main menu. This gave users much more control over their shopping experience. I also improved stock handling by adding methods like HasEnoughStock() and DeductStock() in my Product class, which helped make stock validation and inventory updates cleaner, easier to manage, and more organized. Stock now adjusts properly whenever items are added, removed, or updated in the cart.

To make the system easier to use, I added search features for both product names and categories using partial and case-insensitive matching. This means users do not need to type exact product names or categories just to find what they are looking for. I also improved the checkout process by preventing empty cart checkouts, calculating the total cost, automatically applying a 10% discount for purchases worth PHP 5000 or more, and showing the final total clearly.

I made the payment process more realistic by adding payment validation, checking if the payment is enough, asking again if it is insufficient, and calculating the user’s change. I also improved the receipt system by adding receipt numbers and displaying the current date and time, making each transaction feel more complete and professional. Another major feature I added was order history, which allows users to view previous transactions during the program session, making the system more advanced than my original version.

Lastly, I added a low-stock alert system that warns users when product stock becomes too low, helping monitor inventory better. I also included a shop again feature so users can continue using the program without restarting it every time. Overall, Part 2 helped me transform my simple shopping cart code into a more realistic, user-friendly, and feature-rich shopping system with better structure, stronger inventory management, and a much better overall experience.
