namespace MyFinancial.Data.Entities
{
    public class Competence : EntityBase
    {
        public string Description { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public ICollection<Input>? Inputs { get; set; }
        public ICollection<Output>? Outputs { get; set; }

        public Competence()
        {

        }

        public Competence(string description)
        {
            Description = description;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
        }

        public Competence(string description, int month, int year) : this(description)
        {
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"'{nameof(Id)}: {Id} | {nameof(CreatedAt)}: {CreatedAt:g} | {nameof(UpdatedAt)}: {UpdatedAt:g} | {nameof(Description)}: {Description} | {nameof(Month)}: {Month} | {nameof(Year)}: {Year}'";
        }
    }
}
