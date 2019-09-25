using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataClasses
{
    public class PatInfoTable
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Pdate { get; set; }
        public string Diag { get; set; }
    }
}
