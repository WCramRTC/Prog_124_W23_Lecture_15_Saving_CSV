//using CsvHelper;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        List<Player> players = new List<Player>();
        public CSV_Example()
        {
            InitializeComponent();
            //ReadFile_Players();
            ReadPlayerFile();
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

        //public void ReadFileCSV_Helper()
        //{
        //    string filePath = FileLocation.csvLocation;

        //    using(StreamReader reader = new StreamReader(filePath))
        //    {
        //        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {
        //            while(csv.Read())
        //            {
        //                string val1 = csv.GetField(0);
        //                string val2 = csv.GetField(1);
        //                string val3 = csv.GetField(2);

        //                runDisplay.Text += $"{val1} \n" +
        //                    $"{val2} \n " +
        //                    $"{val3} \n";

        //            }
        //        }
        //    }
        //}

        //public void ReadFileCSV_Helper2()
        //{
        //    string filePath = Directory.GetCurrentDirectory() + @"\Example\CSV_Files\data.csv";

        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {

        //            while (csv.Read())
        //            {

        //                int val1 = csv.GetField<int>(0);
        //                double val2 = csv.GetField<double>(1);
        //                string val3 = csv.GetField(2);

        //                runDisplay.Text += $"{val1} \n" +
        //                    $"{val2} \n " +
        //                    $"{val3} \n";

        //            }


        //        }
        //    }


        //} // ReadFileCSV_Helper()

        //public void ReadFile_Players()
        //{
        //    // Users static location
        //    using(var reader = new StreamReader(FileLocation.playersLocation))
        //    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        // Skips Header
        //        csv.Read();
        //        csv.ReadHeader();

        //        // Looks at each individual line
        //        while (csv.Read())
        //        {
        //            string name = csv.GetField(0);
        //            string hp = csv.GetField(1);

        //            players.Add(new Player(name, hp));
        //        }

        //    }

        //    MessageBox.Show(players.Count.ToString());
        //}

        public void ReadPlayerFile()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\CSV_Files\players.csv";


            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                players = csv.GetRecords<Player>().ToList<Player>();
            }

            Display();
        }

        public void Display()
        {
            runDisplay.Text = "";

            foreach (Player item in players)
            {
                runDisplay.Text += item.ToString() + "\n";
            }
        }


    } // class

} // namespace
