using System;
using System.Threading;

namespace SingleInstance
{
    class SingleIntsanceStart
    {
        static void Main(string[] args)
        {
            Mutex oneMutex = null;
            const string MutexName = "RUNMEONLYONCE";

            try
            {
                oneMutex = Mutex.OpenExisting(MutexName);
            }
            catch (WaitHandleCannotBeOpenedException ex)
            {
                Console.WriteLine(">Exception occurred: " + ex.Message);
            }

            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MutexName);
            }
            else{
                oneMutex.Close();
                return;
            }

            Console.WriteLine(">Our Application");
            Console.Read();
        }
    }
}
