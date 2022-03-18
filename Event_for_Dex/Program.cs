using System;

namespace Event_for_Dex
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем класс с событием
            Person Valeriy = new Person("Валерий", 77711567, "Прага");
            //Создаем класс-подписчик
            AccountingSystem GoogleAccountSystem = new AccountingSystem();
            //Подписываемся на событие
            GoogleAccountSystem.AddToSource(Valeriy);
            //Меняем значения свойств и смотрим на вызов событий.
            Valeriy.Name = "Владимир";
            Valeriy.PhoneNumber = 77521543;
            Valeriy.CityOfResidence = "Осло";
            //Проверяем информацию об объекте
            Valeriy.GetInfo();


            //Создаем ещё класс с событием
            Person Egor = new Person("Егор", 77712467, "Стамбул");
            //Подписываемся на этот класс с событием
            GoogleAccountSystem.AddToSource(Egor);
            //Меняем значение свойства имени и срабатывает событие
            Egor.Name = "Абдулла";
            //Создаем другой класс с событием, который реализует интерфейс с этим событием
            Group VKMusic = new Group("ВК музыка");
            //Подписываемся на событие
            GoogleAccountSystem.AddToSource(VKMusic);
            //Изменяем свойства объекта и вызывается событие
            VKMusic.AddPost();
            VKMusic.Title = "Смешные приколы";

            //Отписываемся у подписчика от всех объектов с событиями.
            GoogleAccountSystem.Dispose();

        }
    }
}
