using System;

namespace AppendixDemo
{
    public class BaseClass
    {
        public int value = 42;

        public virtual void SomeMethod() => 
            Console.WriteLine($"{GetType().FullName}.SomeMethod() invoked. Value is {value}.");
    }
}