using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using static System.Console;

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
        public readonly string[] passTxt = { " Parolni kiriting : ", " Введите пароль : ", " Enter pssword : " };
        public readonly string[] welcom = { " -= Hushkelibsiz =-"," -= Добропожаловать =- ", " -= Wellcom =-" };
        public readonly string[] choseMenu = {" Menudan birini tanlang ", " Выберите пункт из меню ", " Chose one punkt in menu "};
        public readonly string[] menuS = {" 1.Hisobingizdi korish \n 2.Naqt pul yechish \n 3.Pul tashlash \n 4.Sms hizmatlari \n 5.Parolni almashtirish",
                                          " 1.Посмотреть баланс \n 2.Выдача наличных \n 3.Отправка средств \n 4.СМС услуги \n 5.Смена пороля",
                                          " 1.Check your balans \n 2.Givs nul maney \n 3.Pay money \n 4.Sms function \n 5.Update your password"};
    }
    public class Menu : Language
    {
        public void startMenu()
        {
            metka:
            for (int i = 0; i < chose.Length; i++)
            {
                Write(chose[i]);
            }
            WriteLine();
            Write("-= : ");
            try
            {
                int choseLang = int.Parse(ReadLine()!);
                switch (choseLang)
                {
                    case 1:
                        {
                            Clear();
                            UZB uZB = new UZB();
                            uZB.uzb();
                        }; break;
                    case 2:
                        {
                            Clear();
                            RU rU = new RU();
                            rU.ru();
                        }; break;
                    case 3:
                        {
                            Clear();
                            ENG eNG = new ENG();
                            eNG.eng();
                        }; break;
                    default: Clear(); goto metka;
                }
            }catch (Exception e)
            {
                WriteLine(e);
            }
        }
        public static int passwdForEnter = 0000;
        public void enterPasswd()
        {
            Write(passTxt[0]);
            try
            {
                int passwdEnter = int.Parse(ReadLine()!);
                if(passwdEnter == passwdForEnter)
                {

                }
            }
            catch(Exception e)
            {
                WriteLine(e);
            }
        }
    }
    public class UZB : Language
    {
        public void uzb()
        {
            Write($"{welcom[0]}\n\n{choseMenu[0]}\n\n{menuS[0]}\n\n -= : ");
        }
    }
    public class RU : Language
    {
        public void ru()
        {
            Write($"{welcom[1]}\n\n{choseMenu[1]}\n\n{menuS[1]}\n\n -= : ");
        }
    }
    public class ENG : Language
    {
        public void eng()
        {
            Write($"{welcom[2]}\n\n{choseMenu[2]}\n\n{menuS[2]}\n\n -= : ");
        }
    }
}
