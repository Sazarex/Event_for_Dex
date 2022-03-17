using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Event_for_Dex
{
    /// <summary>
    /// Класс, определяющий событие и вызов этого события при изменении свойств объекта.
    /// </summary>
    class Person: INotifyPropertyChanged
    {
        #region Поля класса
        private string name;
        private uint phoneNumber;
        private string cityOfResidence;
        #endregion


        #region Свойства
        /// <summary>
        /// При изменении свойств выполняется возов события
        /// </summary>
        public string Name
        {
            private get 
            {
                return name;
            }

            set
            {
                if (value != null)
                {
                    OnPropertyChanged($"У {name} изменилось имя на {value}.");
                    name = value;
                }
            }
        }


        public uint PhoneNumber
        {
            private get
            {
                return phoneNumber;
            }

            set
            {
                if (value > 0)
                {
                    OnPropertyChanged($"У {name} изменился номер телефона с {phoneNumber} на {value}");
                    phoneNumber = value;
                }
            }
        }

        public string CityOfResidence
        {
            private get
            {
                return cityOfResidence;
            }

            set
            {
                if (value != null)
                {
                    OnPropertyChanged($"{name} поменял место проживания с {cityOfResidence} на {value}.");
                    cityOfResidence = value;
                }
            }
        }

        #endregion


        /// <summary>
        /// Объявляем событие
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод вызова события
        /// </summary>
        /// <param name="propertyName">Сообщение, выводимое в случае изменения свойства.</param>
        private void OnPropertyChanged(string message ="nothing")
        {
            PropertyChangedEventHandler handlerOfEvent = PropertyChanged;
            handlerOfEvent?.Invoke(this, new PropertyChangedEventArgs(message));
        }

        /// <summary>
        /// Получение информации о человеке
        /// </summary>
        public void GetInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} \nНомер телефона: {PhoneNumber} \nПроживает в {CityOfResidence}");
            Console.WriteLine();
        }


        /// <summary>
        /// Конструткор класса
        /// </summary>
        /// <param name="Name">Имя человека</param>
        /// <param name="PhoneNubmer">Мобильный телефон человека</param>
        /// <param name="City">Город, в котором проживает человек</param>
        public Person(string Name, uint PhoneNubmer, string City)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNubmer;
            CityOfResidence = City;
        }
    }
}
