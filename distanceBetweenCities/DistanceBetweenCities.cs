using System;
using System.Collections.Generic;
using System.Text;

namespace distanceBetweenCities
{
    
    public class DistanceBetweenCities
    {
        public List<Edge> cities = new List<Edge>();
        public List<List<int>> pathes = new List<List<int>>();
        public List<int> сitiesList = new List<int>();
        public List<int> CountDistance(int _vertex1, int _vertex2)
        {
            List<Edge> neighbours = new List<Edge>();
            List<List<int>> pathesBoof = new List<List<int>>();
            foreach (var k in cities)
            {
                if (_vertex1 == k.vertex1)
                {
                    List<int> path = new List<int>();
                    path.Add(_vertex1);
                    path.Add(k.vertex2);
                    pathes.Add(path);
                }
            }
            сitiesList.Remove(_vertex1);
            List<List<int>> oldPathes = new List<List<int>>();
            while (сitiesList.Count > 0)
            {
                pathesBoof.Clear();
                oldPathes.Clear();
                foreach (var p in pathes)
                {

                    foreach (var k in cities)
                    {
                        if (p[p.Count - 1] == k.vertex1)
                        {
                            if (k.vertex2 == p[p.Count - 2]) { }

                            else
                            {
                                List<int> pt = new List<int>();
                                foreach (var c in p)
                                    pt.Add(c);

                                pt.Add(k.vertex2);
                                pathesBoof.Add(pt);
                                oldPathes.Add(p);
                            }
                        }
                    }
                    сitiesList.Remove(p[p.Count - 1]);
                }
                foreach (var k in oldPathes)
                    pathes.Remove(k);
                
                foreach (var k in pathesBoof)
                    pathes.Add(k);
                
                pathesBoof.Clear();

            }
            List<List<int>> ways = new List<List<int>>();
            foreach (var k in pathes)
            {
                foreach (var v in k)
                {
                    if (v == _vertex2)
                    {
                        List<int> w = new List<int>();
                        foreach (var v1 in k)
                        {
                            w.Add(v1);
                            if(v1 == _vertex2)   
                                break;
                        }
                        ways.Add(w);
                    }
                }
            }
            int minDistance = 0;
            List<int> minPath = new List<int>();
            foreach (var w in ways)
            {
                int i = 0;
                int distance = 0;
                while (i < w.Count - 1)
                {
                    foreach (var c in cities)
                    {
                        if (c.vertex1 == w[i] && c.vertex2 == w[i + 1])
                            distance += c.distance; 
                    }
                    i++;
                }
                if (distance < minDistance && minDistance != 0)
                {
                    minDistance = distance;
                    minPath = w;
                }
                if (minDistance == 0)
                {
                    minDistance = distance;
                    minPath = w;
                }
            }
            return minPath;

        }

       
    }
    public class Edge
    {
        public int vertex1;
        public int vertex2;
        public int distance;
        public Edge(int _vertex1, int _vertex2, int _distance)
        {
            vertex1 = _vertex1;
            vertex2 = _vertex2;
            distance = _distance;
        }
    }
}
