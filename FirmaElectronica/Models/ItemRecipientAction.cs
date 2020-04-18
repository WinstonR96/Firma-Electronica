namespace FirmaElectronica.Models
{
    public class ItemRecipientAction
    {

        public string ItemId { get; set; }
        public string RecipientId { get; set; }
        public string RequestedAction { get; set; }
        public WidgetPosition WidgetPosition { get; set; }
    }
}
