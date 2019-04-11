using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SystemetAPI.Models;

namespace DoingImport
{
    class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("U wanna update the database? Y/N");
            string userInput = Console.ReadLine();

            if (userInput == "Y")
            {
                await AddingToD();
            }
        }

        public static XmlNodeList Node;
        
        public async static Task AddingToD()
        {
            ReadingFIle();

            for (int i = 0; i < Node.Count; i++)
            {
                int nrIn = int.Parse(Node.Item(i).SelectSingleNode("nr").InnerText);
                int artId = int.Parse(Node.Item(i).SelectSingleNode("Artikelid").InnerText);
                int varnummret = int.Parse(Node.Item(i).SelectSingleNode("Varnummer").InnerText);
                string namnPrimary = Node.Item(i).SelectSingleNode("Namn").InnerText;
                string namn2Seccondary = Node.Item(i).SelectSingleNode("Namn2").InnerText;
                decimal prisinklMomsen = decimal.Parse(Node.Item(i).SelectSingleNode("Prisinklmoms").InnerText);
                int panten = 0;
                try
                {
                    panten = int.Parse(Node.Item(i).SelectSingleNode("Pant").InnerText);
                }
                catch (Exception)
                {
                }
                decimal volymiMilliliter = decimal.Parse(Node.Item(i).SelectSingleNode("Volymiml").InnerText);
                decimal prisPerLitern = decimal.Parse(Node.Item(i).SelectSingleNode("PrisPerLiter").InnerText);
                DateTime saljstarten = DateTime.ParseExact(Node.Item(i).SelectSingleNode("Saljstart").InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
               
                string varugruppen = "";
                try
                {
                    varugruppen = Node.Item(i).SelectSingleNode("Varugrupp").InnerText;
                }
                catch (Exception)
                {
                }
                string typen = Node.Item(i).SelectSingleNode("Typ").InnerText;
                string stilen = Node.Item(i).SelectSingleNode("Stil").InnerText;
                string forpackningen = Node.Item(i).SelectSingleNode("Forpackning").InnerText;
                string ursprunget = Node.Item(i).SelectSingleNode("Ursprung").InnerText;
                string landet = Node.Item(i).SelectSingleNode("Ursprunglandnamn").InnerText;
                string producenten = "";
                try
                {
                    producenten = Node.Item(i).SelectSingleNode("Producent").InnerText;
                }
                catch (Exception)
                {
                }
                string leverantoren = "";
                try
                {
                    leverantoren = Node.Item(i).SelectSingleNode("Leverantor").InnerText;
                }
                catch (Exception)
                {
                }

                string alkoholString = Node.Item(i).SelectSingleNode("Alkoholhalt").InnerText;
                decimal alkoholhalten = 0;
                if (alkoholString.Contains('%'))
                {
                    alkoholhalten = decimal.Parse(alkoholString.Substring(0, alkoholString.Length - 1));
                }
                string ravarorBeskrivningen = "";
                try
                {
                    ravarorBeskrivningen = Node.Item(i).SelectSingleNode("RavarorBeskrivning").InnerText;
                }
                catch (Exception)
                {
                }

                using (VRContext vRContext = new VRContext())
                {
                    try
                    {
                        var truncating = vRContext.SysSortTable.FromSql("TRUNCATE TABLE [SysSortTable]");
                    }
                    catch (Exception)
                    {

                    }

                    var addThis = new SysSortTable
                    {
                        Nr = nrIn,
                        ArtikelId = artId,
                        Varunummer = varnummret,
                        Namn = namnPrimary,
                        Namn2 = namn2Seccondary,
                        PrisInkMoms = prisinklMomsen,
                        Pant = panten,
                        VolymIml = volymiMilliliter,
                        PrisPerLiter = prisPerLitern,
                        Saljstart = saljstarten,
                        Varugrupp = varugruppen,
                        Typ = typen,
                        Stil = stilen,
                        Forpackning = forpackningen,
                        Ursprung = ursprunget,
                        Land = landet,
                        Producent = producenten,
                        Leverantör = leverantoren,
                        Alkoholhalt = alkoholhalten,
                        RavarorDesc = ravarorBeskrivningen
                    };

                    vRContext.Add(addThis);
                    await vRContext.SaveChangesAsync();
                }
               
            }

        }
        public static void ReadingFIle()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument document = new XmlDocument();
            document.Load("https://www.systembolaget.se/api/assortment/products/xml");

            XmlElement element = document.DocumentElement;
            Node = element.SelectNodes("artikel");
        }
    }
}
