namespace Zanlib
{
    public static class Limits
    {
        private const int SQF_LIMITS = 0x00010000;

        public struct Limit
        {
            public short FragLimit;
            public short TimeLimit;
            public short TimeLeft;
            public short DuelLimit;
            public short PointLimit;
            public short WinLimit;

            public override string ToString()
            {
                return $"FragLimit={FragLimit}, TimeLimit={TimeLimit}, TimeLeft={TimeLeft}, DuelLimit={DuelLimit}, PointLimit={PointLimit}, WinLimit={WinLimit}";
            }
        };

        /// <summary>
        /// Returns the limits on the server.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Limit Get(string hostname, int port)
        {
            var result = NetworkHelpers.GetMessageFromServer(SQF_LIMITS, hostname, port);
            var data = new Limit();
            result = MessageHelpers.GetShortFromMessage(result, out data.FragLimit);
            result = MessageHelpers.GetShortFromMessage(result, out data.TimeLimit);
            if (data.TimeLimit > 0)
                result = MessageHelpers.GetShortFromMessage(result, out data.TimeLeft);
            result = MessageHelpers.GetShortFromMessage(result, out data.DuelLimit);
            result = MessageHelpers.GetShortFromMessage(result, out data.PointLimit);
            MessageHelpers.GetShortFromMessage(result, out data.WinLimit);
            return data;
        }
    }
}
