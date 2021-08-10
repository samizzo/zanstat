namespace Zanlib
{
    public static class Skill
    {
        private const int SQF_GAMESKILL = 0x00001000;

        /// <summary>
        /// Returns the skill level on the server
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static byte Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_GAMESKILL, hostname, port);
            byte skill;
            MessageHelpers.GetByteFromMessage(result, out skill);
            return skill;
        }
    }
}
