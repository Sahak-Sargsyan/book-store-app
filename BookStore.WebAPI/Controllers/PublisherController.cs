using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers;

[ApiController]
[Route("publishers")]
public class PublisherController : Controller
{
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PublisherListDto>>> GetAllPublishersAsync()
    {
        var publishers = await _service.GetAllPublishersAsync();
        return Ok(publishers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherListDto>> GetPublisherByIdAsync(Guid id)
    {
        var publisher = await _service.GetPublisherByIdAsync(id);
        return Ok(publisher);
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<PublisherListDto>> GetPublisherByIsbn13Async(string isbn13)
    {
        var publisher = await _service.GetPublisherByIsbn13Async(isbn13);
        return Ok(publisher);
    }

    [HttpPost]
    public async Task<ActionResult> AddPublisherAsync([FromBody] PublisherCreateDto publisher)
    {
        await _service.AddPublisherAsync(publisher);
        return Ok(publisher);
    }

    [HttpPut]
    public async Task<ActionResult<PublisherListDto>> UpdatePublisherAsync([FromBody] PublisherUpdateDto publisherToUpdate)
    {
        await _service.UpdatePublisherAsync(publisherToUpdate);
        return Ok(publisherToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PublisherListDto>> DeletePublisherAsync(Guid id)
    {
        await _service.DeletePublisherByIdAsync(id);
        return Ok();
    }
}
