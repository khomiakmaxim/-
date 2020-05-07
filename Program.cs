using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stoiko2
{
	class Program
	{
		static void Menu()
		{
			Console.WriteLine("Read:\t1");
			Console.WriteLine("Add:\t2");
			Console.WriteLine("Sort:\t3");
			Console.WriteLine("Remove:\t4");
			Console.WriteLine("Find:\t5");
			Console.WriteLine("Update:\t6");
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Filename: ");
			string filename = Validation.ValidationFile(Console.ReadLine());
			Collection<House> hCollection = new Collection<House>(@"C:\Users\Максим\source\repos\Stoiko2\" + filename);

			while (true)
			{
				Menu();
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						hCollection.ReadFromFile();
						break;

					case "2":
						hCollection.Add(House.Parse(Console.ReadLine()));
						break;

					case "3":
						Console.WriteLine("Criteria: ");
						string crit = Console.ReadLine();
						hCollection.Sort(crit);
						break;

					case "4":
						Console.WriteLine("id: ");
						string crit2 = Console.ReadLine();
						hCollection.Remove(crit2);
						break;

					case "5":
						Console.WriteLine("id: ");
						string crit3 = Console.ReadLine();
						List<House> result = hCollection.Find(crit3);

						foreach (House item in result)
						{
							Console.WriteLine(item.ToString());
						}

						Console.ReadKey();
						break;

					case "6":
						Console.WriteLine("id: ");
						string crit4 = Console.ReadLine();
						House newHum = House.Parse(Console.ReadLine());
						hCollection.Update(crit4, newHum);
						break;

					default:
						break;
				}

				Console.Clear();
				Console.WriteLine(hCollection.ToString());

			}

		}

	}
}
