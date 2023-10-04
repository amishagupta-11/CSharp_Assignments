using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using System.Security.Claims;

namespace ConcurrentCollectionsPractice
{
    public class ConcurrentBagPractice
    {
        public void BagTest()
        {
            //to add elements in bag.
            ConcurrentBag<string> cBag = new ConcurrentBag<string>();
            cBag.Add("Momos");
            cBag.Add("Pasta");
            cBag.Add("Pizza");
            cBag.Add("Noodles");
            Console.WriteLine("ConcurrentBag elements: ");
            foreach (var item in cBag)
            {
                Console.WriteLine(item);
            }
            string[] arr = { "Idly", "Wada", "Sambar", "Dosa" };
            ConcurrentBag<string> cBagN = new ConcurrentBag<string>(arr);
            Console.WriteLine("\nConcurrentBag elements after passing array values: ");
            foreach (var item in cBagN)
            {
                Console.WriteLine(item);
            }
        }

        public void BagTestNew()
        {
            ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>
            {
                "India",
                "USA",
                "UK",
                "Canada",
                "Japan"
            };
            //Printing Elements After TryPeek the Element
            Console.WriteLine($"ConcurrentBag All Elements: Count {concurrentBag.Count}");
            foreach (var element in concurrentBag)
            {
                Console.WriteLine($"{element} ");
            }

            bool IsRemoved = concurrentBag.TryTake(out string Result1);
            Console.WriteLine($"\nTryTake Return : {IsRemoved}");
            Console.WriteLine($"TryTake Result Value : {Result1}");
            
            Console.WriteLine($"\nConcurrentBag Elements After TryTake: Count {concurrentBag.Count}");
            foreach (var element in concurrentBag)
            {
                Console.WriteLine($"{element} ");
            }
            bool IsPeeked = concurrentBag.TryPeek(out string Result2);
            Console.WriteLine($"\nTryPeek Return : {IsPeeked}");
            Console.WriteLine($"TryPeek Result Value : {Result2}");
           
            Console.WriteLine($"\nConcurrentBag Elements After TryPeek: Count {concurrentBag.Count}");
            foreach (var element in concurrentBag)
            {
                Console.WriteLine($"{element} ");
            }

        }
        public void BagArray()
        {
            //Creating ConcurrentBag collection and Initialize with Collection Initializer
            ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>
            {
                "India",
                "USA",
                "UK",
                "Canada",
                "Japan"
            };
            
            Console.WriteLine($"ConcurrentBag All Elements: Count {concurrentBag.Count}");
            foreach (var element in concurrentBag)
            {
                Console.WriteLine($"{element} ");
            }
            
            string[] concurrentBagCopy = new string[5];
            concurrentBag.CopyTo(concurrentBagCopy, 0);
            Console.WriteLine("\nConcurrentBag Copy Array Elements:");
            foreach (var item in concurrentBagCopy)
            {
                Console.WriteLine(item);
            }
        }

        public void BagToArray()
        {
            //Creating ConcurrentBag collection and Initialize with Collection Initializer
            ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>
            {
                "India",
                "USA",
                "UK",
                "Canada"
            };
             Console.WriteLine($"ConcurrentBag Elements");
            foreach (var element in concurrentBag)
            {
                Console.WriteLine($"{element} ");
            }
            
            string[] concurrentBagArray = concurrentBag.ToArray();
            Console.WriteLine("\nConcurrentBag Array Elements:");
            foreach (var item in concurrentBagArray)
            {
                Console.WriteLine(item);
            }
        }
            
    }
}

   
   
        
       

