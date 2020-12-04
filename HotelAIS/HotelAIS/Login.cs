using System;
using System.Collections;
using System.Windows;
using UnityEngine;

namespace HotelAIS
{
    public class Login
    {
        public string login, pass, role;
        private string feedBack;

        public void Logining()
        {
            MessageBox.Show(feedBack);
        }

        public IEnumerator CheckLogin()
        {
            WWWForm form = new WWWForm(); // Создание формы
            form.AddField("login", login); // Добавление полей для таблицы
            form.AddField("pass", pass);
            form.AddField("role", role);

            WWW www = new WWW("http://26.146.217.182/login-user.php", form); // Отправка формы на сервер
            yield return www; // Ждём ответа
            if (www.error != null)
            {
                Debug.Log("Ошибка: " + www.error); // Выводи ошибку 
                yield break;
            }

            // Просто вывод в консоль, на всякий случай, при надобности комментируется
            Debug.Log("Сервер ответил: " + www.text);

            feedBack = www.text; // Обработка сообщений
            MessageBox.Show(feedBack);

            try
            {
                feedBack = feedBack.Remove(feedBack.IndexOf("!") + 1);
                role = feedBack.Substring(feedBack.IndexOf("!") + 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                // ignore
            }

            if (feedBack == "Вход выполнен успешно!")
            {
                yield return true;
            }
        }
    }
}