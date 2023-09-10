using Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using MyApiRPG.Data;

namespace MyApiRPG.Tests
{
    [TestFixture]
    public class CharacterServiceTests
    {
        private DataContext _context = null!;
        private CharacterService _characterService = null!;

        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "in-memory-db")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _context = new DataContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var fakeCharacterData = new List<Character>
            {
                new Character { Id = 1, Name = "Character1" },
                new Character { Id = 2, Name = "Character2" },
            };

            _context.Characters.AddRange(fakeCharacterData);
            _context.SaveChanges();

            var fakeMapper = new Mock<IMapper>();
            _characterService = new CharacterService(fakeMapper.Object, _context);
        }

        [Test]
        public async Task GetAllCharacters_ReturnsListOfCharacters()
        {
            var result = await _characterService.GetAllCharacters();
            
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Data);
            if (result.Data != null) Assert.AreEqual("2", result.Data.Count.ToString());
            
        }
    }
}