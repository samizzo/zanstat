using System.Net;
using System.Net.Sockets;

namespace Zanlib
{
    public class NetworkHelper
    {
        private readonly string _hostname;
        private readonly int _port;
        private readonly UdpClient _udpClient;
        private readonly Huffman _huffman;

        public NetworkHelper(string hostname, int port)
        {
            _hostname = hostname;
            _port = port;

            _udpClient = new UdpClient();
            _huffman = new Huffman();
        }

        ~NetworkHelper()  // finalizer
        {
            _udpClient.Close();
        }


        public byte[] GetMessageFromServer(int serverQueryFlag)
        {
            byte[] message = MessageHelpers.GetMessage(serverQueryFlag);
            var compressedMessage = _huffman.Encode(message);

            _udpClient.Connect(_hostname, _port);
            _udpClient.Send(compressedMessage, compressedMessage.Length);

            var remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
            var compressedResult = _udpClient.Receive(ref remoteEndpoint);
            var result = _huffman.Decode(compressedResult);

            int response;
            result = MessageHelpers.GetIntFromMessage(result, out response);
            if (response != 5660023)
            {
                throw ServerDeniedException.Make(response);
            }

            result = MessageHelpers.GetIntFromMessage(result, out int time);

            result = MessageHelpers.GetStringFromMessage(result, out string serverVersion);

            result = MessageHelpers.GetIntFromMessage(result, out int flags);

            return result;
           
        }
    }
}
