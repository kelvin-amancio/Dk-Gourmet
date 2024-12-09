using DkGourmet.Entites;
using DkGourmet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DkGourmet.Controllers;

[ApiController]
[Route("[controller]")]
public class DkCotroller(IDkService dkService) : ControllerBase
{
    private readonly IDkService _dkService = dkService;

    [HttpGet()]
    public async Task<IActionResult> GetAll() => Ok(await _dkService.GetAllAsync());
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) => Ok(await _dkService.GetByIdAsync(id));
    
    [HttpPost()]
    public async Task<IActionResult> Add(Produto produto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.Select(x=> x.Value!.Errors));
        
        try
        {
            await _dkService.AddAsync(produto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete()]
    public async Task<IActionResult> Remove(string id)
    {
        try
        {
            await _dkService.RemoveAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}