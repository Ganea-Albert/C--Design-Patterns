using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "Off";

            o.SetMemento(c.Memento);

            Console.ReadKey();
        }
    }

    public class Originator
    {
        string state;

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(state));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    public class Memento
    {
        string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string State
        {
            get { return state; }
        }
    }

    public class Caretaker
    {
        Memento memento;

        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }

}
