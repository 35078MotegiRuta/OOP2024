using ProductSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductApp {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);

            Product daihuku = new Product(300, "だいふく", 120);

            Product dorayaki = new Product(98, "どら焼き", 210);

            int karintoprice = karinto.Price;//税抜きの金額

            int karintotaxIncluded = karinto.GetPriceIncludingTax();//税込みの価格

            int daihukuprice = daihuku.Price;//税抜きの金額

            int daihukutaxIncluded = daihuku.GetPriceIncludingTax();//税込みの価格

            int dorayakiprice = dorayaki.Price;//税抜きの金額

            int dorayakitaxIncluded = dorayaki.GetPriceIncludingTax();//税込みの価格

            int dorayakiTax = dorayaki.GetTax();

            Console.WriteLine(karinto.Name + "の税込み金額" + karintotaxIncluded + "円【税抜き" + karintoprice + "円】");

            Console.WriteLine(daihuku.Name + "の税込み金額" + daihukutaxIncluded + "円【税抜き" + daihukuprice + "円】");

            Console.WriteLine($"{dorayakiTax}円");


        }
    }
}
