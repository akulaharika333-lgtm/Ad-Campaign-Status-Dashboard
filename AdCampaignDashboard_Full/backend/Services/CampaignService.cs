using AdCampaignDashboard.Api.Models;
using System.Text.Json;

namespace AdCampaignDashboard.Api.Services
{

    public class CampaignService
    {
        private readonly List<Campaign> _campaigns;

        public CampaignService()
        {
            var json = File.ReadAllText("Data/campaigns.json"); // <-- Updated path
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _campaigns = JsonSerializer.Deserialize<List<Campaign>>(json, options) ?? new List<Campaign>();
        }

        public List<Campaign> GetAll() => _campaigns;
   

        public Campaign? GetById(int id) => _campaigns.FirstOrDefault(c => c.Id == id);

        public bool UpdateStatus(int id, string newStatus)
        {
            var campaign = GetById(id);
            if (campaign == null) return false;

            if (campaign.Status == "Active" && newStatus == "Archived")
                return false;

            campaign.Status = newStatus;
            return true;
        }
    }
}
