using System;

namespace MenuItems
{
    class MenuItem
    {
        public string Name;
        public string HotKey;
        public MenuItem[] SubMenu;

        public void PrintMenuInfo()
        {
            Console.Write($"{Name} ({HotKey}), ");

            if (SubMenu != null)
            {
                Console.Write("подменю: ");
                foreach (var item in SubMenu)
                    item.PrintMenuInfo();
            }
        }
    }
}
