using System;
using System.Text;

namespace Zanlib
{
    internal static class MessageHelpers
    {
        private const int LAUNCHER_CHALLENGE = 199;

        /// <summary>
        /// Parses a null terminated ASCII string from the input byte data and returns the remaining byte data after the string, as well as the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetStringFromMessage(byte[] input, out string str)
        {
            var nullTerminatorIndex = input.Length;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                {
                    nullTerminatorIndex = i;
                    break;
                }
            }

            str = Encoding.ASCII.GetString(input[0..nullTerminatorIndex]);

            var remaining = input[(nullTerminatorIndex + 1)..];
            return remaining;
        }

        /// <summary>
        /// Converts the four bytes at the start of `input` to an int value and returns the remaining byte data after the int value.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] GetIntFromMessage(byte[] input, out int val)
        {
            val = BitConverter.ToInt32(input[0..4]);
            var remaining = input[4..];
            return remaining;
        }

        /// <summary>
        /// Converts the two bytes at the start of `input` to a short value and returns the remaining byte data after the short value.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] GetShortFromMessage(byte[] input, out short val)
        {
            val = BitConverter.ToInt16(input[0..2]);
            var remaining = input[2..];
            return remaining;
        }

        /// <summary>
        /// Converts the two bytes at the start of `input` to a byte value and returns the remaining byte data after the byte value.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] GetByteFromMessage(byte[] input, out byte val)
        {
            val = input[0];
            var remaining = input[1..];
            return remaining;
        }

        /// <summary>
        /// Returns a message of type `messageType` for sending to the server.
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static byte[] GetMessage(int messageType)
        {
            var message = new int[3];
            message[0] = LAUNCHER_CHALLENGE;
            message[1] = messageType;
            message[2] = 0; // Time field - unused.

            var byteMessage = new byte[message.Length * sizeof(int)];
            Buffer.BlockCopy(message, 0, byteMessage, 0, byteMessage.Length);
            return byteMessage;
        }
    }
}
