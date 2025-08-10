using AdCampaignDashboard.Api.Models;
using AdCampaignDashboard.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdCampaignDashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        public CampaignsController(CampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public IActionResult GetCampaigns()
        {
            return Ok(_campaignService.GetAll());
        }



        [HttpPost("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateRequest request)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey) || apiKey != "Ad-Api-Key-123")
                return Unauthorized("Invalid API key");

            await Task.Delay(2000);

            var success = _campaignService.UpdateStatus(id, request.NewStatus);

            if (!success)
                return BadRequest("Invalid status change");

            return Ok(new { message = "Status updated" });
        }
    }

    public class StatusUpdateRequest
    {
        public string NewStatus { get; set; }
    }
}
