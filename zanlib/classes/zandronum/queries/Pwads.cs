using System.Collections.Generic;

namespace Zanlib
{
    public class Pwads: ZandronumQuery
    {
        private const int SQF_PWADS = 0x00000040;

        public Pwads(NetworkHelper networkHelper) : base(networkHelper) { }

        /// <summary>
        /// Returns the pwads loaded by the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string[] Get()
        {
            var result = _networkHelper.GetMessageFromServer(SQF_PWADS);
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
