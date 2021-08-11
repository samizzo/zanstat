namespace Zanlib
{
    public static class GameModeExtension
    {
        public static bool IsTeamGame(this GameModeEnum gameMode)
        {
            return gameMode == GameModeEnum.TeamGame || gameMode == GameModeEnum.TeamLastManStanding || gameMode == GameModeEnum.Teamplay || gameMode == GameModeEnum.TeamPossession;
        }
    }
}
