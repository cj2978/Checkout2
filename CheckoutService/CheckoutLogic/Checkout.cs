using System;
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

            foreach (char key in _items.Keys)
            {
                total = total + GetItemTotal(key.ToString(), _items[key]);
            }

            return total;
        }

        private static void GetPriceList()
        {
            using (var reader = new StreamReader(@"C:\Users\Christopher\Documents\GitHub\Checkout2\CheckoutService\bin\prices.json"))
            {
                _pricelist = JsonConvert.DeserializeObject<List<Price>>(reader.ReadToEnd());
            }
        }

        private static int GetItemTotal(string sKU, int qty)
        {
            var itemTotal = 0;

            Price itemDetails = _pricelist.Find(x => x.SKU == sKU);

            if (itemDetails != null)
            {
                int specialPriceMultiplier = itemDetails.SpecialPriceQty > 0 ? qty / itemDetails.SpecialPriceQty : 0;
                int standardPriceMultiplier = qty - (specialPriceMultiplier * itemDetails.SpecialPriceQty);

                itemTotal = (specialPriceMultiplier * itemDetails.SpecialPriceAmount) + (standardPriceMultiplier * itemDetails.UnitPrice);
            }
            else
            {
                string message = string.Format("The SKU {0} is not a valid value", sKU);
                throw new Exception(message);
            }

            return itemTotal;
        }
    }
}
