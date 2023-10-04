namespace ConcurrentCollectionsPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*ConcurrentStackPractice obj = new ConcurrentStackPractice();
            obj.Test();
            obj.TestCheck();
            obj.RetrieveTest();*/
            //ConcurrentBagPractice obj=new ConcurrentBagPractice();
            //obj.BagTest();
            //Console.WriteLine("***************************");
            //obj.BagTestNew();
            //Console.WriteLine("***************************");
            //obj.BagArray();
            //Console.WriteLine("***************************");
            //obj.BagToArray();
            BlockingCollectionPractice obj= new BlockingCollectionPractice();
            obj.implement();
            Console.WriteLine("************");
            obj.eliminate();

        }
    }
}