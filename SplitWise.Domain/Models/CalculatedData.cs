using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Models
{
    public class CalculatedData
    {
        public decimal ExpenseAmount { get; set; }
        public decimal ReciveAmount { get; set; }
        public decimal NotConfirmedReciveAmount { get; set; }
    }
}
