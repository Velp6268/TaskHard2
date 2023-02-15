using System;

namespace TaskHard2
{
    class Program
    {
        static void Main(string[] args)
        {
            City[] cities = GetCities();

            Console.Write("Введите кол-во городов (до 4): ");
            int countSelectedCity = Convert.ToInt32(Console.ReadLine());

            City[] arr = new City[countSelectedCity];

            Console.Write("Введите бюджет:  ");
            int budget = Convert.ToInt32(Console.ReadLine());

            PrintCity(cities);

            City[] selectCity = SelectCity(cities, countSelectedCity);

            double price = 0;



            for (int i = 0; i < selectCity.Length - 1; i++)
            {
                int temp = selectCity.Length;
                if (temp == selectCity.Length)
                {
                    price += CalcPrice(price, cities, selectCity[i], selectCity[i + 1]);
                    if (selectCity[i].id == 3) price *= 1.5;
                }

            }

            Console.WriteLine($"Стоимость поездки: {price}");

            if (price > budget)
                Console.WriteLine("Дорога");

            Console.ReadLine();
        }

        static double CalcPrice(double price, City[] cities, City firstCity, City secondCity)
        {
            price += secondCity.price;

            if (secondCity.id == 1)
            {
                price += cities[1].price * cities[1].tax - cities[1].price;
                price += cities[1].price * 1.04 - cities[1].price;
            }

            if (secondCity.id == 2)
                price += cities[2].price * 1.04 - cities[2].price;

            if (secondCity.id == 3)
                price += cities[3].price * 1.04 - cities[3].price;

            if (secondCity.id == 4)
            {
                price += cities[8].transit;
                if (firstCity.id == 3) price += cities[4].price * 1.09 - cities[4].price;
                price += cities[4].price * 1.04 - cities[4].price;
                if (firstCity.id == 7) price += cities[8].transit + cities[1].transit;
            }

            if (secondCity.id == 5)
                price += cities[3].price;


            if (secondCity.id == 7)
            {
                if (firstCity.id == 5) price += cities[7].price * 1.07 - cities[7].price;
                if (firstCity.id == 9) price += cities[7].price * 1.11 - cities[7].price;
                price += cities[7].price * 1.04 - cities[7].price;
                if (firstCity.id == 4) price += cities[8].transit + cities[1].transit;
            }

            if (secondCity.id == 8)
                price += cities[8].price * 1.04 - cities[8].price;

            if (secondCity.id == 9)
                price += cities[11].transit;

            if (secondCity.id == 10)
            {
                price += cities[3].transit;
                price += cities[10].price * 1.04 - cities[10].price;
            }

            if (secondCity.id == 11)
                price += cities[11].price * 1.04 - cities[11].price;



            return price;
        }


        // вывод городов 
        static void PrintCity(City[] cities)
        {
            for (int i = 0; i < cities.Length; i++)
                Console.WriteLine($"{i} - {cities[i].name}");

        }
    }
}