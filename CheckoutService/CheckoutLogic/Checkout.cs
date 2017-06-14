using System.Collections.Generic;

namespace CheckoutLogic
{
    public static class Checkout
    {
        private static Dictionary<char, int> _items = new Dictionary<char, int>();

        public static void ScanItem(string item)
        {
            foreach (var character in item)
            {
                if (_items.ContainsKey(character))
                {
                    var currentItems = _items[character];
                    currentItems++;
                    _items[character] = currentItems;
                }
                else
                {
                    _items.Add(character, 1);
                }
            }
        }
    }
}
