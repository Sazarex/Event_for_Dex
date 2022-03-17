using System;

namespace Event_for_Dex
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testingEvents no matter
            //Console.WriteLine("Enter the message:");
            //string mes = Console.ReadLine();

            //MailManager DNKMailManager = new MailManager();
            //Printer HP_LJ1012 = new Printer("Hewlett-Packard LaserJet 1012", DNKMailManager);
            //TV LG = new TV("LG 202029", DNKMailManager);
            //Sms sms = new Sms(DNKMailManager);
            //DNKMailManager.SimultateSendingMail(mes);
            //HP_LJ1012.Dispose();
            //LG.Dispose();
            //sms.Dispose();

            #endregion

            Person Valeriy = new Person("Валерий", 77711567, "Прага");
            AccountingSystem GoogleAccountSystem = new AccountingSystem();
            GoogleAccountSystem.AddToSource(Valeriy);

            Valeriy.Name = "Владимир";
            Valeriy.PhoneNumber = 77521543;
            Valeriy.CityOfResidence = "Осло";
            Valeriy.GetInfo();


            Person Egor = new Person("Егор", 77712467, "Стамбул");
            GoogleAccountSystem.AddToSource(Egor);
            Egor.Name = "Абдулла";

            Group VKMusic = new Group("ВК музыка");
            GoogleAccountSystem.AddToSource(VKMusic);
            VKMusic.AddPost();
            VKMusic.Title = "Смешные приколы";

            GoogleAccountSystem.Dispose();

        }
    }
}
