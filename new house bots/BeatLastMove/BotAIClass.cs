using System;
using System.Collections.Generic;
using Common;
using static System.String;


namespace BotExample
{
    internal class BotAIClass :IBotAi
    {
        private string _opponentName;
        private string _lastOpponentsMove;
        private string _lastMove;
        private int _pointstoWin;
        private int _maxRounds;
        private int _dynamite;
        private readonly Random _random = new Random();

        /* Method called when start instruction is received
         *
         * POST http://<your_bot_url>/start
         *
         */
        public void SetStartValues(string opponentName, int pointstoWin, int maxRounds, int dynamite)
        {
            _opponentName = opponentName;
            _pointstoWin = pointstoWin;
            _maxRounds = maxRounds;
            _dynamite = dynamite;
        }

        /* Method called when move instruction is received instructing opponents move
         *
         * POST http://<your_bot_url>/move
         *
         */
        public void SetLastOpponentsMove(string lastOpponentsMove)
        {
            _lastOpponentsMove = lastOpponentsMove;
        }


        /* Method called when move instruction is received requesting your move
         *
         * GET http://<your_bot_url>/move
         *
         */
        public string GetMove()
        {
            if (IsNullOrWhiteSpace(_lastOpponentsMove))
                return Move.GetMoves()[_random.Next(4)].MoveName;

            return GetRandom(Move.Parse(_lastOpponentsMove).GetBeatingMoves()).MoveName;
        }

        private Move GetRandom(List<Move> moves)
        {
            return moves[_random.Next(moves.Count)];
        }
    }
}
