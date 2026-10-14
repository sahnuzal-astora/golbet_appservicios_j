// GolBet.Repositories/Interfaces/IMatchRepository.cs 

using GolBet.Entities;

using GolBet.Entities.Enums;



namespace GolBet.Repositories.Interfaces;



public interface IMatchRepository : IGenericRepository<Match>

{

    // Added optional search parameter to filter by home or away team name (case-insensitive)
    Task<IEnumerable<Match>> GetAllWithTeamsAsync(MatchStatus? status = null, string? search = null);

    Task<Match?> GetByIdWithDetailsAsync(int id);

}