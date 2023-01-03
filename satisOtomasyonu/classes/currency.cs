using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace satisOtomasyonu.classes
{
    class currency
    {

        public void showCurrency(DataGridView data, Label lblDolar, Label lblEuro, Label lblSterlin, Timer timer)
        {
            try
            {
                decimal price = 0;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    price += decimal.Parse(data.Rows[i].Cells["totalPrice"].Value.ToString());
                }

                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));
                decimal totalUSD = price / dolar;
                decimal totalEUR = price / euro;
                decimal totalGBP = price / sterlin;
                totalUSD = Math.Round(totalUSD, 3);
                totalEUR = Math.Round(totalEUR, 3);
                totalGBP = Math.Round(totalGBP, 3);
                lblDolar.Text = "USD($): " + totalUSD.ToString();
                lblEuro.Text = "EUR(€): " + totalEUR.ToString();
                lblSterlin.Text = "GBP(£): " + totalGBP.ToString();
            }
            catch (XmlException xml)
            {
                timer.Stop();
                MessageBox.Show(xml.ToString());
            }

        }

    }
}
