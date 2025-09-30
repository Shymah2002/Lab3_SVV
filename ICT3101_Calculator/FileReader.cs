using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileReader : IFileReader
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}

