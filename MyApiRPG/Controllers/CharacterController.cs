using Microsoft.AspNetCore.Mvc;
namespace MyApiRPG.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    public ICharacterService CharacterService { get; private set; }
    
    private readonly ICharacterService _characterService;
    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }
    
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<Character>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
    }
   
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Character>>> GetSingle(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }
   
    [HttpPost]
    public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
    {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }
}