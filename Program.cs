using System.Text;
using System.Security.Cryptography;

namespace txt2md5
{
    internal class Program
    {
        public static string GetMD5(string input)
        {
            using MD5 md5 = MD5.Create();
            return Convert.ToHexString(md5.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }

        private static void Main(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                string[] lines = File.ReadAllLines(args[0]);

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = GetMD5(lines[i]);
                }
                if (args.Length > 1)
                {
                    File.WriteAllLines(args[1], lines);
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, lines));
                }
            }
            else
            {
                Console.WriteLine("Usage: txt2md5.exe <file> [output]");
            }
        }
    }
}