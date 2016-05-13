using System.IO;
using System.Text;

namespace RacingMachinez.Plugins.ProjectCars
{
    internal static class UnmanagedMemoryAccessorExtensions
    {
        public static string ReadString(this UnmanagedMemoryAccessor memoryAccessor, long position, int length)
        {
            var message = new StringBuilder();
            for (var i = position; i < position + length; i++)
            {
                var asciiChar = (char)memoryAccessor.ReadByte(i);
                if (asciiChar != 0)
                {
                    message.Append(asciiChar);
                }
            }

            return message.ToString();
        }
    }
}