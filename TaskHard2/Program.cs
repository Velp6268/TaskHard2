using System;
using System.Collections.Immutable;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using TaskHard2;

namespace TaskHard2
{
    internal class Program
    {
        public static City[] DbCities()
        {
            // Обьявление городов и переменных
            City[] cities = new City[] {

                    new City  (1, "Берлин", 399, 175, 1.13),
                    new City  (2, "Прага", 300, 270),
                    new City  (3, "Париж", 350, 220),
                    new City  (4, "Рига", 250, 170),
                    new City  (5, "Лондон", 390, 270),
                    new City  (6, "Ватикан", 500, 350),
                    new City  (7, "Палермо", 230, 150),
                    new City  (8, "Варшава", 300, 190),
                    new City  (9, "Кишинев", 215, 110),
                    new City  (10, "Мадрид", 260, 190),
                    new City  (11, "Будапешт", 269, 230)
                };
            return cities;
        }
        //Выбираем города в которые хотим отправиться, а так же указываем с кого города начинаем путешествие
        public static City[] SelectCity(City[] cities, int countSelectedCity)
        {
            City[] select = new City[countSelectedCity];

            int temp = 0;
            bool isException = false;

            for (int i = 1; i <= countSelectedCity; i++)
            {
                do
                {
                    if (i == 1)
                    {
                        Console.Write($"Введите номер города из которого начнете путешествие: ");
                    }
                    else
                    {
                        Console.Write($"Введите номер {i - 1} города: ");
                    }

                    try
                    {
                        temp = Convert.ToInt32(Console.ReadLine());
                        select[i - 1] = cities[temp];
                        isException = false;
                    }
                    catch
                    {
                        Console.WriteLine("Введи правильный номер города");
                        isException = true;
                    }
                } while (isException);
            }
            return select;
        }

        static void Main(string[] args)
        {
            City[] cities = DbCities();

            Console.Write("Введите кол-во городов (до 3): ");
            int countSelectedCity = Convert.ToInt32(Console.ReadLine());
            countSelectedCity += 1;

            City[] arr = new City[countSelectedCity];

            Console.Write("Введите бюджет:  ");
            int budget = Convert.ToInt32(Console.ReadLine());

            PrintCity(cities);

            City[] selectCity = SelectCity(cities, countSelectedCity);

            double result = 0;

            for (int i = 0; i < selectCity.Length - 1; i++)
            {
                double price = 0;
                int temp = selectCity.Length;
                if (temp == selectCity.Length)
                {
                    price = CalcPrice(price, cities, selectCity[i], selectCity[i + 1]);
                    
                    if (selectCity[i].id == 6) price *= 1.5;
                    result += price;
                }

            }

            Console.WriteLine($"Стоимость поездки: {result}");

            if (result> budget)
                Console.WriteLine("Не достаточно средств для путешествия");

            Console.ReadLine();
        }
        //Метод в котором прописанны 10 доп. условий
        static double CalcPrice(double price, City[] cities, City firstCity, City secondCity)
        {
            price += secondCity.price;

            if (firstCity.id == 10)
            {
                price += cities[2].transit;
            }

            if (secondCity.id == 10)
            {
                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[9].price * 1.04 - cities[9].price;
                }
            }

            if (firstCity.id == 9)
            {
                price += cities[10].transit;

            }

            if (firstCity.id == 5)
            {
                price += cities[2].price;
            }

            if (firstCity.id == 4)
            {
                price += cities[7].transit;
            }

            if (secondCity.id == 1)
            {
                price *= cities[0].nalog;

                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[0].price * 1.04 - cities[0].price;
                }
            }

            if (secondCity.id == 7)
            {
                if (firstCity.id == 5) price += cities[6].price * 1.07 - cities[6].price;
                if (firstCity.id == 9) price += cities[6].price * 1.11 - cities[6].price;

                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[6].price * 1.04 - cities[6].price;
                }
            }

            if (secondCity.id == 4)
            {
                if (firstCity.id == 3) price += cities[3].price * 1.09 - cities[3].price;

                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[3].price * 1.04 - cities[3].price;
                }
            }

            if (secondCity.id == 3)
            {
                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[2].price * 1.04 - cities[2].price;
                }
            }

            if (secondCity.id == 8)
            {
                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[7].price * 1.04 - cities[7].price;
                }
            }

            if (secondCity.id == 11)
            {
                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[10].price * 1.04 - cities[10].price;
                }
            }


            if (secondCity.id == 2)
            {
                if (firstCity.id == 6 || firstCity.id == 5 || firstCity.id == 9)
                {
                    price += cities[1].price * 1.04 - cities[1].price;
                }
            }


            if (firstCity.id == 7 && secondCity.id == 4 || firstCity.id == 4 && secondCity.id == 7)
            {
                price += cities[7].transit + cities[0].transit;
            }

            return price;
        }

        // Вывод городов 
        static void PrintCity(City[] cities)
        {
            for (int i = 0; i < cities.Length; i++)
                Console.WriteLine($"{i} - {cities[i].name}");
        }
    }
}