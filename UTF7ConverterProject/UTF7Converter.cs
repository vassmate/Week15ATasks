using System;
using System.IO;
using System.Text;

namespace UTF7ConverterProject
{
    class UTF7Converter
    {
        private static string inptFilePath = @"C:\testfiles\dir01\phonebook.dat";
        private static string outptFilePath = @"C:\testfiles\dir01\phonebook-utf7.txt";

        static void Main(string[] args)
        {
            try
            {
                StreamReader streamReader = new StreamReader(inptFilePath);
                StreamWriter streamWriter = new StreamWriter(outptFilePath, false, Encoding.UTF7);

                streamWriter.WriteLine(streamReader.ReadToEnd());
                streamWriter.Close();
                streamReader.Close();

                Console.WriteLine(">File on the following path is converted to UTF7: " + "\n>" + inptFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(">Exception occurred: " + ex.Message);
            }

            Console.WriteLine(">Press any key to exit...");
            Console.ReadKey();
        }
    }
}
