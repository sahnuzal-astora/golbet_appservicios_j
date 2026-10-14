using GolBet.Entities.Enums;

using GolBet.Services.DTOs;



namespace GolBet.Services.Interfaces;



public interface IMatchService

{

    /// <summary>Match board: all active matches ordered by date.</summary> 

    // Added optional search parameter to request matches filtered by team name
    Task<IEnumerable<MatchDto>> GetBoardAsync(MatchStatus? status = null, string? search = null);
    // GolBet.Services/Interfaces/IMatchService.cs  (agregar) 

    Task<MatchDetailDto?> GetDetailAsync(int id);
    // GolBet.Services/Interfaces/IMatchService.cs  (agregar) 

    Task<MatchFormDto?> GetForEditAsync(int id);

    Task CreateAsync(MatchFormDto dto);

    Task UpdateAsync(MatchFormDto dto);

    Task DeactivateAsync(int id);

}