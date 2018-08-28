using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using CsQuery;
using IrlFfLeague.Core.Models;

namespace IrlFfLeague.Filler
{
    class LeagueToImport
    {
        public League League { get; set; }

        public string Link { get; set; }

        public int TeamsAmount { get; set; }
    }

    class Program
    {
        private static readonly List<LeagueToImport> Leagues = new List<LeagueToImport>
        {
            new LeagueToImport
            {
                League = League.EPL,
                Link = "https://www.transfermarkt.com/premier-league/startseite/wettbewerb/GB1",
                TeamsAmount = 20
            },
            new LeagueToImport
            {
                League = League.RPL,
                Link = "https://www.transfermarkt.com/premier-liga/startseite/wettbewerb/RU1",
                TeamsAmount = 16
            },
            new LeagueToImport
            {
                League = League.LaLiga,
                Link = "https://www.transfermarkt.com/primera-division/startseite/wettbewerb/ES1",
                TeamsAmount = 20
            },
            new LeagueToImport
            {
                League = League.SerieA,
                Link = "https://www.transfermarkt.com/serie-a/startseite/wettbewerb/IT1",
                TeamsAmount = 20
            }
        };

        static void Main(string[] args)
        {
            foreach (var league in Leagues)
            {
                ParseLeague(league);

                Console.WriteLine("--------------------------");
            }

            Console.ReadKey();
        }

        static void ParseLeague(LeagueToImport league)
        {
            CQ doc = GetData(league.Link);

            var divs = doc[".items td:nth-child(2) a:nth-child(1)"];

            for (var i = 0; i < league.TeamsAmount; i++)
            {
                Console.WriteLine(divs[i].InnerText);

                ParsePlayers("https://www.transfermarkt.com" + divs[i]["Href"]);
            }
        }

        static void ParsePlayers(string url)
        {
            CQ doc = GetData(url);

            var divs = doc["#yw1 .items td:nth-child(2) div:nth-child(1) a"];

            foreach (var div in divs)
            {
                Console.WriteLine(div.InnerText);

                ParsePlayer("https://www.transfermarkt.com" + div["Href"]);
            }
        }

        static List<Position> ParsePlayer(string url)
        {
            var result = new List<Position>();

            CQ doc = GetData(url);

            var divs = doc[".hauptposition-left"];

            foreach (var div in divs)
            {
                var position = div.InnerHTML.Split(new[] {"<br>"}, StringSplitOptions.None)[1].Replace("\t", "")
                    .Replace("\n", "");

                Console.WriteLine(position);

                result.Add(PositionStringToEnum(position));
            }

            divs = doc[".nebenpositionen"];

            foreach (var div in divs)
            {
                var pos = div.InnerHTML.Split(new[] { "<br>" }, StringSplitOptions.None);

                for (var i = 1; i < pos.Length; i++)
                {
                    var position = pos[i].Replace("\t", "").Replace("\n", "");

                    Console.WriteLine(position);

                    result.Add(PositionStringToEnum(position));
                }
            }

            return result;
        }

        static string GetData(string url)
        {
            var hwr = (HttpWebRequest)WebRequest.Create(url);

            hwr.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            hwr.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            hwr.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us");
            hwr.UserAgent = "My special app";
            hwr.KeepAlive = true;

            hwr.Method = "GET";
            var response = hwr.GetResponse();

            var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            var result = reader.ReadToEnd();

            return result;
        }

        static Position PositionStringToEnum(string position)
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
    }
}
