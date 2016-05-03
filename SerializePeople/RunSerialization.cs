using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SerializePeople
{
    static class RunSerialization
    {
        static void Main()
        {
            string nameInfo = ">Person's name: ";
            string ageInfo = ">Person's age: ";
            string exitInfo = "\n>Press any key to exit...";

            Person person = new Person("Mate", 25);

            SerialzePersons(person, new SoapFormatter());
            Person personFromFile = DeserializePersons(new SoapFormatter());

            SerializePersonsToXml(person);

            Console.WriteLine(nameInfo + personFromFile.Name);
            Console.WriteLine(ageInfo + personFromFile.Age);
            Console.WriteLine(exitInfo);
            Console.Read();
        }

        private static void SerializePersonsToXml(Person person)
        {
            XmlSerializer xmlSrlr = new XmlSerializer(typeof(Person));
            StreamWriter strmWriter = new StreamWriter("file.xml");
            xmlSrlr.Serialize(strmWriter, person);
            strmWriter.Close();
        }

        private static Person DeserializePersons(IFormatter iformatter)
        {
            FileStream readerStream = new FileStream("file.bin", FileMode.Open);
            Person personFromFile = (Person)iformatter.Deserialize(readerStream);
            readerStream.Close();
            return personFromFile;
        }

        private static void SerialzePersons(Person person, IFormatter iformatter)
        {
            FileStream fileStream = new FileStream("file.bin", FileMode.Create);
            iformatter.Serialize(fileStream, person);
            fileStream.Close();
        }
    }
}
