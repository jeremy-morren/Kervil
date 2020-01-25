using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kervil.Csv
{
    public class CsvDocument
    {
        public List<string> ColumnHeaders { get; internal set; }

        public List<List<string>> Rows { get; internal set; }
    }
}
