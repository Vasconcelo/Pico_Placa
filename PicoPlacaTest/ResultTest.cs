using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicoPlaca;
using System.Globalization;

namespace PicoPlacaTest
{
    [TestClass]
   public class ResultTest
    {
        [TestMethod]
        void ShouldShowCanTravel() 
        {
            //when passing 10/10/2016 and AAA5243 and 7:00 ====>>>>Return "You can travel" 
            //Entry Data
            var entryDate = "10/10/2016";
            var plate = "AAA5243";
            var time = "7:00";

            List<PicoPlaca.PicoPlaca> listadoPicoPlaca = new List<PicoPlaca.PicoPlaca>();
            var culture = new CultureInfo("es-ES");
            var date = DateTime.Parse(entryDate);
            var name = culture.DateTimeFormat.GetDayName(date.DayOfWeek).ToString();
            var digit = plate.Substring(plate.Length - 1, 1);
            TimeSpan hr = TimeSpan.Parse(time);
            var txt = PicoPlaca.Result.Check(listadoPicoPlaca, name,digit,hr);
            //Assert
            Assert.AreEqual("You can travel",txt);
        }

    }
}
