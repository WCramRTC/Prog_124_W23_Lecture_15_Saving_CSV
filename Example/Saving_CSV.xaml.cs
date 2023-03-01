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
    /// Interaction logic for Saving_CSV.xaml
    /// </summary>
    public partial class Saving_CSV : Window
    {
        public Saving_CSV()
        {
            InitializeComponent();
        } // Saving_CSV

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This was called");
            SaveFile();
        } // btnSaveToFile_Click()

        

        public void SaveFile()
        {
            string filePath = FileLocation.csvLocation;
            CultureInfo ci = CultureInfo.InvariantCulture;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using(CsvWriter csv = new CsvWriter(writer, ci))
                {
                    csv.WriteField("one");
                    csv.WriteField("two");
                    csv.WriteField("three");
                }
            }


        } // SaveFile()

    } // class
} // namespace
