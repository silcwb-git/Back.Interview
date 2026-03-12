namespace Back.Interview.Domain.Entities
{
    public class Interview
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id} - {Name} - {Status}";
        }
    }
}