using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CheckoutLogic
{
    public static class Checkout
    {
        private static Dictionary<char, int> _items = new Dictionary<char, int>();
        private static List<Price> _pricelist = new List<Price>();


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

        public static int GetTotal()
        {
            GetPriceList();

            var total = 0;

            return total;
        }

        private static void GetPriceList()
        {
            using (var reader = new StreamReader(@"C:\Users\Christopher\Documents\GitHub\Checkout2\CheckoutService\bin\prices.json"))
            {
                _pricelist = JsonConvert.DeserializeObject<List<Price>>(reader.ReadToEnd());
            }
        }
    }
}
