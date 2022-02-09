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
        }
    }

    class Сommodity
    {
        public string Name { get; protected set; }

        public int Price { get; protected set; }

        public int Weight { get; protected set; }

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
                                                                 new Сommodity("Огурец ", 1, 1),
                                                                 new Сommodity("Помидор",2,1),
                                                                 new Сommodity("Рыба",15,2)};

        public void AddaProduct(Сommodity сommodity)
        {
            _counter.Add(сommodity);
        }

        public bool TrySell(out Сommodity сommodity, string ltemName)
        {
            сommodity = null;

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

            return false;
        }

        public void showAllСommodity()
        {
            for (int i = 0; i < _counter.Count; i++)
            {
                ShowMessage(_counter[i].Name + "\n Цена: " + _counter[i].Price+ "\n Вес: " + _counter[i].Weight, ConsoleColor.Blue);
            }
        }
    
        private void ShowMessage(string message,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }

    class Player
    {
        private string _userName;

        private List<Сommodity> _shoppingСart = new List<Сommodity> { };

        public Player(string userName)
        {
            _userName = userName;
        }

        public void TryBuy(Seller seller, string productName)
        {
            Сommodity сommodity;

            if (seller.TrySell(out сommodity, productName))
            {
                _shoppingСart.Add(сommodity);
            }
        }

        public void ShowShoppingList()
        {
            if (_shoppingСart.Count > 0)
            {
                Console.WriteLine("Список купленных товаров");

                for (int i = 0; i < _shoppingСart.Count; i++)
                {
                    Console.WriteLine($"{_shoppingСart[i].Name} \n" +
                                      $"Цена: {_shoppingСart[i].Price}\n" +
                                      $"Вес: {_shoppingСart[i].Price}\n");
                }
            }
            else
            {
                Console.WriteLine("У вас нет покупок");
            }
        }
    }
}
