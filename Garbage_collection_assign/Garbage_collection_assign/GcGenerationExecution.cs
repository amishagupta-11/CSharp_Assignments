using System;
using System.Security.Cryptography;

namespace GCSystem
{
    /// <summary>
    /// Adding class to check execution time taken by objects to move between generations 
    /// </summary>
   public class GcGenerationExecution
    {        
        /// <summary>
        /// method to find the time taken by objects to move between generations
        /// </summary>
        /// <param name="obj"></param>
        public void ExecutionTime(object obj)
        {
            int count = 0;
            int countV = 0;
            //using DateTime function to start the timer when the objects are in gen 0 
            //finding the generation of an obj using garbageCOllection method i.e..,GC.GetGeneration()
            DateTime start = DateTime.Now;
            while (GC.GetGeneration(obj)==0 )
            {
                //creation of multiple objects and then incrementing the counter after every iteration 
                GcGenerationExecution firstObj = new GcGenerationExecution();
                GcGenerationExecution secondObj= new GcGenerationExecution();
                GcGenerationExecution thirdObj = new GcGenerationExecution();
                GcGenerationExecution fourthObj = new GcGenerationExecution();
                count++;
            }
            //stopping the timer after all the objects have moved from gen0 to gen 1
            DateTime end = DateTime.Now;
            //calculating time taken 
            TimeSpan ts = end-start;           
            Console.WriteLine("Execution time in ms:{0}", ts.TotalMilliseconds+ " ms ");
            Console.WriteLine("Objects executed :"+count);            
            //starting the timer to check time taken by obj to move from gen 0 to gen 1
            DateTime startIt = DateTime.Now;
            while (GC.GetGeneration(obj)==1)
            {
                //creation of multiple objects while the first object is in first generation
                GcGenerationExecution firstObj = new GcGenerationExecution();
                GcGenerationExecution secondObj = new GcGenerationExecution();
                GcGenerationExecution thirdObj = new GcGenerationExecution();
                GcGenerationExecution fourthObj = new GcGenerationExecution();
                //incrementing counter variable
                countV++;
            }
            Console.WriteLine("Address after first Generation:"+obj.GetHashCode());
            //stopping the timer 
            DateTime endIT = DateTime.Now;
            //calculating the time span 
            TimeSpan tsIt = endIT-startIt;
            //displaying the execution time ,total iterations and current generation when objects have moved from gen 1 to gen 2
            Console.WriteLine("Execution time in ms :{0}", tsIt.TotalMilliseconds+ " ms ");
            Console.WriteLine("Objects Executed: "+countV);
            Console.WriteLine("Generation after second loop:"+ GC.GetGeneration(obj));
        }
      
    }
}

