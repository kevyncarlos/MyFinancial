using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinancial.Data.Entities
{
    public class InputOutputBase : EntityBase
    {
        public string Description { get; set; }
        public decimal Value { get; set; } = 0;
        public bool WasPaid { get; set; } = false;
        public string? Observation { get; set; }

        public int CompetenceId { get; set; }
        public Competence Competence { get; set; }

        public InputOutputBase(string description, int competenceId)
        {
            Description = description;
            CompetenceId = competenceId;
        }

        public InputOutputBase(string description, decimal value, int competenceId) : this(description, competenceId)
        {
            Value = value;
        }

        public InputOutputBase(string description, decimal value, bool wasPaid, string? observation, int competenceId) : this(description, value, competenceId)
        {
            WasPaid = wasPaid;
            Observation = observation;
        }
    }
}
