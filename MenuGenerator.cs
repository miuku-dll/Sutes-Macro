using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using MacroForSols;
using DeclarativeConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using main;
using System.Threading.Tasks;


namespace MacroForSols
{
    class MenuGenerator
    {
        public static MenuCollection CreateMenuCollection()
        {
            MenuCollection collection = new MenuCollection();

            //Declarative way of building a menu, there are also generator methods you can use.
            return new MenuCollection()
            {
                Menus = {
                    new Menu()
                    {
                        // give the menu an identifier
                        MenuId = 1,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Features",
                                // if you want to link to another menu, then set the other menu's id
                                SubMenuId = 2
                            },
                            new MenuItem()
                            {
                                Text = "Settings",
                                //or if you want to perform an action, set the Action property
                                SubMenuId = 3
                            }
                        }
                    },
                    new Menu()
                    {
                        MenuId = 2,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Collect Items",
                                Action = () => Program.option1()
                            },
                            new MenuItem()
                            {
                                Text = "Auto Craft Gilded Coins",
                                Action = () => Program.option2()
                            },
                            new MenuItem()
                            {
                                Text = "Back to main menu",
                                SubMenuId = 1
                            }
                        }
                    },

                    new Menu()
                    {
                        MenuId = 3,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Set Webhook",
                                Action = () => Util.Webhook()
                            },
                            new MenuItem()
                            {
                                Text = "Set Keybind",
                                Action = () => Console.WriteLine("Goodbye")
                            },
                            new MenuItem()
                            {
                                Text = "Back to main menu",
                                SubMenuId = 1
                            }
                        }
                    }
                }
            };
        }
    }
}