using System;


namespace MenuItems
{
    class Program
    {
        //Для представления информации о пункте меню отдельном модуле класса нужно создать класс MenuItem

        //Для каждого пункта меню должно храниться название, горячая клавиша
        //и список подменю (null, если подменю нет).

        //В классе создать метод PrintMenuInfo, который должен рапечатывыать в строку название, 
        //грячую клавишу и названия пунктов подменю.
        //Если есть пункты подменю, то в следующих строках должна рапечатвыватся 
        //аналогичная информация по каждому пункту подменю

        
        static MenuItem[] GenerateMenu()
        {
            var menu = new MenuItem[2];
            menu[0] = new MenuItem() { Name = "File", HotKey = "F" };
            menu[0].SubMenu = new MenuItem[2];
            menu[0].SubMenu[0] = new MenuItem() { Name = "New", HotKey = "N" };
            menu[0].SubMenu[1] = new MenuItem() { Name = "Save", HotKey = "S" };
            menu[1] = new MenuItem() { Name = "Edit", HotKey = "E"};
            menu[1].SubMenu = new MenuItem[2];
            menu[1].SubMenu[0] = new MenuItem() { Name = "Copy", HotKey = "C" };
            menu[1].SubMenu[1] = new MenuItem() { Name = "Paste", HotKey = "V" };

            return menu;
            
            //return new[] ...

            //Метод должен создавать следующее меню (горячаие клавиши указаны в скобках):

            //На верхнем уровне должно находится два пункта: File (F) и Edit (E). 
            //Меню File должно содержать команды New (N), Save (S).
            //Меню Edit (E) должно содержать команды Copy (C) и Paste (V).
            //Решите задачу с использованием сокращенного синтаксиса создания классов в одно выражение. 
            //Используйте переводы строк и отступы, чтобы сделать код более читаемым.
        }



        static void Main()
        {
            //Создать меню при помощи метода GenerateMenu 
            //и распечатать информацию о нем, используя метод PrintMenuInfo

            var menu = GenerateMenu();
            foreach (var item in menu)
            {
                item.PrintMenuInfo();
                Console.WriteLine("\b\b ");
            }
                

            Console.ReadKey();

        }
    }
}
