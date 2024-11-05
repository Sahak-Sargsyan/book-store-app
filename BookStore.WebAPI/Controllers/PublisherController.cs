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
        try
        {
            var publishers = await _service.GetAllPublishersAsync();
            return Ok(publishers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherListDto>> GetPublisherByIdAsync(Guid id)
    {
        try
        {
            var publisher = await _service.GetPublisherByIdAsync(id);
            return Ok(publisher);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<PublisherListDto>> GetPublisherByIsbn13Async(string isbn13)
    {
        try
        {
            var publisher = await _service.GetPublisherByIsbn13Async(isbn13);
            return Ok(publisher);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddPublisherAsync([FromBody] PublisherCreateDto publisher)
    {
        try
        {
            await _service.AddPublisherAsync(publisher);
            return Ok(publisher);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<PublisherListDto>> UpdatePublisherAsync([FromBody] PublisherUpdateDto publisherToUpdate)
    {
        try
        {
            await _service.UpdatePublisherAsync(publisherToUpdate);
            return Ok(publisherToUpdate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PublisherListDto>> DeletePublisherAsync(Guid id)
    {
        try
        {
            await _service.DeletePublisherByIdAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
