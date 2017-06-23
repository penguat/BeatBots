using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Move
    {
        public const string Rock = "ROCK";
        public const string Paper = "PAPER";
        public const string Scissors = "SCISSOR";
        public const string Dynamite = "DYNAMITE";
        public const string Waterbomb = "WATERBOMB";

        public static List<Move> GetMoves()
        {
            return new List<Move>
            {
                new Move(Rock, new List<string>{Scissors, Waterbomb}),
                new Move(Paper, new List<string>{Rock, Waterbomb}),
                new Move(Scissors, new List<string>{Paper, Waterbomb}),
                new Move(Dynamite, new List<string>{Rock, Paper, Scissors}),
                new Move(Waterbomb, new List<string>{Dynamite})
            };
        }

        public static Move Parse(string moveToParse)
        {
            return GetMoves().Single(m => m.MoveName == moveToParse.ToUpper());
        }

        public string MoveName { get; private set; }
        private List<string> _winsAgainst;


        public Move(string moveName, List<string> winsAgainst)
        {
            _winsAgainst = winsAgainst;
            MoveName = moveName;
        }

        public bool WinsAgainst(Move otherMove)
        {
            return _winsAgainst.Contains(otherMove.MoveName);
        }

        public bool DrawsWith(Move otherMove)
        {
            return MoveName == otherMove.MoveName;
        }

        public List<Move> GetBeatingMoves()
        {
            return GetMoves().FindAll(m => m.WinsAgainst(this));
        }
    }
}
