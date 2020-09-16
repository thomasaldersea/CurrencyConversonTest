using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyConversionTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Dictionary<string, double> currencies;

        public MainWindow()
        {            
            Loaded += MainWindow_Load;

            InitializeComponent();
            filloutConversionRates();

        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            currencySelectionComboBox.SelectedIndex = 0;
            newAmountTextbox.Text = "0";
            amountTextbox.Text = "0";

        }
        private static void filloutConversionRates()
        {
            currencies = new Dictionary<string, double>();

            currencies.Add("AUD", 1.1);
            currencies.Add("USD", 1.2);
            currencies.Add("EUR", 1.3);

        }
        private static string proccessAmount(string pCurrencyValue, string pAmountString)
        {
            string regex = @"[0-9]+(\.[0-9][0-9]?)?";
            string newAmount = "";

            Match match = Regex.Match(pAmountString, regex, RegexOptions.IgnoreCase);
            if (match.Success && validateAmount(pAmountString))
            {
                newAmount = calculateNewAmount(double.Parse(pAmountString), currencies[pCurrencyValue]);

                logConversion(pAmountString, pCurrencyValue, newAmount);

            }
            else
            {
                newAmount = "Amount invalid";
            }

            return newAmount;

        }
        private static bool validateAmount(string amount)
        {
            try
            {
                double validate = double.Parse(amount);

                if(validate > 0)
                {
                    return true;
                }
                else 
                {
                   return false;

                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        private static void logConversion(string pAmount, string pCurrencyCode, string pResult)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + "ConversionLog.xml";

            if (!File.Exists(dir))
            {
                // Create a file to write to.
                using (XmlWriter writer = XmlWriter.Create(dir))
                {
                    writer.WriteStartElement("Log");
                    writer.WriteStartElement("Entry");
                    writer.WriteElementString("DateTime", DateTime.Now.ToString());
                    writer.WriteElementString("GBPAmount", pAmount);
                    writer.WriteElementString("Result", pResult);
                    writer.WriteElementString("CurrencyCode", pCurrencyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(dir);
                XElement root = xDocument.Element("Log");
                IEnumerable<XElement> rows = root.Descendants("Entry");
                XElement newRow = rows.First();
                newRow.AddBeforeSelf(
                   new XElement("Entry",
                   new XElement("DateTime", DateTime.Now.ToString()),
                   new XElement("GBPAmount", pAmount),
                   new XElement("Result", pResult),
                   new XElement("CurrencyCode", pCurrencyCode)));
                xDocument.Save(dir);
            }


        }

        private void amountTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = ((ComboBoxItem)currencySelectionComboBox.SelectedItem).Content.ToString();

            newAmountTextbox.Text = proccessAmount(value,amountTextbox.Text);
        }

        private static string calculateNewAmount(double pAmount, double pConverstionRate)
        {
            return Math.Round(pAmount * pConverstionRate, 2).ToString();
        }

        private void currencySelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = ((ComboBoxItem)currencySelectionComboBox.SelectedItem).Content.ToString();

            conversionRateLabel.Content = currencies[value] + " rate";

            newAmountTextbox.Text = proccessAmount(value, amountTextbox.Text);


        }
    }
}
