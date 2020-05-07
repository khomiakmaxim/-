using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stoiko2
{
    class HouseCollection
    {
        private List<House> collection;
        public string FilePath { get; private set; }

        public HouseCollection(string filePath)
        {
            collection = new List<House>();
            FilePath = filePath;
        }

        public override string ToString()
        {
            string repr = "";

            foreach (House item in collection)
            {
                repr += item.ToString() + '\n';
            }

            return repr;
        }

        public void Add(House h)
        {
            collection.Add(new House(h));
            UpdateFile();
        }

        public List<House> Find(string id)
        { 
            List<House> hLst = new List<House>();

            foreach (House h in collection)
            {
                if (h.ToString().ToLower().Contains(id.ToLower()))
                {
                    hLst.Add(h);
                }
            }

            return hLst;
        }

        public void Update(string id, House newHouse)
        {
            foreach (House h in collection)
            {
                if (h.ToString().Contains(id.ToLower()))
                {
                    int index = collection.IndexOf(h);

                    collection.Insert(index, new House(newHouse));
                    collection.Remove(h);

                    break;
                }
            }

            UpdateFile();
        }

        public void Remove(string id)
        {
            List<House> death = new List<House>();

            foreach (House h in collection)
            { 
                if(h.ToString().Contains(id.ToLower()))
                {
                    death.Add(h);
                }
            }

            foreach (House item in death)
            {
                collection.Remove(item);
            }

            UpdateFile();
        }

        public void Sort(string crit)
        {
            try
            {
                collection = collection.OrderBy(p => p.GetType().GetProperty(crit).GetValue(p)).ToList();
            }
            catch
            {
                Console.WriteLine("invalid input");
                Console.ReadKey();
            }

            UpdateFile();
        }

        public void ReadFromFile()
        {
            string[] houseRepr = File.ReadAllLines(FilePath);

            foreach (string item in houseRepr)
            {
                collection.Add(House.Parse(item));
            }

            UpdateFile();
        }

        public void UpdateFile()
        {
            File.WriteAllText(FilePath, ToString());
        }
    }
}
