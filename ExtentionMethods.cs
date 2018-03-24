using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppendixDemo
{
    public static class ExtentionMethods
    {
        public static StringBuilder AppendFormatLine(this StringBuilder sb, 
            string format, params object[] args) => 
            sb.AppendFormat(format, args).AppendLine();

        // strange solution
        public static void Print(this int value) =>
            Console.WriteLine(value);

        public static int IncrementAndPrint(this int value)
        {
            value++;
            Console.WriteLine(value);
            return value;
        }

        public static void Print<T>(this IEnumerable<T> collection, string collectionName = null) =>
            Console.WriteLine($"{collectionName ?? "unnamed"} = {{{string.Join(", ", collection)}}};");

        public static IEnumerable<TOut> Generator<TOut, TIn>(this IEnumerable<TIn> collection)
            where TIn : class
            where TOut : class, new()
        {
            var type = typeof(TOut);
            //var ctor = type.GetConstructor(new Type[] { typeof(TIn) });
            var ctor = type.GetConstructor(
                bindingAttr: BindingFlags.NonPublic | BindingFlags.Public, 
                binder: null, 
                types: new Type[] { typeof(TIn) }, 
                modifiers: null);
            if (ctor == null)
                return Enumerable.Empty<TOut>();

            //var result = new List<TOut>();
            //foreach (var item in collection)
            //    result.Add(ctor.Invoke(new object[] { item }) as TOut);
            //return result;

            return collection
                .Select(item => ctor.Invoke(new object[] { item }))
                .OfType<TOut>();
        }


        // Generator<string, int>
        public static IEnumerable<TOut> Convert<TOut, TIn>(
            this IEnumerable<TIn> collection, 
            Func<TIn, TOut> convertor)
            => collection.Select(convertor);
    }
}