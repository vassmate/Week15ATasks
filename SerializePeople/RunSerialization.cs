using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    static class RunSerialization
    {
        private static readonly string _fileName = "person.dat";

        static void Main()
        {
            Person person = new Person("Mate", 25);

            Serialze(person, new BinaryFormatter());
            Person personFromFile = Deserialize(new BinaryFormatter());

            CloseInfoToConsole();
        }

        private static void Serialze(Person person, IFormatter iformatter)
        {
            FileStream fileStream = new FileStream(_fileName, FileMode.Create);
            iformatter.Serialize(fileStream, person);
            fileStream.Close();
        }

        private static Person Deserialize(IFormatter iformatter)
        {
            FileStream fileStream = new FileStream(_fileName, FileMode.Open);
            Person personFromFile = (Person)iformatter.Deserialize(fileStream);
            fileStream.Close();

            return personFromFile;
        }

        private static void CloseInfoToConsole()
        {
            string exitInfo = ">Press any key to exit...";
            Console.WriteLine(exitInfo);
            Console.Read();
        }
    }
}
