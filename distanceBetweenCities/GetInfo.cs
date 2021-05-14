using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace distanceBetweenCities
{
    class GetInfo
    {
        List<string> allLines = new List<string>();
        public List<string> firstVertex = new List<string>();
        public List<string> secondVertex = new List<string>();
        public List<string> distance = new List<string>();
        public List<string> cities = new List<string>();

        public void ReadFile()
        {
            string input = "map.txt";
            StreamReader read = new StreamReader(input);
            using (read)
            {
                string s;
                do
                {
                    s = read.ReadLine();
                    allLines.Add(s);
                }

                while (s != null);
                allLines.RemoveAt(allLines.Count - 1);
            }
            read.Close();
        }


        public void Parsing()
        {
            foreach (var s in allLines)
            {
                string[] ff = s.Split(';');
                firstVertex.Add(ff[0]);
                secondVertex.Add(ff[1]);
                distance.Add(ff[2]);
            }
        }

        public void Transfer(List<Edge>_edges, List<int>_cities)
        {
            cities.Clear();
            for(int i = 0; i < firstVertex.Count; i++)
            {
                bool flag1 = false;
                bool flag2 = false;
                foreach(var c in cities)
                {
                    if (c == firstVertex[i])
                        flag1 = true;

                    if(c == secondVertex[i])
                        flag2 = true;
                  
                }

                if (!flag1)
                    cities.Add(firstVertex[i]);

                if (!flag2)
                    cities.Add(secondVertex[i]);
                  
            }


            for(int i = 0; i < firstVertex.Count; i++)
            {
                int v1 = 0;
                int v2 = 0;
                for (int k = 0; k < cities.Count; k++)
                {
                    if (firstVertex[i] == cities[k])
                        v1 = k;

                    if (secondVertex[i] == cities[k])
                        v2 = k;
                }
                Edge edge = new Edge(v1, v2, Convert.ToInt32(distance[i]));
                _edges.Add(edge);
            }


            for(int i = 0; i < cities.Count; i++)
                _cities.Add(i); 
        }
    }
}
