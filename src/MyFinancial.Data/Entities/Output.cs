using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinancial.Data.Entities
{
    public class Output : InputOutputBase
    {
        public Output(string description, int competenceId) : base(description, competenceId) { }

        public Output(string description, decimal value, int competenceId) : base(description, value, competenceId) { }

        public Output(string description, decimal value, bool wasPaid, string? observation, int competenceId) : base(description, value, wasPaid, observation, competenceId) { }
    }
}
