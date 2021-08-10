namespace Zanlib
{
    public static class Name
    {
        private const int SQF_NAME = 0x00000001;

        /// <summary>
        /// Returns the name of the specified server (set via sv_hostname).
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_NAME, hostname, port);
            string serverName;
            MessageHelpers.GetStringFromMessage(result, out serverName);
            return serverName;
        }
    }
}
