using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using static System.Console;

namespace Bankamat
{
    internal class Program
    {
        static void Main(string[] args)//Run time
        {
            Menu menu = new Menu();
            menu.startMenu();
        }
    }
    public class Language// Локализация
    {
        public readonly string[] chose = { " -= Tilni tanlang ", " Виберите язык ", " Chose language =- \n\n " +
                "        -= Uzb = 1 , Ru = 2 , Eng = 3 =- \n" };
        public readonly string[] passTxt = { " Parolni kiriting : ", " Введите пароль : ", " Enter pssword : " };
        public readonly string[] passTxtIsNotTrue = { " Parolingiz hato \n", " Введеный пароль неправельно \n", " Entered pssword is not true \n" };
        public readonly string[] welcom = { " -= Hushkelibsiz =-"," -= Добропожаловать =- ", " -= Wellcom =-" };
        public readonly string[] choseMenu = {" Menudan birini tanlang ", " Выберите пункт из меню ", " Chose one punkt in menu "};
        public readonly string[] menuS = {" 1.Hisobingizdi korish \n 2.Naqt pul yechish \n 3.Pul tashlash \n 4.Sms hizmatlari \n 5.Parolni almashtirish",
                                          " 1.Посмотреть баланс \n 2.Выдача наличных \n 3.Отправка средств \n 4.СМС услуги \n 5.Смена пороля",
                                          " 1.Check your balans \n 2.Givs nul maney \n 3.Pay money \n 4.Sms function \n 5.Update your password"};
        public readonly string[] lookBalans = { "  Sizning hisobingizda - ", "   На вашем шету - ", "  You have got - "};
    }
    public class Menu : Language
    {
        static int choseLang;//Переменая для выбора языка
        int choseMenu1;//Переменая для выбора пункта меню
        public static int passwdForEnter = 1111;//Пароль неизменая //Exepation with 0000
        static bool folsePasswd = false;//Переменая для утверждения пароля
        static double Balans = 100000;//Переменая для баланса
        public void viborMenu() //Меню для выбора
        {
            try
            {
                choseMenu1 = int.Parse(ReadLine()!);
                switch (choseMenu1)
                {
                    case 1:
                        {
                            balans();
                        }break;
                        case 2:
                        {
                            money();
                        }break;
                        case 3:
                        {
                            sendMoney();
                        }break;
                        case 4:
                        {
                            sms();
                        }break;
                        case 5:
                        {
                            password();
                        }break;
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.ToString());
            }
        }
        public void startMenu() // Меню окно выброра
        {
        metka:
            for (int i = 0; i < chose.Length; i++)//Вывод выбора языка
            {
                Write(chose[i]);
            }
            WriteLine();
            Write(" -= : ");
            try
            {
                choseLang = int.Parse(ReadLine()!);
                switch (choseLang)
                {
                    case 1:
                        {
                            Clear();
                            EnterPasswd();
                            if (folsePasswd == true)
                            {
                                Clear();
                                UZB uZB = new UZB();
                                uZB.uzb();
                            }
                        }; break;
                    case 2:
                        {
                            Clear();
                            EnterPasswd();
                            if (folsePasswd == true)
                            {
                                Clear();
                                RU rU = new RU();
                                rU.ru();
                            }
                        }; break;
                    case 3:
                        {
                            Clear();
                            EnterPasswd();
                            if (folsePasswd == true)
                            {
                                Clear();
                                ENG eNG = new ENG();
                                eNG.eng();
                            }
                        }; break;
                    default: Clear(); goto metka;
                }
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }
        public void EnterPasswd()//Функция проверки пороля
        {
        metka:
            switch (choseLang)//Приведствие
            {
                case 1:
                    {
                        Write(passTxt[0]);
                    }; break;
                case 2:
                    {
                        Write(passTxt[1]);
                    }; break;
                case 3:
                    {
                        Write(passTxt[2]);
                    }; break;
            }
            try
            {
                int passwdEnter = int.Parse(ReadLine()!);
                if (passwdEnter == passwdForEnter)
                {
                    folsePasswd = true;
                }
                else//Если не правельно 
                {
                    switch (choseLang)
                    {
                        case 1:
                            {
                                Clear();
                                WriteLine(passTxtIsNotTrue[0]);
                                goto metka;
                            };
                        case 2:
                            {
                                Clear();
                                WriteLine(passTxtIsNotTrue[1]);
                                goto metka;
                            };
                        case 3:
                            {
                                Clear();
                                WriteLine(passTxtIsNotTrue[2]);
                                goto metka;
                            };
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }
        public void balans()//Просмотр баланса
        {
            switch (choseLang)
            {
                case 1:
                    {
                        metka:
                        Clear();
                        Write("   " + welcom[0]);
                        Write("   \n\n" + lookBalans[0] + Balans + " som bor\n\n");
                        Write("  <-- ");
                        string a = ReadLine()!;
                        if(a == string.Empty)
                        {
                            Clear();
                            Write($"  {welcom[0]} \n\n{menuS[0]} \n\n =- ");
                            viborMenu();
                        }
                        else
                        {
                            goto metka;
                        }
                    }
                    break;
                case 2:
                    {
                        metka:
                        Clear();
                        Write("   " + welcom[1]);
                        Write("   \n\n" + lookBalans[1] + Balans + " сум есть\n\n");
                        Write("  <-- ");
                        string a = ReadLine()!;
                        if (a == string.Empty)
                        {
                            Clear();
                            Write($"  {welcom[1]} \n\n{menuS[1]} \n\n =- ");
                            viborMenu();
                        }
                        else
                        {
                            goto metka;
                        }
                    }
                    break;
                case 3:
                    {
                        metka:
                        Clear();
                        Write("   " + welcom[2]);
                        Write("   \n\n" + lookBalans[2] + Balans + " som\n\n");
                        Write("  <-- ");
                        string a = ReadLine()!;
                        if (a == string.Empty)
                        {
                            Clear();
                            Write($"  {welcom[2]} \n\n{menuS[2]} \n\n =- ");
                            viborMenu();
                        }
                        else
                        {
                            goto metka;
                        }
                    }
                    break;
            }
        }
        public void money()
        {
            WriteLine("Money");
        }
        public void sendMoney() 
        {
            WriteLine("Send money");
        }
        public void sms()
        {
            WriteLine("sms");
        }
        public void password()
        {
            WriteLine("Passwd");
        }
    }
    public class UZB : Language // Локализация Узбекского языка
    {
        public void uzb()
        {
            Write($"{welcom[0]}\n\n{choseMenu[0]}\n\n{menuS[0]}\n\n -= : ");
            Menu menu = new Menu();
            menu.viborMenu();
        }
    }
    public class RU : Language // Локализация Русскаого языка
    {
        public void ru()
        {
            Write($"{welcom[1]}\n\n{choseMenu[1]}\n\n{menuS[1]}\n\n -= : ");
            Menu menu = new Menu();
            menu.viborMenu();
        }
    }
    public class ENG : Language  // Локализация Ангийского языка
    {
        public void eng()
        {
            Write($"{welcom[2]}\n\n{choseMenu[2]}\n\n{menuS[2]}\n\n -= : ");
            Menu menu = new Menu();
            menu.viborMenu();
        }
    }
}
