using System;
using System.Data;
using System.IO;
/*
 * File IO operations happen using Streams. Streams are like pipes that allows to input and output the content to and from the App respectively. Anything that comes into the Application is called InputStream anything that goes out of the App is called as OutputStream. 
 * There is FileStream Class to interact with Files. 
 * For Reading and Writing Text based files we have classes derived from TextReader and TextWriter classes.
 * StreamReader and StreamWriter classes are used to read and write to a TextFile...
 * For reading value types like Bytes, U could use BinaryReader and BinaryWriter classes. This is used for reading and writing BinaryFiles. 
 * StringReader and StringWriter is used to read and write strings. Usually used for converting Char [] to strings in an optimized manner. 
 */
namespace SampleConApp
{
    class FileIO
    {
        const string file = @"C:\Users\phani\source\repos\PhilipsDotnetTraining\SampleConApp\Employees.csv";
        static void Main(string[] args)
        {
            //readAfile();
            //writeToFile();
            //readCsvFileExample();
            //Get all the data into  Table...
            var table = readACSVFile();
            //Add any new or update old into the table.
            var newRow = table.NewRow();
            newRow[0] = 101;
            newRow[1] = "Phaniraj";
            newRow[2] = "Bangalore";
            table.Rows.Add(newRow);
            table.AcceptChanges();
            //Replace all the data into the CSV file again...
            StreamWriter streamWriter = new StreamWriter(file);
            //iterate thro' the Rows Collection of the table
            foreach(DataRow row in table.Rows)
            {
                var line = String.Format("{0},{1},{2}", row[0], row[1], row[2]);//Create a line using ,
                streamWriter.WriteLine(line);//Write to the file
            }
            streamWriter.Flush();
            streamWriter.Dispose();
        }

        private static void readCsvFileExample()
        {
            DataTable Table = readACSVFile();
            //MainForm form = new MainForm(Table);
            //form.ShowDialog();

            foreach (DataRow row in Table.Rows)
            {
                Console.WriteLine("Name:{0}\tAddress:{1}", row[1], row[2]);
            }
        }

        private static DataTable readACSVFile()
        {
            DataTable table = new DataTable("Employees");
            table.Columns.Add("EmpID", typeof(int));
            table.Columns.Add("EmpName", typeof(string));
            table.Columns.Add("EmpAddress", typeof(string));
            table.AcceptChanges();
            StreamReader reader = new StreamReader(file);
            //read single line at a time till the end of the file...
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var words = line.Split(','); //split each line based on ,
                DataRow row = table.NewRow();//Initialize the row...
                for(int i = 0; i < words.Length; i++)
                {
                    row[i] = words[i];
                }
                table.Rows.Add(row);
            }
            reader.Dispose();
            table.AcceptChanges();
            //iterate thro the words to get the values. 
            //Add it to the Table's rows collection
            //Save the table and return it.....
            return table;
        }
        private static void writeToFile()
        {
            using (StreamWriter writer = new StreamWriter("SampleFile.txt",true))
            { 
                writer.WriteLine("Testing the code on file dated " + DateTime.Now.ToString());
                writer.Flush();//Clears the buffer to the writing object.... 
            }//using takes care of closing the resources before its destroyed....
        }

        private static void readAfile()
        {
            const string file = @"C:\Users\phani\source\repos\PhilipsDotnetTraining\SampleConApp\FileIO.cs";
            StreamReader reader = new StreamReader(file);
            string contents = reader.ReadToEnd();
            Console.WriteLine(contents);
            reader.Dispose();
            
            
        }
    }
}
