using System;

namespace ReginaGameDev.Models
{
    public class PlayerName
    {
        private string FirstName;
        private string LastName;

        public PlayerName(string firstName, string lastName)
        {
            this.FirstName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName);
            this.LastName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastName);
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetFullName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
