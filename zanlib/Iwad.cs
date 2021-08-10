using System.Collections.Generic;

namespace Zanlib
{
    public static class Iwad
    {
        private const int SQF_IWAD = 0x00000200;

        /// <summary>
        /// Returns the iwad used by the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_IWAD, hostname, port);
            string iwad;
            MessageHelpers.GetStringFromMessage(result, out iwad);
            return iwad;
        }
    }
}
