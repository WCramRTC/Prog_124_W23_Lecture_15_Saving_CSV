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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prog_124_W24_Lecture_15_Saving_CSV.Example
{
    /// <summary>
    /// Interaction logic for Saving_CSV.xaml
    /// </summary>
    public partial class Saving_CSV : Window
    {
        List<Player> players = new List<Player>();

        public Saving_CSV()
        {
            InitializeComponent();
            players.Add(new Player("Will", "123"));
            players.Add(new Player("Anne", "123"));
            SaveList();
        } // Saving_CSV

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileRecords();
            
        } // btnSaveToFile_Click()

        public void SaveFileRecords()
        {

            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = FileLocation.csvLocation;

            using (var stream = File.Open(filePath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                csvWriter.WriteField(txtFirstName.Text);
                csvWriter.WriteField(txtLastName.Text);
                csvWriter.WriteField(txtHitPoints.Text);
                csvWriter.NextRecord();

                writer.Flush();
            }

        } // SaveFile()

        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = FileLocation.playersLocation;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                csvWriter.WriteRecords(players);
                writer.Flush();
            }
        }

    } // class
} // namespace
