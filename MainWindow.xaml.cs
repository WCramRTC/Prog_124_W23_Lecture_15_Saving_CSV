//using CsvHelper;
using CsvHelper;
using Prog_124_W24_Lecture_15_Saving_CSV.Example;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog_124_W24_Lecture_15_Saving_CSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> players = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            MySaveToFile();

            players.Add(new Player("Suleman", 10, "Seahawks"));
            players.Add(new Player("Bander", 113, "Seahawks"));
            players.Add(new Player("Will", 7, "49ers"));
            players.Add(new Player("Zach", 9, "Seahawks"));


        }

        public void MySaveToFile()
        {

            // File.Open is used to open a sepecific file
            // The location is in your 
            // bin -> debug -> net6.0 -> files
            using (var stream = File.Open(FilePaths.dataPath, FileMode.OpenOrCreate))
            { // Connection to file is open
            // Tells our program we are going to write to a file
                using(StreamWriter writer = new StreamWriter(stream))
                    {
                        // CulatureInfo.InvariantCulter
                        using(CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            // User csv object to write to the file
                            csv.WriteField("Suleman");
                            csv.WriteField("110");

                            // Creates a new record ( goes to next line ) ALWAYS DO THIS
                            csv.NextRecord();
                            
                            csv.WriteField("Bander");
                            csv.WriteField("120");
                            csv.NextRecord();


                            // Flushes the stream
                            writer.Flush();
                        }
                    }
            } // Connection to the file is closed


            // Steps to save to a csv

            // Step 1
            // using (var stream = File.Open(FilePaths.dataPath, FileMode.OpenOrCreate))
   
            
          
        }


        public void SaveToFile()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
           

            // Append - Continue to add to our code
            using (var stream = File.Open(FilePaths.dataPath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                
                // Grabbing text from first name, saving it as a field
                csvWriter.WriteField(txtFirstName.Text);
                // Grabbing grade and saving as a second field
                csvWriter.WriteField(txtGrade.Text);
                // Going to next record
                csvWriter.NextRecord();
                //// flushing writer
                writer.Flush();
            }
        }

        private void btnSaveGrade_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
        }

        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = FilePaths.playerPath;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(players);
                writer.Flush();
            }
        } // SaveList

        private void btnSaveList_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }
    }
}
