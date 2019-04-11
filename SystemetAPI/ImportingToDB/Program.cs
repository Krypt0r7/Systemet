using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SystemetAPI.Models;

namespace ImportingToDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ReadingFIle();
            await AddingToD();
        }

        public static XmlNodeList node;

        public async static Task AddingToD()
        {
            for (int i = 0; i < node.Count; i++)
            {
                if (node.Item(i).SelectSingleNode("Varugrupp").InnerText == "Öl")
                {
                    int nrIn = int.Parse(node.Item(i).SelectSingleNode("nr").InnerText);
                    int artId = int.Parse(node.Item(i).SelectSingleNode("Artikelid").InnerText);
                    int varnummret = int.Parse(node.Item(i).SelectSingleNode("Varnummer").InnerText);
                    string namnPrimary = node.Item(i).SelectSingleNode("Namn").InnerText;
                    string namn2Seccondary = node.Item(i).SelectSingleNode("Namn2").InnerText;
                    decimal prisinklMomsen = decimal.Parse(node.Item(i).SelectSingleNode("Prisinklmoms").InnerText);
                    int panten = 0;
                    try
                    {
                        panten = int.Parse(node.Item(i).SelectSingleNode("Pant").InnerText);
                    }
                    catch (Exception)
                    {
                    }
                    decimal volymiMilliliter = decimal.Parse(node.Item(i).SelectSingleNode("Volymiml").InnerText);
                    decimal prisPerLitern = decimal.Parse(node.Item(i).SelectSingleNode("PrisPerLiter").InnerText);
                    DateTime saljstarten = DateTime.ParseExact(node.Item(i).SelectSingleNode("Saljstart").InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    string varugruppen = "";
                    try
                    {
                        varugruppen = node.Item(i).SelectSingleNode("Varugrupp").InnerText;
                    }
                    catch (Exception)
                    {
                    }
                    string typen = node.Item(i).SelectSingleNode("Typ").InnerText;
                    string stilen = node.Item(i).SelectSingleNode("Stil").InnerText;
                    string forpackningen = node.Item(i).SelectSingleNode("Forpackning").InnerText;
                    string ursprunget = node.Item(i).SelectSingleNode("Ursprung").InnerText;
                    string landet = node.Item(i).SelectSingleNode("Ursprunglandnamn").InnerText;
                    string producenten = "";
                    try
                    {
                        producenten = node.Item(i).SelectSingleNode("Producent").InnerText;
                    }
                    catch (Exception)
                    {
                    }
                    string leverantoren = "";
                    try
                    {
                        leverantoren = node.Item(i).SelectSingleNode("Leverantor").InnerText;
                    }
                    catch (Exception)
                    {
                    }

                    string alkoholString = node.Item(i).SelectSingleNode("Alkoholhalt").InnerText;
                    decimal alkoholhalten = 0;
                    if (alkoholString.Contains('%'))
                    {
                        alkoholhalten = decimal.Parse(alkoholString.Substring(0, alkoholString.Length - 1));
                    }
                    string ravarorBeskrivningen = "";
                    try
                    {
                        ravarorBeskrivningen = node.Item(i).SelectSingleNode("RavarorBeskrivning").InnerText;
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

        }
        public static void ReadingFIle()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument document = new XmlDocument();
            document.Load("https://www.systembolaget.se/api/assortment/products/xml");

            XmlElement element = document.DocumentElement;
            node = element.SelectNodes("artikel");
        }
    }
}

