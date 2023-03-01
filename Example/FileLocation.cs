using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_W24_Lecture_15_Saving_CSV.Example
{
    public static class FileLocation
    {
        public static string directoryLocation = Directory.GetCurrentDirectory();
        public static string csvLocation = directoryLocation + @"\CSV_Files\data.csv";
        public static string playersLocation = directoryLocation + @"\CSV_Files\players.csv";



    }
}
