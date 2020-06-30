using System;

namespace AssessmentTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to the input file:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter sender email:");
            string senderEmail = Console.ReadLine();
            Console.WriteLine("Enter sender password:");
            string senderPassword = Console.ReadLine();
            Console.WriteLine("Enter receiver email:");
            string receiverEmail = Console.ReadLine();

            string outputFile = FileConverter.CreateOutputFile(filePath);
            EmailSender.SendEmail(senderEmail, senderPassword, receiverEmail, outputFile);
        }
    }
}
