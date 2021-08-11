using System;

namespace Zanlib
{
    public class ServerDeniedException : Exception
    {
        public static ServerDeniedException Make(int response)
        {
            if (response == 5660024)
            {
                return new ServerDeniedException(response, "Too many requests");
            }
            else
            {
                return new ServerDeniedException(response, "IP is banned");
            }
        }

        public int Response { get; private set; }

        public ServerDeniedException(int response, string message) : base(message)
        {
            Response = response;
        }
    }
}
