using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Event_for_Dex
{
    /// <summary>
    /// Класс сообщества(группы)
    /// </summary>
    class Group: INotifyPropertyChanged
    {
        /// <summary>
        /// Поля
        /// </summary>
        private string title;
        private int postsCount;

        /// <summary>
        /// Свойства
        /// </summary>
        public string Title
        {
            private get
            {
                return title;
            }

            set
            {
                if (value!= null)
                {
                    On_PropertyChanged($"Группа {title} сменила название на {value}");
                    title = value;
                }
            }

        }

        private int PostsCount
        {
            get
            {
                return postsCount;
            }

            set
            {
                On_PropertyChanged($"Количество записей в группе {Title} пополнилось.");
                postsCount += value;
            }
        }

        /// <summary>
        /// Метод, имитирующий добавление поста в группу
        /// </summary>
        public void AddPost()
        {
            PostsCount++;
        }

        /// <summary>
        /// Событие
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод вызывающий событие.
        /// </summary>
        /// <param name="message">Сообщение при вызове события</param>
        private void On_PropertyChanged(string message="nothing")
        {
            PropertyChangedEventHandler eventHandler = PropertyChanged;
            eventHandler?.Invoke(this, new PropertyChangedEventArgs(message));
        }


        /// <summary>
        /// Информация о группе
        /// </summary>
        public void GetInfo()
        {
            Console.WriteLine($"У группы {Title} {PostsCount} записей.");
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="title">Название группы</param>
        public Group(string title)
        {
            Title = title;
            PostsCount = 0;
        }
    }
}
