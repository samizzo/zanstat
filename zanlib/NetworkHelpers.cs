using System.Net;
using System.Net.Sockets;

namespace Zanlib
{
    internal static class NetworkHelpers
    {
        public static byte[] GetMessageFromServer(int serverQueryFlag, string hostname, int port)
        {
            var udpClient = new UdpClient();

            try
            {
                var compressedMessage = MessageHelpers.GetCompressedMessage(serverQueryFlag);
                udpClient.Connect(hostname, port);
                udpClient.Send(compressedMessage, compressedMessage.Length);

                var remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
                var compressedResult = udpClient.Receive(ref remoteEndpoint);
                var result = Huffman.Decode(compressedResult);

                int response;
                result = MessageHelpers.GetIntFromMessage(result, out response);
                if (response != 5660023)
                {
                    throw ServerDeniedException.Make(response);
                }

                int time;
                result = MessageHelpers.GetIntFromMessage(result, out time);

                string serverVersion;
                result = MessageHelpers.GetStringFromMessage(result, out serverVersion);

                int flags;
                result = MessageHelpers.GetIntFromMessage(result, out flags);

                return result;
            }
            finally
            {
                udpClient.Close();
            }
        }
    }
}
