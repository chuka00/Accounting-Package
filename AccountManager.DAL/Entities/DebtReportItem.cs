﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.Entities
{
    public class DebtReportItem
    {
        public string CustomerName { get; set; }
        public decimal TotalDebt { get; set; }
    }

}
