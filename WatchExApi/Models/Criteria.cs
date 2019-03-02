using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchExApi
{
    public class Criteria
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 25;

        public string Filter { get; set; }
    }
}
