using CustomAttributes.Attributes;
using System;
using System.Reflection;

namespace CustomAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Wyświetlamy kody atrybutów klasy 
            MemberInfo info = typeof(Sender);
            object[] attributes = info.GetCustomAttributes(true);
            var type1 = info.GetType();

            Console.WriteLine($"Kody atrybutów klasy {nameof(Sender)}:");
            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute);
                DebugInfo code = (DebugInfo)attribute;
                Console.WriteLine("Info: {0}", code.CodeNumber);
            }
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();


            // Wyświetlamy atrybuty metod 
            Type type = typeof(Sender);

            Console.WriteLine($"Atrybuty metod z klasy {nameof(Sender)}:");
            foreach (var method in type.GetMethods())
            { 
                foreach (Attribute a in method.GetCustomAttributes(true))
                {
                    DebugInfo di = a as DebugInfo;
                    if (di != null)
                    {
                        Console.WriteLine("Numer błędu: {0}", di.CodeNumber);
                        Console.WriteLine("Programista: {0}", di.DeveloperName);
                        Console.WriteLine("Przegląd kodu: {0}", di.LastReviewData);
                        Console.WriteLine("Info: {0}", di.Message);
                    }
                }
            }
        }
    }
}
