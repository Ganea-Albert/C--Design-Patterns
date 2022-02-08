using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.Structure
{
    class Program
    {
        static void Main(string[] args)
        {

            int extrinsicstate = 22;

            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new
                UnsharedConcreteFlyweight();

            fu.Operation(--extrinsicstate);

            Console.ReadKey();
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> flyweights { get; set; } = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }
    
    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicstate);

        }
    }
}
