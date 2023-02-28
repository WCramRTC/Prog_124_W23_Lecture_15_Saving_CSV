using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prog_124_W24_Lecture_15_Saving_CSV.Example
{
    /// <summary>
    /// Interaction logic for CSV_Example.xaml
    /// </summary>
    public partial class CSV_Example : Window
    {
        public CSV_Example()
        {
            InitializeComponent();
            ReadFileCSV_Helper();
        } // CSV_Example()

        public void ReadFile()
        {
            
            string filePath = Directory.GetCurrentDirectory() + @"\Example\CSV_Files\data.csv";

            using (StreamReader sr = new StreamReader(filePath))
            {
                runDisplay.Text = "";
                string line = sr.ReadLine();
                string[] splitLine = line.Split(",");

                for (int i = 0; i < splitLine.Length; i++)
                {
                    runDisplay.Text += splitLine[i] + "\n";
                }
            }
        }

        // https://zetcode.com/csharp/csv/

        public void ReadFileCSV_Helper()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\Example\CSV_Files\data.csv";

            using(StreamReader reader = new StreamReader(filePath))
            {
                using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    while(csv.Read())
                    {
                        string val1 = csv.GetField(0);
                        string val2 = csv.GetField(1);
                        string val3 = csv.GetField(2);

                        runDisplay.Text += $"{val1} \n" +
                            $"{val2} \n " +
                            $"{val3} \n";

                    }
                }
            }
        }

        public void ReadFileCSV_Helper2()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\Example\CSV_Files\data.csv";

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {

                    while (csv.Read())
                    {

                        int val1 = csv.GetField<int>(0);
                        double val2 = csv.GetField<double>(1);
                        string val3 = csv.GetField(2);

                        runDisplay.Text += $"{val1} \n" +
                            $"{val2} \n " +
                            $"{val3} \n";

                    }


                }
            }


        } // ReadFileCSV_Helper()



    } // class

} // namespace
