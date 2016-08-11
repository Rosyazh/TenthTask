using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Practice: Develop custom class Crew which implements IList<Worker>, +
Worker is a custom class containing personal info and his working position.
Also implement EqualityComparer to sort workers by their working position.
*/

namespace TenthTask
{
    class Crew: IList<Worker>
    {
        List<Worker> contents = new List<Worker>();

        public Worker this[int index]
        {
            get
            {
                return contents[index];
            }

            set
            {
                contents[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return contents.Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Worker item)
        {
            contents.Add(item);
        }

        public void Clear()
        {
            contents.Clear();
        }

        public bool Contains(Worker item)
        {
            return contents.Contains(item);
        }

        public void CopyTo(Worker[] array, int arrayIndex)
        {
            contents.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        public int IndexOf(Worker item)
        {
            return contents.IndexOf(item);
        }

        public void Insert(int index, Worker item)
        {
            contents.Insert(index, item);
        }

        public bool Remove(Worker item)
        {
            return contents.Remove(item);
        }

        public void RemoveAt(int index)
        {
            contents.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Surname, Position);
        }
    }
    
    class PositionComparer : EqualityComparer<Worker>
    {
        public override bool Equals(Worker x, Worker y)
        {
            return x.Position == y.Position; 
        }
        public override int GetHashCode(Worker obj)
        {
            return (obj.Position).GetHashCode();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {      
            Crew cr = new Crew();
            cr.Add(new Worker { Name = "Petr", Surname = "Ivanov", Position = "Director" });
            cr.Add(new Worker { Name = "Vika", Surname = "Klichko", Position = "Manager" });
            cr.Add(new Worker { Name = "Kolya", Surname = "Vikulov", Position = "Bookkeeper" });
            /*
            Dictionary<int, string> pos = new Dictionary<int, string>();
            pos[1] = "Director";
            pos[2] = "Manager";
            pos[3] = "Bookkeeper";
            */
            var eqComparer = new PositionComparer();
            var d = new Dictionary<Worker, string>(eqComparer);
            d[cr[0]] = "Director";
            d[cr[1]] = "Manager";
            d[cr[2]] = "Bookkeeper";

            foreach (Worker c in d.Keys)
            {
                Console.WriteLine(c.ToString());
            }

            /*
            foreach (Worker rab in cr)
            {
                Console.WriteLine("{0} {1} {2}", rab.Name.PadRight(15), rab.Surname.PadRight(15), rab.Position.ToString().PadRight(10));
            }*/
        }
    }
}
