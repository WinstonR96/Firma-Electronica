namespace FirmaElectronica.Models
{
    public class DocumentSet
    {
        public string DocumentSetSender { get; set; }
        public string DocumentSetName { get; set; }
        public string DocumentSetReminder { get; set; }
        public string DocumentSetExpirationDate { get; set; }
        public string DocumentSetLanguage { get; set; }
        public string DocumentSetCompany { get; set; }
        public DocumentSetItems DocumentSetItems { get; set; }
        public DocumentSetRecipients DocumentSetRecipients { get; set; }
        public DocumentSetActions DocumentSetActions { get; set; }
    }
}
