using System;
using Common;


namespace BotExample
{
    internal class BotAIClass :IBotAi
    {
        private readonly Random _random = new Random();


        /* Method called when start instruction is received
         *
         * POST http://<your_bot_url>/start
         *
         */
        public void SetStartValues(string opponentName, int pointstoWin, int maxRounds, int dynamite)
        {
        }

        /* Method called when move instruction is received instructing opponents move
         *
         * POST http://<your_bot_url>/move
         *
         */
        public void SetLastOpponentsMove(string lastOpponentsMove)
        {
        }


        /* Method called when move instruction is received requesting your move
         *
         * GET http://<your_bot_url>/move
         *
         */
        public string GetMove()
        {
            return Move.GetMoves()[_random.Next(4)].MoveName;
        }
    }
}
