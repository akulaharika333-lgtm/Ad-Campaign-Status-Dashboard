namespace AdCampaignDashboard.Api.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal Budget { get; set; }
    }
}
