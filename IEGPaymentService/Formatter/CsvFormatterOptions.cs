using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEGPaymentService.Formatter
{
    public class CsvFormatterOptions
    {
        public bool UseSingleLineHeaderInCsv { get; set; } = true;

        public string CsvDelimiter { get; set; } = ";";

        public string Encoding { get; set; } = "ISO-8859-1";

        public bool IncludeExcelDelimiterHeader { get; set; } = false;
    }
}