using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Timers;
using System.Text;
using System.Resources;
using System.Windows.Forms;

namespace iPhone_X_Virus
{
    public class BasicClass
    {
        private static int UpdateRateInMs = 1;
        public static string englishAlphabet = @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789@!$#%& ";

        /// <summary>
        /// Just the basic main method.
        /// </summary>
        public static void Main()
        {
            Parallel.Invoke(() => CallAllStartMethods(), () => CallAllUpdateMethods());
        }
        /// <summary>
        /// Use this for preventing immediate console closeing.
        /// </summary>
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        /// <summary>
        /// Use this for finding all the classes or types in an namespace.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
        /// <summary>
        /// Calls all "Start" methods in all classes deriveing from this class
        /// </summary>
        public static void CallAllStartMethods ()
        {
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsSubclassOf(typeof(BasicClass)))
                {
                    MethodInfo method = t.GetMethod("Start");
                    if (method != null)
                        if (method.IsStatic)
                            method.Invoke(null, null);
                }
            }
        }
        /// <summary>
        /// Calls all "Update" methods in all classes deriveing from this class
        /// </summary>
        public static void CallAllUpdateMethods ()
        {
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsSubclassOf(typeof(BasicClass)))
                {
                    MethodInfo method = t.GetMethod("Update");
                    if (method != null)
                    {
                        if (method.IsStatic)
                        {
                            while (true)
                            {
                                method.Invoke(null, null);
                                Thread.Sleep(UpdateRateInMs);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets the update rate for use outside of this class.
        /// </summary>
        /// <returns></returns>
        public static int GetUpdateRate ()
        {
            return UpdateRateInMs;
        }
        /// <summary>
        /// Use this to get an random integer between the two values that you put in.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumberInt (int min, int max)
        {
            Random random = new Random();
            int randomNumberInt = random.Next(min, max);
            return randomNumberInt;
        }
        /// <summary>
        /// Use this to get an random double between 0 and 1.
        /// </summary>
        /// <returns></returns>
        public static double GetRandomNumberDouble()
        {
            Random random = new Random();
            double randomNumberdouble = random.NextDouble();
            return randomNumberdouble;
        }
        /// <summary>
        /// Use this to clear the current line.
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        /// <summary>
        /// Use this to type an text character by character.
        /// </summary>
        /// <param name="line"></param>
        public static void TypeLine(string line, int delay = 150)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(delay);
            }
        }
        /// <summary>
        /// Use this to wait an surten ammount of miliseconds.
        /// </summary>
        /// <param name="Time"></param>
        public static void Sleep (int Time)
        {
            Thread.Sleep(Time);
        }
        /// <summary>
        /// Use this to start an process using an path.
        /// 
        /// Usage: add before the string an @ for this to work at all.
        /// </summary>
        /// <param name="path"></param>
        public static void StartProcess (string path)
        {
            Process.Start(path);
        }
        public static string GenerateRandomStringFromAlphabet (string _alphabet)
        {
            int length = new Random().Next(1, _alphabet.Length);
            string password = "";
            for (int i = 0; i < length; i++)
            {
                int pos = new Random().Next(1, _alphabet.Length);
                char currentChar = _alphabet[pos];
                password += currentChar;
                Thread.Sleep(1);
            }
            return password;
        }
        public static string GetDesktopPath ()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return path;
        }
        public static string FilePathToFileUrl(string filePath)
        {
            StringBuilder uri = new StringBuilder();
            foreach (char v in filePath)
            {
                if ((v >= 'a' && v <= 'z') || (v >= 'A' && v <= 'Z') || (v >= '0' && v <= '9') ||
                  v == '+' || v == '/' || v == ':' || v == '.' || v == '-' || v == '_' || v == '~' ||
                  v > '\xFF')
                {
                    uri.Append(v);
                }
                else if (v == Path.DirectorySeparatorChar || v == Path.AltDirectorySeparatorChar)
                {
                    uri.Append('/');
                }
                else
                {
                    uri.Append(String.Format("%{0:X2}", (int)v));
                }
            }
            if (uri.Length >= 2 && uri[0] == '/' && uri[1] == '/') // UNC path
                uri.Insert(0, "file:");
            else
                uri.Insert(0, "file:///");
            return uri.ToString();
        }
    }
}
