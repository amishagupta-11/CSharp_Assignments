using System;
using System.Collections.Concurrent;


namespace ConcurrentCollectionsPractice
{
    public class ConcurrentStackPractice
    {           
        public void Test()
        {
            ConcurrentStack<string> cStack = new ConcurrentStack<string>(); 
            //Adding elements in ConcurrentStack.
            cStack.Push("India");
            cStack.Push("USA");
            cStack.Push("Mauritius");
            cStack.Push("Bali");
            Console.WriteLine("ConcurrentStack Elements after push method:");
            foreach(var item in cStack)
            {
                Console.WriteLine(item);
            }
            string[] countryArray = { "UK", "Australia" };
            cStack.PushRange(countryArray);
            Console.WriteLine("\nConcurrentStack elements after pushRange method:");
            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*********************");
        }

        public void TestCheck()
        {
            //Removing Elements 
            ConcurrentStack<string> cStack= new ConcurrentStack<string>();
            cStack.Push("India");
            cStack.Push("USA");
            cStack.Push("UK");
            cStack.Push("Canada");
            cStack.Push("Japan");
            cStack.Push("Brazil");

            Console.WriteLine("\nAll ConcurrentStack Elements:");
            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }

            bool isRemoved = cStack.TryPop(out string result);
            Console.WriteLine($"\nTryPop Returns: {isRemoved}");
            Console.WriteLine($"\n TryPop result value: {result}");
            Console.WriteLine("\nConcurrentStack Elements After TryPop Method");
            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }
            string[] arr = { "UK", "NZ", "Brazil" };
            int totalCountries = cStack.TryPopRange(arr);
            Console.WriteLine($"\nTryPopRange Return : {totalCountries}");
            Console.WriteLine("Elements Removed By TryPopRange Method");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nConcurrentStack Elements after TryPopRange Method");
            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************");
        }
        public void RetrieveTest()
        {
            ConcurrentStack<string> cStack = new ConcurrentStack<string>();
            //Adding Element using Push Method of ConcurrentStack Class
            cStack.Push("India");
            cStack.Push("USA");
            cStack.Push("UK");
            cStack.Push("Canada");
            cStack.Push("Japan");
            //Accesing all the Elements of ConcurrentStack using For Each Loop
            Console.WriteLine($"ConcurrentStack Elements Count: {cStack.Count}");
            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }
            // Removing and Returning the Top Element from ConcurrentStack using TryPop method
            bool IsRemoved = cStack.TryPop(out string Result1);
            Console.WriteLine($"\nTryPop Return : {IsRemoved}");
            Console.WriteLine($"TryPop Result Value : {Result1}");
            //Printing Elements After Removing the Top Element
            Console.WriteLine($"\nConcurrentStack Elements After TryPop: Count {cStack.Count}");
            foreach (var element in cStack)
            {
                Console.WriteLine($"{element} ");
            }
            //Returning the Top Element from ConcurrentStack using TryPeek method
            bool IsPeeked = cStack.TryPeek(out string Result2);
            Console.WriteLine($"\nTryPeek Return : {IsPeeked}");
            Console.WriteLine($"TryPeek Result Value : {Result2}");
            //Printing Elements After TryPeek the Top Element
            Console.WriteLine($"\nConcurrentStack Elements After TryPeek: Count {cStack.Count}");
            foreach (var element in cStack)
            {
                Console.WriteLine($"{element} ");
            }
           
        }
    }
}

        
           
 


