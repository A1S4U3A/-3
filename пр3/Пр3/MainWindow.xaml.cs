using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Пр3
{
    public partial class MainWindow : Window// Список пользователей который будет хранить объекты типа User
    {
        private static List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        void Load()// Метод для загрузки нового пользователя из текстовых полей
        {
            users.Add(new User
            {
                id = Convert.ToInt32(i.Text),// Преобразуем текст из поля ввода в целое число
                name = nam.Text,// Получаем имя
                password = passwor.Text,// Получаем пароль
            });
        }

        public class User// Класс User, представляющий пользователя
        {
            public int id { get; set; }// Свойство для хранения идентификатора пользователя
            public string name { get; set; }// Свойство для хранения имени пользователя
            public string password { get; set; }// Свойство для хранения пароля пользователя

            public override string ToString() // Переопределяем ToString
            {
                return $"ID: {id}, Name: {name}";// Возвращаем строку с ID и именем
            }
        }

        private void ba_Click(object sender, RoutedEventArgs e)// Обработчик события нажатия кнопки "Добавить"
        {
            Load();// Загружаем нового пользователя
            lia.Items.Clear();// Очищаем список
            foreach (var item in users)// Перебираем всех пользователей
            {
                lia.Items.Add(item);// Добавляем каждого пользователя в ListBox
            }
        }

        private void ShakeSort(List<User> arr)// Метод сортировки пользователей методом "Shake Sort"
        {
            int left = 0;// Начальная позиция
            int right = arr.Count - 1;// Конечная позиция
            bool swapped;// Флаг указывающий на необходимость дальнейшей сортировки

            do
            {
                swapped = false;// Сбрасываем флаг
                for (int i = left; i < right; i++)// Проходим слева направо
                {
                    if (arr[i].id > arr[i + 1].id)// Если текущий элемент больше следующего
                    {
                        Swap(arr, i, i + 1); //Меняем их местами
                        swapped = true;// Устанавливаем флаг
                    }
                }
                right--;// Уменьшаем правую границу

                if (swapped)// Если произошла перестановка
                {
                    swapped = false;// Сбрасываем флаг для следующего прохода
                    for (int i = right; i > left; i--)// Проходим справа налево
                    {
                        if (arr[i].id < arr[i - 1].id)// Если текущий элемент меньше предыдущего
                        {
                            Swap(arr, i, i - 1);// Меняем их местами
                            swapped = true;// Устанавливаем флаг
                        }
                    }
                    left++;// Увеличиваем левую границу
                }
            } while (swapped);// Продолжаем пока есть перестановки
        }

        private void btn_SortShake_Click(object sender, RoutedEventArgs e)// Обработчик события нажатия кнопки "Сортировать"
        {
            ShakeSort(users);// Сортируем список пользователей
            lia.Items.Clear();// Очищаем список
            foreach (var item in users)// Перебираем всех пользователей в отсортированном списке
            {
                lia.Items.Add(item);// Добавляем каждого пользователя в ListBox
            }
        }

        private void Swap(List<User> arr, int i, int j)// Метод для обмена элементов списка по индексам i и j
        {
            User temp = arr[i];// Сохраняем элемент i во временной переменной
            arr[i] = arr[j];// Меняем местами элементы i и j
            arr[j] = temp;// Вставляем временный элемент на место j
        }
    }
}