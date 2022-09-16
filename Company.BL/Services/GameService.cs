using Company.BL.Repositories;
using Company.DAL;
using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.BL.Services
{
    public class GameService: IGameRepository
    {
        private readonly ApiDbContext _context;

        // Creamos un constructor e inyectar el contexto
        public GameService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetVideogames()
        {
            var list = await _context.Game.ToListAsync();
            return list;
        }

        public async Task<Game> GetVideogameById(int id)
        {
            var game = await _context.Game.FindAsync(id);
            return game;
        }

        public async Task<Game> PostVideogame(Game data)
        {
            _context.Game.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<Game> UpdateVideogame(int id, Game data)
        {
            _context.Game.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<string> DeleteVIdeogameById(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return "NOT_FOUND";
            }
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return "OK";
        }
    }
}
