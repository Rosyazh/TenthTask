using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Practice: Develop custom class Crew which implements IList<Worker>, 
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

        public void Sort()
        {
            contents.Sort(new EqualityComparer());
        }
    }

    class Worker/*: IComparable<Worker>*/
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position WorkPosition { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Surname, WorkPosition);
        }
        /*
        public int CompareTo(Worker other)
        {
            if (Equals(other)) return 0;
            return WorkPosition.CompareTo(other.WorkPosition);
        }*/
    }

    class EqualityComparer : IComparer<Worker>
    {
        public int Compare(Worker x, Worker y)
        {
            return x.WorkPosition.CompareTo(y.WorkPosition);
        }
    }

    enum Position
    {
        Director = 1,
        Manager = 2,
        Bookkeeper = 3
    }

    /*
    class PositionComparer : EqualityComparer<Worker>
    {
        public override bool Equals(Worker x, Worker y)
        {
            return x.WorkPosition == y.WorkPosition;
        }

        public override int GetHashCode(Worker obj)
        {
            return (obj.WorkPosition).GetHashCode();
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {      
            Crew crew = new Crew();
            crew.Add(new Worker { Name = "Petr", Surname = "Ivanov", WorkPosition = Position.Director });
            crew.Add(new Worker { Name = "Vika", Surname = "Klichko", WorkPosition = Position.Bookkeeper });
            crew.Add(new Worker { Name = "Kolya", Surname = "Vikulov", WorkPosition = Position.Manager });

            //sort by IComparer
            crew.Sort();
            Console.WriteLine("Sort with IComparer:\n");
            foreach (var worker in crew)
                Console.WriteLine("{0} {1} {2}", worker.Name.PadRight(15), worker.Surname.PadRight(15), worker.WorkPosition);

            /*//sort by LINQ
            var team = crew.OrderBy(n => n.WorkPosition);
            Console.WriteLine("Sort with LINQ:\n");
            foreach (var worker in team)
                Console.WriteLine("{0} {1} {2}", worker.Name.PadRight(15), worker.Surname.PadRight(15), worker.WorkPosition);*/
        }
    }
}
