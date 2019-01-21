using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Xml;
using SystemetAPI.Models;

namespace ServicesSystemet
{
    public class ImportingToDB
    {
        public XmlNodeList Node;
        public void ReadingFIle()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument document = new XmlDocument();
            document.Load("https://www.systembolaget.se/api/assortment/products/xml");

            XmlElement element = document.DocumentElement;
            Node = element.SelectNodes("artikel");

            AddingToD();
        }

        public void AddingToD()
        {
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
                bool utgatt = false;
                string utgattstring = Node.Item(i).SelectSingleNode("Utgått").InnerText;
                if (utgattstring == "1")
                {
                    utgatt = true;
                }
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
                string forslutningen = Node.Item(i).SelectSingleNode("Forslutning").InnerText;
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
                string argangenString = Node.Item(i).SelectSingleNode("Argang").InnerText;
                int argangen = 0;
                if (argangenString != "")
                {
                    argangen = int.Parse(Node.Item(i).SelectSingleNode("Argang").InnerText);
                }
                int provardargangen = 0;
                if (Node.Item(i).SelectSingleNode("Provadargang").InnerText != "")
                {
                    provardargangen = int.Parse(Node.Item(i).SelectSingleNode("Provadargang").InnerText);
                }
                string alkoholString = Node.Item(i).SelectSingleNode("Alkoholhalt").InnerText;
                decimal alkoholhalten = 0;
                if (alkoholString.Contains('%'))
                {
                    alkoholhalten = decimal.Parse(alkoholString.Substring(0, alkoholString.Length - 1));
                }
                string sortimentet = Node.Item(i).SelectSingleNode("Sortiment").InnerText;
                string sortimentetTexten = Node.Item(i).SelectSingleNode("SortimentText").InnerText;
                bool ekolokiskt = false;
                string ekostring = Node.Item(i).SelectSingleNode("Ekologisk").InnerText;
                if (utgattstring == "1")
                {
                    utgatt = true;
                }
                bool etiskt = false;
                if (Node.Item(i).SelectSingleNode("Etiskt").InnerText == "1")
                {
                    utgatt = true;
                }
                bool koschert = false;
                if (Node.Item(i).SelectSingleNode("Koscher").InnerText == "1")
                {
                    utgatt = true;
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
                    catch(Exception)
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
                        Utgatt = utgatt,
                        Varugrupp = varugruppen,
                        Typ = typen,
                        Stil = stilen,
                        Forpackning = forpackningen,
                        Forslutning = forslutningen,
                        Ursprung = ursprunget,
                        Land = landet,
                        Producent = producenten,
                        Leverantör = leverantoren,
                        Argang = argangen,
                        Provadarargang = provardargangen,
                        Alkoholhalt = alkoholhalten,
                        Sortiment = sortimentet,
                        SortimentText = sortimentetTexten,
                        Ekolokisk = ekolokiskt,
                        Etiskt = etiskt,
                        Koscher = koschert,
                        RavarorDesc = ravarorBeskrivningen
                    };

                    vRContext.Add(addThis);
                    vRContext.SaveChanges();
                }

            }
        }
    }
}
