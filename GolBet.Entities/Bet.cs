// GolBet.Entities/Bet.cs 

using System.ComponentModel.DataAnnotations.Schema;

using GolBet.Entities.Common;

using GolBet.Entities.Enums;



namespace GolBet.Entities;



public class Bet : AuditableEntity

{

    [Column(TypeName = "decimal(12,2)")]

    public decimal Amount { get; set; }



    /// <summary>Odds frozen at placement time. Admin odds changes never affect placed bets.</summary> 

    [Column(TypeName = "decimal(5,2)")]

    public decimal OddsAtPlacement { get; set; }



    public BetPick Pick { get; set; }



    public BetStatus Status { get; set; } = BetStatus.Pending;

    //PK

    public int MatchId { get; set; }
    //navegacion de las PK

    public Match Match { get; set; } = null!;
    //aqui se demuestra que solo es un match por que solo puede ir a un partido, pero un partido puede tener muchas apuestas, por eso es una relacion de 1 a muchos


    // Module 7 will add:  public string UserId  +  AppUser User 

}