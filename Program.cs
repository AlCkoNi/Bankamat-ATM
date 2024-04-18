using System.Threading.Channels;

namespace Bankamat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.startMenu();
        }
    }
    public class Language()
    {
        public readonly string[] chose = { " -= Tilni tanlang ", " Виберите язык ", " Chose language =- \n\n " +
                " -= Uzb = 1 , Ru = 2 , Eng = 3 =- \n" };
        public readonly string[] welcom = { " -= Hushkelibsiz =-"," -= Добропожаловать =- ", " -= Wellcom =-" };
    }
    public class Menu : Language
    {
        public void startMenu()
        {
            metka:
            for (int i = 0; i < chose.Length; i++)
            {
                Console.Write(chose[i]);
            }
            Console.WriteLine();
            Console.Write("-= Tanlovingiz : ");
            try
            {
                int choseLang = int.Parse(Console.ReadLine()!);
                switch (choseLang)
                {
                    case 1:
                        {
                            Console.WriteLine(welcom[0]);
                        }; break;
                    case 2:
                        {
                            Console.WriteLine(welcom[1]);
                        }; break;
                    case 3:
                        {
                            Console.WriteLine(welcom[2]);
                        }; break;
                    default: goto metka;
                }
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    
}
