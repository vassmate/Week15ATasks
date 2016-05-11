using System;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        private string _name;
        [NonSerialized] private int _age;

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

        public void OnDeserialization(object sender)
        {
            string isAgeSerialized = Age == 0 ? "Age is not serialized!" : Age.ToString();
            string msg = ">Person is under deserialization...\n" +
                         "> Person's name: " + Name + "\n" +
                         "> Person's age: " + isAgeSerialized + "\n";

            Console.WriteLine(msg);
        }
    }
}