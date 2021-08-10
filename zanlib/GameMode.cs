namespace Zanlib
{
    public enum GameMode
    {
        Cooperative = 0,
        Survival,
        Invasion,
        Deathmatch,
        Teamplay,
        Duel,
        Terminator,
        LastManStanding,
        TeamLastManStanding,
        Possession,
        TeamPossession,
        TeamGame,
        CTF,
        OneFlagCTF,
        Skulltag,
        Domination
    }

    public static class GameModeExtension
    {
        public static bool IsTeamGame(this GameMode gameMode)
        {
            return gameMode == GameMode.TeamGame || gameMode == GameMode.TeamLastManStanding || gameMode == GameMode.Teamplay || gameMode == GameMode.TeamPossession;
        }
    }
}
