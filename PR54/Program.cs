﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR54
{
    //Интерфейс реализующий магию
    interface ISpell
    {
        string Use();
        int Mana { get; set; }
        string Name { get; set; }
    }

    //Класс заклинания с интерферсом
    class Spell : ISpell
    {
        //Инициализация свойств
        public int Mana { get;  set; }
        private string Effect { get; set; }
        public string Name { get;  set; }

        //Конструктор, принимающий значения заклинания
        public Spell(int mana, string effect, string name)
        {
            Mana = mana;
            Effect = effect;
            Name = name;
        }

        //Метод использования заклинания, вывод эффект от заклинания
        public string Use()
        {
            return Effect;
        }
    }

    //Класс со свойствами мага
    class Magician
    {
        //Свойства класса Маг
        public string Name { get; private set; }
        public int Mana { get; private set; }

        //Конструтор, принимающий значения мага
        public Magician(string name, int mana)
        {
            Name = name;
            Mana = mana;
        }

        //Колдонуть с проверкой маны
        public void CastSpell(ISpell spell)
        {
            if (Mana >= spell.Mana)
            {
                Console.WriteLine($"{Name} колдует! {spell.Use()}");
                Mana -= spell.Mana;
            }
            else
            {
                Console.WriteLine($"Для использования \"{spell.Name}\" не хватает {spell.Mana - Mana} единиц маны");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Создание объектов заклинаний
            ISpell alohomora = new Spell(60, "Замок открывается!", "Алохомора");
            ISpell vingardiumLeviosa = new Spell(60, "Предмет поднимается в воздух!", "Вингардиум-Левиоса");

            //Создание объекта Маг
            Magician garryPotter = new Magician("Гарри Поттер", 100);

            //Использование заклятий
            garryPotter.CastSpell(alohomora);
            garryPotter.CastSpell(vingardiumLeviosa);

            Console.ReadKey(true);
        }
    }
}
