using System.Security.Principal;

namespace forClasses
{
    public class Product
    {
            public string Name { get; set; }
            public double Price { get; private set; }
            public int Quantity { get; private set; }

            public double Weight { get;  set;}

            public Product(string name, double price, int quantity = 0, double weight = 0)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
                Weight = weight;
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Product`s name: {Name}\nPrice: {Price}$\nQuantity: {Quantity}\nWeight: {Weight}kg");
                Console.WriteLine(new string('-', 30));
            }

            public void AddItem(int addCount)
            {
                this.Quantity += addCount;
            }
            
            public void AddMultipleItems(params int[] quantities)
            {
                foreach (var item in quantities)
                {
                    this.Quantity += item;
                }
            }
            public void SellItem(int removeCount)
            {
                if (this.Quantity - removeCount < 0)
                {
                    Console.WriteLine($"Invaled operation: Only {this.Quantity} {this.Name} in stock");
                    return;
                }

                if (removeCount > 5)
                {
                    double finalPrice = this.DiscountCounter(10);
                    Console.WriteLine($"The customer has  10% discount, couse he/she ordered more than 5 item," +
                                      $" he/she need to pay only {finalPrice}$");
                    
                }
                this.Quantity -= removeCount;
            }

            public double ChangePrice(double newPrice)
            {
                return this.Price = newPrice;
            }

            public bool TryGetProduct(string productName, Product[] products, out Product foundItem)
            {
                foreach (var item in products)
                {
                    if (productName.ToLower() == item.Name.ToLower())
                    {
                        foundItem = item;
                        return true;
                    }
                }

                foundItem = null;
                return false;
                int a = 1;
                
            }
        
        
        }
    
}

