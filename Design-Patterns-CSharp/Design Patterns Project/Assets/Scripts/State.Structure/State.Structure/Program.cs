using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcreteStateA());

            context.Request();
            context.Request();
            context.Request();
            context.Request();

            Console.ReadKey();
        }
    }

    public abstract class State
    {
        public abstract void Handle(Context context);
    }

    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    public class Context
    {
        State state;

        public Context(State state)
        {
            this.State = state;
        }

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State: " + state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
