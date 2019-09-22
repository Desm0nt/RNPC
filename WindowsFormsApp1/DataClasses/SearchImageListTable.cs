using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataClasses
{
    public class SearchImageListTable
    {
        public int Id { get; set; }
        public string Id_vid { get; set; }
        public string Id_pat { get; set; }
        public string path { get; set; }
        public DateTime date { get; set; }
        public string timestamp { get; set; }
        public double distance { get; set; }
    }
}
