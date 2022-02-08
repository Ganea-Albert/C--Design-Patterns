using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();

            Console.ReadKey();
        }
    }

    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    public class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if(realSubject == null)
            {
                realSubject = new RealSubject();

            }

            realSubject.Request();
        }
    }
}
