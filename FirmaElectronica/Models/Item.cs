namespace FirmaElectronica.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ItemOrder { get; set; }
        public bool ItemMandatory { get; set; }
        public string ItemName { get; set; }
        public string ItemPDFContentB64 { get; set; }
    }
}
