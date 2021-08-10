namespace Zanlib
{
    public static class MaxPlayers
    {
        private const int SQF_MAXPLAYERS = 0x00000020;

        /// <summary>
        /// Returns the maximum number of players for the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static byte Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_MAXPLAYERS, hostname, port);
            byte maxPlayers;
            MessageHelpers.GetByteFromMessage(result, out maxPlayers);
            return maxPlayers;
        }
    }
}
