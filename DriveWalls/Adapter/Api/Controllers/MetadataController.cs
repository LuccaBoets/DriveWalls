using Core.Api.Service;
using Core.Dto;
using Core.Models;
using Core.Ports.Driving.Api;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataService _metadataService;

        public MetadataController(IMetadataService metadataService)
        {
            _metadataService = metadataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _metadataService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Metadata metadata)
        {
            return Created("temp", await _metadataService.Create(metadata));
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //}
    }
}