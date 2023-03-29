using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Damage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float health;
            int armor, damage;
            int precentConvert = 100;

            Console.Write("Введите кол-во здоровья:");
            health = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во брони:");
            armor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во урона:");
            damage = Convert.ToInt32(Console.ReadLine());

            health -= Convert.ToSingle(damage) / precentConvert * armor;

            Console.WriteLine($"Вам нанесли {damage} урона. У вас осталось {health} здоровья");

            Console.ReadKey();
        }
    }
}

