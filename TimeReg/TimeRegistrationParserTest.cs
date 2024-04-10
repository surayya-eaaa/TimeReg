using EmployeeTimeTracker;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace TimeReg
{
    [TestFixture]
    public class TimeRegistrationParserTest
    {
        [Test]
        public void testParseCSVtoModelThrowsException()
        {
            string fileName = "TimeRegistrations.csv";
            List<TimeRegistrationModel> list = TimeRegistrationParser.CSVtoModel(fileName);
            Assert.That(list.Count>0, Is.True, fileName + " csv file should not be empty");
        }
    }
 }
