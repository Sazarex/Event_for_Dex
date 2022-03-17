using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Event_for_Dex
{
    /// <summary>
    /// Класс учета пользователей
    /// </summary>
    sealed class AccountingSystem : IDisposable
    {

        /// <summary>
        /// Коллекция всех объектов содержащих событие
        /// </summary>
        private List<INotifyPropertyChanged> NotifySource = new List<INotifyPropertyChanged>();

        /// <summary>
        /// Обычный конструктор
        /// </summary>
        public AccountingSystem()
        {

        }

        /// <summary>
        /// Перегруженный конструктор класса. Тут мы подписываемся на событие передаваемого объекта.
        /// </summary>
        /// <param name="person">Объект класса Person, который предоставляет событие</param>
        public AccountingSystem(INotifyPropertyChanged source)
        {
            NotifySource.Add(source);
            Subscribe(source);
        }

        /// <summary>
        /// Конструктор, принимающий на вход коллекцию из объектов с событиями.
        /// </summary>
        /// <param name="notifySource"></param>
        public AccountingSystem(List<INotifyPropertyChanged> notifySource)
        {
            NotifySource = notifySource;
            for (int i = 0; i < NotifySource.Count; i++)
            {
                Subscribe(NotifySource[i]);
            }
        }

        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Source_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("*Оповещается AccountingSystem*");
            Console.WriteLine(e.PropertyName);
            Console.WriteLine();
        }

        /// <summary>
        /// Добавление объект с событием в коллекцию нашего класса и сразу подписываемся на этот объект
        /// </summary>
        /// <param name="source"></param>
        public void AddToSource(INotifyPropertyChanged source)
        {
            if (NotifySource.Contains(source))
            {
                Console.WriteLine("Данный элемент присутствует в коллекции.");
            }
            else
            {
                NotifySource.Add(source);
                Subscribe(source);
            }
        }

        /// <summary>
        /// Подписываемся на событие объекта.
        /// </summary>
        /// <param name="source"></param>
        private void Subscribe(INotifyPropertyChanged source)
        {
            source.PropertyChanged += Source_PropertyChanged;
        }

        /// <summary>
        /// Отписываемся от события объекта.
        /// </summary>
        /// <param name="source"></param>
        private void Unsubscribe(INotifyPropertyChanged source)
        {
            source.PropertyChanged -= Source_PropertyChanged;
        }

        /// <summary>
        /// При уничтожении нашего объекта - отписываемся от всех событий.
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < NotifySource.Count; i++)
            {
                Unsubscribe(NotifySource[i]);
            }
            Console.WriteLine();
            Console.WriteLine("*Отписано от всех событий.*");
        }
    }
}
