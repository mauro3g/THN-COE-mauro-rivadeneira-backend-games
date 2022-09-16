using Company.DAL.Models;

namespace Company.BL.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetVideogames();
        Task<Game> GetVideogameById(int id);
        Task<Game> PostVideogame(Game data);
        Task<Game> UpdateVideogame(int id, Game data);
        Task<string> DeleteVIdeogameById(int id);
    }
}
