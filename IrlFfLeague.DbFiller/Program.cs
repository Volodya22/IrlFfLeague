using System.Collections.Generic;

namespace IrlFfLeague.DbFiller
{
    class Program
    {
        private static List<string> _leagues = new List<string>
        {
            // EPL
            "https://www.transfermarkt.com/premier-league/startseite/wettbewerb/GB1",
            // RPL
            "https://www.transfermarkt.com/premier-liga/startseite/wettbewerb/RU1",
            // La Liga
            "https://www.transfermarkt.com/primera-division/startseite/wettbewerb/ES1",
            // Serie A
            "https://www.transfermarkt.com/serie-a/startseite/wettbewerb/IT1"
        };

        static void Main(string[] args)
        {
            foreach (var league in _leagues)
            {
                ParseLeague(league);
            }
        }

        static void ParseLeague(string url)
        {

        }
    }
}
