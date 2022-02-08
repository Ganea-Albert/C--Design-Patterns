using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);

            Console.ReadKey();
        }
    }

    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        List<Component> children = new List<Component>();

        public Composite(string name) : base(name)
        {

        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        { }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
    }
}
