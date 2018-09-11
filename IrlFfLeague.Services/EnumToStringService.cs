using System;
using IrlFfLeague.Core.Models;

namespace IrlFfLeague.Services
{
    public static class EnumToStringService
    {
        public static Position StringToPosition(string position)
        {
            switch (position)
            {
                case "Goalkeeper":
                    return Position.GK;
                case "Centre-Back":
                    return Position.CB;
                case "Right-Back":
                    return Position.RB;
                case "Left-Back":
                    return Position.LB;
                case "Defensive Midfield":
                    return Position.CDM;
                case "Central Midfield":
                    return Position.CM;
                case "Right Midfield":
                    return Position.RM;
                case "Left Midfield":
                    return Position.LM;
                case "Attacking Midfield":
                    return Position.CAM;
                case "Right Winger":
                    return Position.RM;
                case "Left Winger":
                    return Position.LM;
                case "Centre-Forward":
                    return Position.ST;
                case "Second Striker":
                    return Position.ST;
                default:
                    return Position.GK;
            }
        }

        public static string PositionToString(Position position)
        {
            switch (position)
            {
                case Position.GK:
                    return "Goalkeeper";
                case Position.RB:
                    return "Right-Back";
                case Position.CB:
                    return "Centre-Back";
                case Position.LB:
                    return "Left-Back";
                case Position.CDM:
                    return "Defensive Midfield";
                case Position.RM:
                    return "Right Midfield";
                case Position.CM:
                    return "Central Midfield";
                case Position.LM:
                    return "Left Midfield";
                case Position.CAM:
                    return "Attacking Midfield";
                case Position.ST:
                    return "Centre-Forward";
                default:
                    return "Goalkeeper";
            }
        }

        public static string LeagueToString(League league)
        {
            switch (league)
            {
                case League.RPL:
                    return "Russian Premier League";
                case League.EPL:
                    return "English Premier League";
                case League.LaLiga:
                    return "La Liga";
                case League.SerieA:
                    return "Serie A";
                default:
                    return "";
            }
        }

        public static string SchemeToString(Scheme scheme)
        {
            switch (scheme)
            {
                case Scheme.S4411:
                    return "4-4-1-1";
                case Scheme.S433:
                    return "4-3-3";
                case Scheme.S41212:
                    return "4-1-2-1-2";
                case Scheme.S532:
                    return "5-3-2";
                case Scheme.S31231:
                    return "3-1-2-3-1";
                default:
                    return "";
            }
        }
    }
}
