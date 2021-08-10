using System.Collections.Generic;

namespace Zanlib
{
    public static class Pwads
    {
        private const int SQF_PWADS = 0x00000040;

        /// <summary>
        /// Returns the pwads loaded by the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string[] Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_PWADS, hostname, port);
            byte numPwads;
            result = MessageHelpers.GetByteFromMessage(result, out numPwads);

            var pwads = new List<string>();
            for (var i = 0; i < numPwads; i++)
            {
                string pwad;
                result = MessageHelpers.GetStringFromMessage(result, out pwad);
                pwads.Add(pwad);
            }

            return pwads.ToArray();
        }
    }
}
