// GolBet.Entities/Match.cs 

using System.ComponentModel.DataAnnotations.Schema;

using GolBet.Entities.Common;

using GolBet.Entities.Enums;



namespace GolBet.Entities;



public class Match : AuditableEntity

{

    public DateTime Date { get; set; }



    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;



    /// <summary>Null until the match finishes.</summary> 

    public int? HomeGoals { get; set; }

    public int? AwayGoals { get; set; }



    [Column(TypeName = "decimal(5,2)")]

    public decimal HomeOdds { get; set; }



    [Column(TypeName = "decimal(5,2)")]

    public decimal DrawOdds { get; set; }



    [Column(TypeName = "decimal(5,2)")]

    public decimal AwayOdds { get; set; }



    // Two foreign keys to the same table (Team) 

    public int HomeTeamId { get; set; }  //PK

    public Team HomeTeam { get; set; } = null!; //la relacion de esa PK con la tabla Team



    public int AwayTeamId { get; set; }

    public Team AwayTeam { get; set; } = null!;


    //navigation property for the bets placed on this match. A match can have many bets, but a bet is only for one match.
    public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    // esta es una relaccion de collection significa como que un partido puede tener muchas apuestas, pero una apuesta solo puede estar en un partido.
    // new list <Bet>() es para inicializar la coleccion de apuestas, para que no sea null y se pueda agregar apuestas a la coleccion.
}