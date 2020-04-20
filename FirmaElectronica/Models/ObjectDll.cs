using FirmaElectronicaOnBase;
using System.Collections.Generic;

namespace FirmaElectronica.Models
{
    public class ObjectDll
    {
        public string senderEmail { get; set; }
        public string authToken { get; set; }
        public string docSetName { get; set; }
        public string daysRemainder { get; set; }
        public string daysExpiration { get; set; }
        public string pdfFileName { get; set; }
        public string pdfB64 { get; set; }
        public List<Destinatario> destinatarios { get; set; }
    }
}
