using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentTask
{
    class CountryStatistics
    {
        private string name;
        private int totalScore;
        private List<int> records= new List<int>();
        private double averageScore;
        private int maxScore;
        private int minScore;
        private int recordCount;

        public string Name { get { return name; } set { name = value; } }
        public double AverageScore { get { return averageScore; } set { averageScore = value; } }
        public int MaxScore { get { return maxScore; } set { maxScore = value; } }
        public int MinScore { get { return minScore; } set { minScore = value; } }
        public int RecordCount { get { return recordCount; } set { recordCount = value; } }


        public CountryStatistics(string name, int score)
        {
            this.name = name;
            totalScore = score;
            records.Add(score);
            averageScore = score;
            maxScore = score;
            minScore = score;
            recordCount = 1;
        }

        public void AddNewDate(Participant p)
        {
            totalScore += p.Score;
            records.Add(p.Score);
            recordCount++;
            averageScore = totalScore / recordCount;
            if (p.Score > maxScore) maxScore = p.Score;
            if (p.Score < minScore) minScore = p.Score;
        }

        public double CalculateMedianScore()
        {
            records.Sort();
            int size = records.Count;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)records[mid] : ((double)records[mid] + (double)records[mid - 1]) / 2;
            return median;
        }

    }
}
