using System;
using System.Security.Cryptography;

namespace Learn_Oop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hash.Md5("secret");
            Hash.Sha1("secret");
            Hash.Sha256("secret");
            Hash.Sha512("secret");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            //var message = Cipher.Encrypt("Ini tulisan rahasia", "p4$$w0rd");
            //Console.WriteLine(message);
            //var decmessage = Cipher.Decrypt(message, "pa$$w0rd");
            //Console.WriteLine(decmessage);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            var logger = new Log();
            logger.Info("This is an information about something.");
            logger.Error("We can't divide any numbers by zero.");
            logger.Notice("Someone loves your status.");
            logger.Warning("Insufficient funds.");
            logger.Debug("This is debug message.");
            logger.Alert("Achtung! Achtung!");
            logger.Critical("Medic!! We've got critical damages.");
            logger.Emergency("System hung. Contact system administrator immediately!");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Cart cart = new Cart();
            cart.AddItem(1, 30000, 3)
            .AddItem(2,10000)
            .AddItem(3, 5000, 3)
            .RemoveItem(2)
            .AddItem(4, 400, 6)
            .AddDiscount(50);

            Console.WriteLine(Cart.TotalItems());
            Console.WriteLine(Cart.TotalQuantity());
            Console.WriteLine(Cart.TotalPrice());
            Cart.ShowAllItems();
            Cart.Checkout();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();


        }
    }
}
