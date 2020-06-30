using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentTask
{
    class Participant
    {
        private string firstName;
        private string lastName;
        private string country;
        private int score;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Country { get { return country; } set { country = value; } }
        public int Score { get { return score; } set { score = value; } }

        public Participant(string firstName, string lastName, string country, int score)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.country = country;
            this.score = score;
        }


    }
}
