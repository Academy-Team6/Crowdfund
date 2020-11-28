namespace Crowdfund.model
{
    public class Media
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
        public Project Project { get; set; }
    }
}
