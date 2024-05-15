using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace _1laba
{
    internal class ImageWork
    {
        public static void DoWork()
        {
            int actionNumber = Menu.ChoosingAnAction(); // Выбираем нужную нам операцию для работы с изображение

            List<string> ImagesPath = Menu.VyborImage(actionNumber); // Получаем названия путей одного или нескольких изо
                                                                      // в зависимости со сколькими изо работает операция

            Menu.Processing(ImagesPath, actionNumber); // Передаем в switch названия Пути/Путей изо, номер команды




            

        }
    }
}
