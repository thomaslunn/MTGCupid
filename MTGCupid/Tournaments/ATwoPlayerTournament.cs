using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    internal abstract class ATwoPlayerTournament : ATournament
    {
        protected ATwoPlayerTournament(List<string> players) : base(players)
        {
        }

        protected bool CreatePairings(List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<(int p1, int p2)> matches)
        {
            return CreatePairings(Players, unpairedPlayers, out matches);
        }

        protected bool CreatePairings(IList<Player> playerSource, List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<(int p1, int p2)> matches)
        {
            // Try to match the first unpaired player with the closest new opponent
            int p1 = unpairedPlayers[0];
            unpairedPlayers.RemoveAt(0);

            for (int i = 0; i < unpairedPlayers.Count; i++)
            {
                int p2 = unpairedPlayers[i];

                if (playerSource[p1].HasPlayed(playerSource[p2]))
                    continue; // Player already played this opponent

                unpairedPlayers.RemoveAt(i);

                if (unpairedPlayers.Count == 0) // Pairing is complete
                {
                    matches = new List<(int p1, int p2)>() { (p1, p2) };
                    return true;
                }
                if (CreatePairings(playerSource, unpairedPlayers, out matches))
                {
                    // Insert at beginning so that higher ranked players are at the top of the list
                    matches.Insert(0, (p1, p2));
                    return true;
                }
                unpairedPlayers.Insert(i, p2);
            }

            // Pairing unsuccessful
            unpairedPlayers.Insert(0, p1);
            matches = null;
            return false;
        }
    }
}
