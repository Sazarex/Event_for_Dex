using System;

namespace Event_for_Dex
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
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
