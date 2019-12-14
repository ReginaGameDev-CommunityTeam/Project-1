using System;

namespace ReginaGameDev.Models
{
    public class PlayerName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public PlayerName(string firstName, string lastName)
        {
            this.FirstName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName);
            this.LastName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastName);
        }

        public string GetFullName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
