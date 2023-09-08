using Microsoft.EntityFrameworkCore;
using MyApiRPG.Data;

namespace MyApiRPG.Services;

public class CharacterService : ICharacterService
{
    private static List<Character> characters = new List<Character>
    {
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };

    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CharacterService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var dbCharacters = await _context.Characters.ToListAsync();
        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        try
        {
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            if (dbCharacter is null)
            throw new Exception($"Character with Id '{id}' not found.");
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        try
        {
            var character = _mapper.Map<Character>(newCharacter);
            
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            
            var characters = await _context.Characters.ToListAsync();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        try
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

            if (character is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Character with Id '{updatedCharacter.Id}' not found.";
            }
            else
            {
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    
    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        try
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

            if (character is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Character with Id '{id}' not found.";
            }
            else
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                var characters = await _context.Characters.ToListAsync();
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}