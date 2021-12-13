using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Level1
    {
        public int LevelID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public string LevelName { get; set; }
        public Nullable<double> Coefficient { get; set; }
    }
}