using System;

namespace AppendixDemo
{
    public class NextGeneration : DerivedClass
    {
        public new string value = "Hello world!";

        public new void SomeMethod() => 
            Console.WriteLine($"new method! value is --> {value}");
    }
}