using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GetPropertyTest
{

    class Program
    {
        public string Свойство_С_Киррилицей { get; set; }


        static void Main(string[] args)
        {
            Console.WriteLine("Press <Enter> or attach debugger.");
            Console.ReadLine();
            var result = typeof(Program).GetProperty(nameof(Свойство_С_Киррилицей),
                BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            Console.WriteLine(
                "typeof(Program).GetProperty(nameof(Свойство_С_Киррилицей),BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public)==" +
                result?.ToString());
            result = typeof(Program).GetProperty(nameof(Свойство_С_Киррилицей),
                BindingFlags.Instance | BindingFlags.Public);
            Console.WriteLine(
                "typeof(Program).GetProperty(nameof(Свойство_С_Киррилицей),BindingFlags.Instance | BindingFlags.Public)==" +
                result);

            var expr = Expression.New(typeof(Program).GetConstructor(new Type[0]));
            var exprProp = Expression.Property(expr, nameof(Свойство_С_Киррилицей));

            Console.WriteLine("Property expression was sucsessfully created.");
        }
    }
}
