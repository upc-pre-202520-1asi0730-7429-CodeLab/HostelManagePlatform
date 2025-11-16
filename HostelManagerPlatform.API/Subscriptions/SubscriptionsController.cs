// Ruta: Subscriptions/SubscriptionsController.cs
using HostelManagerPlatform.API.Subscriptions.Application.Internal.CommandServices;
using HostelManagerPlatform.API.Subscriptions.Application.Internal.QueryServices;
using HostelManagerPlatform.API.Subscriptions.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagerPlatform.API.Subscriptions
{
    [ApiController]
    [Route("api/[controller]")] 
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionCommandService _commandService;
        private readonly ISubscriptionQueryService _queryService;

        public SubscriptionsController(ISubscriptionCommandService commandService, ISubscriptionQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions = await _queryService.HandleGetAllAsync();
            return Ok(subscriptions); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await _queryService.HandleGetByIdAsync(id);
            if (subscription == null)
                return NotFound(); 
            
            return Ok(subscription); 
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Subscription subscription)
        {

            
            var newSubscription = await _commandService.HandleCreateAsync(subscription);
            
            
            return CreatedAtAction(nameof(GetById), new { id = newSubscription.Id }, newSubscription);
        }
    }
}