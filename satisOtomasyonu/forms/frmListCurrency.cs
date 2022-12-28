using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace satisOtomasyonu.forms
{
    public partial class frmListCurrency : Form
    {
        public frmListCurrency()
        {
            InitializeComponent();
        }

        private void frmListCurrency_Load(object sender, EventArgs e)
        {
            DovizGoster();
        }

        public void DovizGoster()
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

                lblDolar.Text = dolar.ToString();
                lblEuro.Text = euro.ToString();
                lblSterlin.Text = sterlin.ToString();
            }
            catch (XmlException xml)
            {
                timer1.Stop();
                MessageBox.Show(xml.ToString());
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            DovizGoster();
        }
    }
}
