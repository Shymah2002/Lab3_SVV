using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class FileReader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }

