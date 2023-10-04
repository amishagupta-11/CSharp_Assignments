using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConcurrentCollectionsPractice
{
    public class BlockingCollectionPractice
    {
        public void implement()
        {
            BlockingCollection<int> bCol = new BlockingCollection<int>(4);
            bCol.Add(05);
            bCol.Add(11);
            bCol.Add(12);
            bCol.Add(14);
            if (bCol.TryAdd(27))
            {
                Console.WriteLine("Item 27 Added!");
            }
            else
            {
                Console.WriteLine("Item 27 not added!");
            }
            Console.WriteLine("\nAll BlockingCollection elements:");
            foreach (int i in bCol)
            {
                Console.WriteLine(i);
            }
        }

        public void eliminate()
        {
            BlockingCollection<int> bCollect = new BlockingCollection<int>()
            { 
              10,
              20
            };
            Console.WriteLine("All BlockingCollection elements: ");
            foreach (int i in bCollect)
            {
                Console.WriteLine(i);
            }
            int res = bCollect.Take();
            Console.WriteLine("Item removed by take method:"+res);
            if(bCollect.TryTake(out int result, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("Item removed by TryTake method:"+result);
            }
            else
            {
                Console.WriteLine("No item was removed");
            }
            if (bCollect.TryTake(out int result1, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("Item removed by TryTake method:"+result1);
            }
            else
            {
                Console.WriteLine("No item was removed");
            }
        }
    }

}
