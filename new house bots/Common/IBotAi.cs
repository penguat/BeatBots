namespace Common
{
    public interface IBotAi
    {
        string GetMove();
        void SetLastOpponentsMove(string lastOpponentsMove);
        void SetStartValues(string opponentName, int pointToWin, int maxRounds, int dynamiteCount);
    }
}
