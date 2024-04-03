using System;
using MacroForSols;
using DeclarativeConsoleMenu;
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
                                Action = () => Util.AutoCollect()

                            },
                            new MenuItem()
                            {
                                Text = "Auto Craft Gilded Coins",
                                Action = () => Util.AutoCraft()
                            },
                            new MenuItem()
                            {
                                Text = "Rotate Collect & Craft Coins",
                                Action = () => Util.Rotate()
                            },
                            new MenuItem()
                            {
                                Text = "More Crafting Features",
                                SubMenuId = 4
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
                                Action = () => Util.SetWebhook()
                            },
                            new MenuItem()
                            {
                                Text = "Set Keybind",
                                Action = () => Console.WriteLine("...")
                            },
                            new MenuItem()
                            {
                                Text = "Set Private Server Address",
                                Action = () => Util.SetPrivateServer()
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
                        MenuId = 4,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Auto Craft Heavenly I & II",
                                Action = () => Util.AutoCraftHeavenly()
                            },
                            new MenuItem()
                            {
                                Text = "Go to stella",
                                Action = () => Util.MoveToStella()
                            },
                            new MenuItem()
                            {
                                Text = "Back to main menu",
                                SubMenuId = 2
                            }
                        }
                    }
                }
            };
        }
    }
}