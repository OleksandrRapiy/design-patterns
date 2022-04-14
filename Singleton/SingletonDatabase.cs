using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }
    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase()
        {
            capitals = File.ReadAllLines(
                    Path.Combine(
                            new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,
                            "capitals.txt")
                ).Batch(2).ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1))
                );
        }

        private static SingletonDatabase instace => new SingletonDatabase();
        public static SingletonDatabase Instace => instace;


        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
