using System;

namespace AppendixDemo
{
    public class DerivedClass : BaseClass
    {
        public sealed override void SomeMethod()
        {
            Console.WriteLine($"{GetType().FullName} begin");
            base.SomeMethod();
            Console.WriteLine($"{GetType().FullName} end");
        }
    }
}