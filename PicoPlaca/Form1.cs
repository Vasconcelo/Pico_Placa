using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicoPlaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            List<PicoPlaca> listadoPicoPlaca = new List<PicoPlaca>();
            var culture = new CultureInfo("es-ES");
            var date = DateTime.Parse(txbDate.Text);
            var name = culture.DateTimeFormat.GetDayName(date.DayOfWeek).ToString();
            var digit = txbPlaca.Text.Substring(txbPlaca.Text.Length - 1, 1);
            TimeSpan hr = TimeSpan.Parse(txbHr.Text);
            var resultado = Result.Check(listadoPicoPlaca, name, digit, hr);
            txtResult.Text = resultado;
        }

        
    }
}
