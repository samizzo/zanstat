namespace Zanlib
{
    public static class MapName
    {
        private const int SQF_MAPNAME = 0x00000008;

        /// <summary>
        /// Returns the current map name running on the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_MAPNAME, hostname, port);
            string mapName;
            MessageHelpers.GetStringFromMessage(result, out mapName);
            return mapName;
        }
    }
}
