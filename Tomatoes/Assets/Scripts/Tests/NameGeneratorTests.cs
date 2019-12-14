using NUnit.Framework;
using UnityEngine;
using ReginaGameDev.Systems;
using ReginaGameDev.Models;

namespace Tests
{
    public class NameGeneratorTests
    {
        [Test]
        public void GenerateNameTest()
        {
            NameGeneratorSystem system = new NameGeneratorSystem();
            PlayerName name = system.GenerateName();

            Debug.Log(name.GetFullName());

            Assert.IsNotNull(name, "Name does not exist");
            Assert.GreaterOrEqual(name.FirstName.Length, 2, "First name is not more than two characters");
            Assert.GreaterOrEqual(name.LastName.Length, 2, "Last name is not more than two characters");
            Assert.AreEqual(name.GetFullName().Split(' ').Length, 2, "Full name is not two words");
        }
    }
}
