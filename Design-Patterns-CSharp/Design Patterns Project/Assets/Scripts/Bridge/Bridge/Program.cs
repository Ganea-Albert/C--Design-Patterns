using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var personalCustomerData = new Customers();

            personalCustomerData.Data = new CustomersData("Bucuresti");

            personalCustomerData.Show();
            personalCustomerData.Next();
            personalCustomerData.Show();
            personalCustomerData.Next();
            personalCustomerData.Show();
            personalCustomerData.Add("Mihai");

            personalCustomerData.ShowAll();

            Console.ReadKey();
        }

    }
    public class CustomersBase
    {
        private DataObject dataObject;

        public DataObject Data
        {
            set { dataObject = value; }
            get { return dataObject; }
        }
        public virtual void Next()
        {
            dataObject.NextRecord();
        }
        public virtual void Prior()
        {
            dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            dataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            dataObject.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            dataObject.ShowAllRecords();
        }
    }

    public class Customers : CustomersBase
    {
        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------");
            base.ShowAll();
            Console.WriteLine("-----------------");
        }
    }

    public abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract string GetCurrentRecord();
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();

    }
    
    public class CustomersData : DataObject
    {
        private readonly List<string> personalCustomerData = new List<string>();
        private int current = 0;
        private string city;

        public CustomersData(string city)
        {
            this.city = city;

            personalCustomerData.Add("Mircea Voda");
            personalCustomerData.Add("Mihai Popescu");
            personalCustomerData.Add("Mirabela Dower");
            personalCustomerData.Add("Marian");
            personalCustomerData.Add("Icsulescu");
        }

        public override void NextRecord()
        {
            if(current <= personalCustomerData.Count - 1)
            {
                current++;
            }
        }

        public override void PriorRecord()
        {
            if(current > 0)
            {
                current--;
            }
        }

        public override void AddRecord(string customer)
        {
            personalCustomerData.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            personalCustomerData.Remove(customer);
        }

        public override string GetCurrentRecord()
        {
            return personalCustomerData[current];
        }

        public override void ShowRecord()
        {
            Console.WriteLine(personalCustomerData[current]);
        }

        public override void ShowAllRecords()
        {
            Console.WriteLine("Customer City: " + city);

            foreach (string customer in personalCustomerData)
            {
                Console.WriteLine(" " + customer);
            }
        }
    }
}
