using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CsQuery;
using IrlFfLeague.Core.Models;
using IrlFfLeague.DataLayer;

namespace IrlFfLeague.Services
{
    internal class LeagueToImport
    {
        public League League { get; set; }

        public string Link { get; set; }

        public int TeamsAmount { get; set; }
    }

    public static class ParsingService
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

        public static void UpdateData(IDbContext context)
        {
            foreach (var league in Leagues)
            {
                ParseLeague(context, league);
            }
        }

        private static void ParseLeague(IDbContext context, LeagueToImport league)
        {
            CQ doc = GetData(league.Link);

            var divs = doc[".items td:nth-child(2) a:nth-child(1)"];

            for (var i = 0; i < league.TeamsAmount; i++)
            {
                var link = "https://www.transfermarkt.com" + divs[i]["Href"];
                var club = context.Clubs.SingleOrDefault(c => c.Link == link);

                if (club == null)
                {
                    club = new Club
                    {
                        Name = divs[i].InnerText,
                        Link = link,
                        League = league.League
                    };

                    context.Clubs.Add(club);
                    context.SaveChanges();
                }

                ParsePlayers(context, club);
            }
        }

        private static void ParsePlayers(IDbContext context, Club club)
        {
            var currentPlayers = context.Players.Where(p => p.ClubId == club.Id).ToList();

            CQ doc = GetData(club.Link);

            var divs = doc["#yw1 .items td:nth-child(2) div:nth-child(1) a"];

            foreach (var div in divs)
            {
                var link = "https://www.transfermarkt.com" + div["Href"];
                var player = context.Players.SingleOrDefault(p => p.Link == link);
                var exists = true;

                if (player == null)
                {
                    player = new Player
                    {
                        Name = div.InnerText,
                        ClubId = club.Id,
                        Link = link
                    };

                    exists = false;
                }
                else
                {
                    currentPlayers.Remove(player);
                }

                var parsedData = ParsePlayer(player);

                player.MainPosition = parsedData.Item1[0] ?? Position.GK;
                player.FirstPosition = parsedData.Item1[1];
                player.SecondPosition = parsedData.Item1[2];
                player.IsInjured = parsedData.Item2;

                if (exists)
                {
                    context.Players.Update(player);
                }
                else
                {
                    context.Players.Add(player);
                }

                context.SaveChanges();
            }

            foreach (var player in currentPlayers)
            {
                context.Players.Remove(player);
                context.SaveChanges();
            }
        }

        private static (List<Position?>, bool) ParsePlayer(Player player)
        {
            var result = new List<Position?>();
            var isInjured = false;

            CQ doc = GetData(player.Link);

            var divs = doc[".hauptposition-left"];

            foreach (var div in divs)
            {
                var position = div.InnerHTML.Split(new[] { "<br>" }, StringSplitOptions.None)[1].Replace("\t", "")
                    .Replace("\n", "");

                result.Add(EnumToStringService.StringToPosition(position));
            }

            divs = doc[".hauptposition-center"];

            foreach (var div in divs)
            {
                var position = div.InnerHTML.Split(new[] { "<br>" }, StringSplitOptions.None)[1].Replace("\t", "")
                    .Replace("\n", "");

                result.Add(EnumToStringService.StringToPosition(position));
            }

            divs = doc[".nebenpositionen"];

            foreach (var div in divs)
            {
                var pos = div.InnerHTML.Split(new[] { "<br>" }, StringSplitOptions.None);

                for (var i = 1; i < pos.Length; i++)
                {
                    var position = pos[i].Replace("\t", "").Replace("\n", "");

                    result.Add(EnumToStringService.StringToPosition(position));
                }
            }

            while (result.Count < 3)
            {
                result.Add(null);
            }

            isInjured = doc[".verletzungsbox"].Length > 0;

            return (result, isInjured);
        }

        private static string GetData(string url)
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
    }
}
