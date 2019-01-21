using System;
using System.Collections.Generic;

namespace SystemetAPI.Models
{
    public partial class SysSortTable
    {
        public int Nr { get; set; }
        public int ArtikelId { get; set; }
        public int Varunummer { get; set; }
        public string Namn { get; set; }
        public string Namn2 { get; set; }
        public decimal PrisInkMoms { get; set; }
        public int Pant { get; set; }
        public decimal VolymIml { get; set; }
        public decimal PrisPerLiter { get; set; }
        public DateTime? Saljstart { get; set; }
        public bool Utgatt { get; set; }
        public string Varugrupp { get; set; }
        public string Typ { get; set; }
        public string Stil { get; set; }
        public string Forpackning { get; set; }
        public string Forslutning { get; set; }
        public string Ursprung { get; set; }
        public string Land { get; set; }
        public string Producent { get; set; }
        public string Leverantör { get; set; }
        public int? Argang { get; set; }
        public int? Provadarargang { get; set; }
        public decimal Alkoholhalt { get; set; }
        public string Sortiment { get; set; }
        public string SortimentText { get; set; }
        public bool Ekolokisk { get; set; }
        public bool Etiskt { get; set; }
        public bool Koscher { get; set; }
        public string RavarorDesc { get; set; }
    }
}
