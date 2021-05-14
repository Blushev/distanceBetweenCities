using System;
using System.Collections.Generic;

namespace distanceBetweenCities
{
    class Program
    {
        static void Main(string[] args)
        {
            DistanceBetweenCities f = new DistanceBetweenCities();
            GetInfo F = new GetInfo();
            F.ReadFile();
            F.Parsing();
            F.Transfer(f.cities, f.сitiesList);
            foreach(var s in F.cities)
            {
                Console.WriteLine(s);
            }
            int vertex1 = 0;
            int vertex2 = 0;
            string userfisrtCities = Console.ReadLine();
            string usersecondCities = Console.ReadLine();


            for (int k = 0; k < F.cities.Count; k++)
            {
                if (userfisrtCities == F.cities[k])
                    vertex1 = k;

                if (usersecondCities == F.cities[k])
                    vertex2 = k;
            }

            f.CountDistance(vertex1, vertex2);
            List<int> min;
            min = new List<int>();
            min = f.CountDistance(vertex1, vertex2);
            foreach (var u in min)
                Console.WriteLine(u);


            Console.ReadKey();
        



        }
    }
}
