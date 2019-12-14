using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
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

            Assert.IsNotNull(name);
            Assert.GreaterOrEqual(name.GetFirstName().Length, 2);
            Assert.GreaterOrEqual(name.GetLastName().Length, 2);
            Assert.AreEqual(name.GetFullName().Split(' ').Length, 2);
        }
    }
}
