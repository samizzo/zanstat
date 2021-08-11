namespace Zanlib
{
    public class MapName: ZandronumQuery
    {
        private const int SQF_MAPNAME = 0x00000008;

        public MapName(NetworkHelper networkHelper) : base(networkHelper) { }

        /// <summary>
        /// Returns the current map name running on the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string Get()
        {
            var result = _networkHelper.GetMessageFromServer(SQF_MAPNAME);
            MessageHelpers.GetStringFromMessage(result, out string mapName);
            return mapName;
        }
    }
}
