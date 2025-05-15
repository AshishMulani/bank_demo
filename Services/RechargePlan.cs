using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_demo.Services
{
    public class RechargePlan
    {
        public string Category { get; set; }  // e.g., "Top-Up", "Data", "Unlimited"
        public string Amount { get; set; }    // e.g., "₹149"
        public string Description { get; set; }  // e.g., "1.5GB/day for 20 days"
    }
}
