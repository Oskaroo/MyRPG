using System.Text.Json.Serialization;

namespace MyApiRPG.Models;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClass
{
    Fighter=1,
    Mage=2,
    Cleric=3,
    Barbarian= 4,
    Rogue=5,
    Ranger=6,
    Warlock= 7,
    Bard=8,
}