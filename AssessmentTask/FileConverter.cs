using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AssessmentTask
{
    static class  FileConverter
    {
        public static string CreateOutputFile(string inputFilePath)
        {
            List<Participant> participants = ConvertFromFileToList(inputFilePath);

            List<CountryStatistics> countryStatistics = GetCountryStatistics(participants);

            string outputFilePath = CreateOutputFile(countryStatistics, participants);

            return outputFilePath;
        }

        public static List<Participant> ConvertFromFileToList(string inputFilePath)
        {
            List<Participant> participants = new List<Participant>();
            try
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    string headerLine = sr.ReadLine();
                    string line;
                    List<string> lineValues;

                    while ((line = sr.ReadLine()) != null)
                    {
                        lineValues = line.Split(';').ToList();
                        Participant tempParticipant = new Participant(lineValues[0], lineValues[1], lineValues[2], Int32.Parse(lineValues[4]));
                        participants.Add(tempParticipant);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("FileNotFound");
            }

            return participants;
        }

        public static List<CountryStatistics> GetCountryStatistics(List<Participant> participants)
        {
            List<CountryStatistics> countryStatistics = new List<CountryStatistics>();
            foreach (Participant p in participants)
            {
                if (countryStatistics.Any(x => x.Name == p.Country))
                {
                    countryStatistics.Find(x => x.Name == p.Country).AddNewDate(p);
                }
                else
                {
                    CountryStatistics newCountry = new CountryStatistics(p.Country, p.Score);
                    countryStatistics.Add(newCountry);
                }
            }

            return countryStatistics.OrderBy(x => x.AverageScore).Reverse().ToList();
        }

        public static string CreateOutputFile(List<CountryStatistics> countryStatistics, List<Participant> participants)
        {

            Console.WriteLine("Choose path for the output file:");
            string filePath = Console.ReadLine() + "ReportByCountry.csv";
            string delimiter = ";";
            string columnNames = "Country" + delimiter + 
                                 "Average score" + delimiter + 
                                 "Median score" + delimiter + 
                                 "Max score" + delimiter + 
                                 "Max score person" + delimiter + 
                                 "Min score" + delimiter + 
                                 "Min score person" + delimiter + 
                                 "Record count" + Environment.NewLine;
          
            File.WriteAllText(filePath, columnNames);

            foreach (CountryStatistics country in countryStatistics)
            {
                string appendText = country.Name + delimiter + 
                                    country.AverageScore + delimiter + 
                                    country.CalculateMedianScore() + delimiter +
                                    country.MaxScore + delimiter +
                                    participants.Find(x => x.Score==country.MaxScore).FirstName + " " + participants.Find(x => x.Score == country.MaxScore).LastName + delimiter +
                                    country.MinScore + delimiter +
                                    participants.Find(x => x.Score == country.MinScore).FirstName + " " + participants.Find(x => x.Score == country.MinScore).LastName + delimiter +
                                    country.RecordCount + Environment.NewLine;
                File.AppendAllText(filePath, appendText);
            }

            return filePath;

        }
    }
}
