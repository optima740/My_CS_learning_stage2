using System.Collections.Generic;

namespace Task1
{
    class LineFinder
    {
        public List<string> GetLine(IFileRead fr, string finderWord)
        {
            List<string> listLines = new List<string>(); 
                      
            foreach (string line in fr.Read())
            {
                if (line.ToUpper().Contains(finderWord.ToUpper()))
                {
                    listLines.Add(line);
                }
            }

            return listLines;
        }
    }
}