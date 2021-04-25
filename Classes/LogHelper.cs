using System;
namespace ProjetoBanco.Classes
{
    public class LogHelper
    {
        
        public static void Log(string text, bool inline = false)
        {
            if (inline)
            {
                Console.Write(text);
                return;
            }
            Console.WriteLine(text);
        }
        public static string Input(string text)
        {
            Log(text, true);
            string resultado = Console.ReadLine();
            return resultado;
        }
        public static void Display(string[] list)
        {
            for (int index = 0; index < list.Length; index++)
            {
                Log(list[index]);
            }
        }
    }
}