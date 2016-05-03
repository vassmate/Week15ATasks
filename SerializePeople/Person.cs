using System;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        private string _name;
        private int _age;

        public Person(){}

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        [OnSerializing]
        public void ShowInfo(StreamingContext context)
        {
            string msg = ">Person is under serialization...\n";
            Console.WriteLine(msg);
        }
    }
}