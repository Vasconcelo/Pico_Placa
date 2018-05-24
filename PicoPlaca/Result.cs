using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PicoPlaca
{
    public class Result
    {
        public static string Check(List<PicoPlaca> listadoPicoPlaca, string name, string digit, TimeSpan hr)
        {
            Dictionary<string, int[]> valores = new Dictionary<string, int[]>();
            valores.Add("lunes", new int[] { 1, 2 });
            valores.Add("martes", new int[] { 3, 4 });
            valores.Add("miercoles", new int[] { 5, 6 });
            valores.Add("jueves", new int[] { 7, 8 });
            valores.Add("viernes", new int[] { 9, 0 });


            foreach (KeyValuePair<string, int[]> item in valores)
            {

                listadoPicoPlaca.Add(new PicoPlaca()
                {
                    schedule_time = new Schedule
                    {
                        start_morning = new TimeSpan(7, 00, 00),
                        end_morning = new TimeSpan(9, 30, 00),
                        star_afternoon = new TimeSpan(4, 00, 00),
                        end_afternoon = new TimeSpan(7, 30, 00)
                    },
                    restriction = new Dictionary<string, int[]> { { item.Key, item.Value }, }
                });
            }
            bool can = false;
            var txt = "";
            var result = listadoPicoPlaca.Where(p => p.restriction.Keys.FirstOrDefault() == name &&
                (p.schedule_time.start_morning <= hr && p.schedule_time.end_morning >= hr || p.schedule_time.star_afternoon <= hr && p.schedule_time.end_afternoon >= hr)).Select(p => p).ToList();

            if (result.Count != 0)
            {
                foreach (KeyValuePair<string, int[]> item in result.FirstOrDefault().restriction)
                {
                    foreach (int itemValue in item.Value)
                    {
                        if (itemValue == int.Parse(digit))
                        {
                            can = true;
                        }
                    }
                }
            }
            return txt = can ? "You can't travel,beak and plate" : "You can travel";
        }
    
    }
}
