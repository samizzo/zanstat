using System.Collections.Generic;

namespace Zanlib
{

    public class Iwad: ZandronumQuery
    {
        private const int SQF_IWAD = 0x00000200;

        public Iwad(NetworkHelper networkHelper) : base(networkHelper) { }

        /// <summary>
        /// Returns the iwad used by the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string Get()
        {
            var result = _networkHelper.GetMessageFromServer(SQF_IWAD);
            MessageHelpers.GetStringFromMessage(result, out string iwad);
            return iwad;
        }
    }
}
