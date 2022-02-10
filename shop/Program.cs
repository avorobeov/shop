using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Player player = new Player();

            string userInput;
            bool isExit = false;

            while (isExit == false)
            {
                ShowMenu();

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        seller.ShowAllСommodity();
                        break;

                    case "2":
                        player.TryBuy(seller);
                        break;

                    case "3":
                        player.ShowShoppingList();
                        break;

                    case "4":
                        isExit = true;
                        break;
                }

            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\nДля получения список продуктов на прилавке нажмите 1\n" +
                              "\nДля покупки товара нажмите 2\n" +
                              "\nпросмотреть список ваших покупок нажмите 3\n" +
                              "\nДля выхода нажмите 4\n");
        }
    }

    class Сommodity
    {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public int Weight { get; private set; }

        public Сommodity(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
    }

    class Seller
    {
        private List<Сommodity> _counter = new List<Сommodity> { new Сommodity("Колбаса", 10, 1),
                                                                 new Сommodity("Огурец", 1, 1),
                                                                 new Сommodity("Помидор",2,1),
                                                                 new Сommodity("Рыба",15,2)};

        public bool TrySell(out Сommodity сommodity, string ltemName)
        {
            сommodity = null;

            if (_counter.Count > 0)
            {
                for (int i = 0; i < _counter.Count; i++)
                {
                    if (_counter[i].Name == ltemName)
                    {
                        сommodity = _counter[i];

                        _counter.RemoveAt(i);

                        ShowMessage("Товар успешно продан", ConsoleColor.Green);

                        return true;
                    }
                }

                ShowMessage("Ошибка!!!", ConsoleColor.Red);
            }
            else
            {
                ShowMessage("Прилавок пуст", ConsoleColor.DarkGreen);
            }

            return false;
        }

        public void ShowAllСommodity()
        {
            if (_counter.Count != 0)
            {
                for (int i = 0; i < _counter.Count; i++)
                {
                    ShowMessage(_counter[i].Name + "\n Цена: " + _counter[i].Price + "\n Вес: " + _counter[i].Weight, ConsoleColor.Blue);
                }
            }
            else
            {
                ShowMessage("Прилавок пуст", ConsoleColor.DarkGreen);
            }
        }

        private void ShowMessage(string message, ConsoleColor color)
        {
            ConsoleColor preliminaryColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            Console.ForegroundColor = preliminaryColor;
        }
    }

    class Player
    {
        private List<Сommodity> _shoppingСart = new List<Сommodity> { };

        public void TryBuy(Seller seller)
        {
            Сommodity сommodity;

            string userInput;

            ShowMessage("Ведите наименование товара которы хотите приобрести", ConsoleColor.DarkYellow);

            userInput = Console.ReadLine();

            if (seller.TrySell(out сommodity, userInput))
            {
                _shoppingСart.Add(сommodity);
            }
        }

        public void ShowShoppingList()
        {
            if (_shoppingСart.Count > 0)
            {
                ShowMessage("Список купленных товаров\n\n\n", ConsoleColor.Magenta);

                for (int i = 0; i < _shoppingСart.Count; i++)
                {
                    ShowMessage($"{_shoppingСart[i].Name} \n" +
                                      $"Цена: {_shoppingСart[i].Price}\n" +
                                      $"Вес: {_shoppingСart[i].Price}\n", ConsoleColor.Cyan);
                }
            }
            else
            {
                ShowMessage("У вас нет покупок", ConsoleColor.DarkMagenta);
            }
        }
        private void ShowMessage(string message, ConsoleColor color)
        {
            ConsoleColor preliminaryColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            Console.ForegroundColor = preliminaryColor;
        }
    }
}
