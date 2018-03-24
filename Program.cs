namespace AppendixDemo
{
    internal class Program
    {
        private static void Main()
        {
            //var objs = new BaseClass[] 
            //{
            //    new BaseClass(),
            //    new DerivedClass(),
            //    new NextGeneration(),
            //};

            //foreach (var obj in objs)
            //    obj.SomeMethod();

            //new NextGeneration().SomeMethod();

            //123.IncrementAndPrint()
            //    .IncrementAndPrint()
            //    .IncrementAndPrint();

            //var number = 1;

            //var array = new[] { "Hello", "world", "!" };

            //var values = new[] { 1.23m, 2.34m, 3.14m };

            new[] { 1, 2, 3 }
                .Convert(x => (2 * x * x + 1).ToString("D2"))
                .Print();
        }
    }
}
