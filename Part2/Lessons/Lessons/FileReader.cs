using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
    class FileReader:IFileRead
    {
        private StreamReader _streamReader;

        public FileReader(string path)
        {
            _streamReader = new StreamReader(path, Encoding.UTF8);  
        }

        public List<string> Read()
        {
            List<string> listLines = new List<string>();

            using (_streamReader)
            {
                string line;
                while ((line = _streamReader.ReadLine()) != null)
                {
                    listLines.Add(line);
                }
            }

            return listLines;
        }
    }
}