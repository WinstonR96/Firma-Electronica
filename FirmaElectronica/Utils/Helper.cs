using FirmaElectronica.Models;
using FirmaElectronicaOnBase;
using System;
using System.Collections.Generic;

namespace FirmaElectronica.Utils
{
    public static class Helper
    {
        public static ObjectDll CastData(RootNewDocumentSet data)
        {
            ObjectDll objectDll = new ObjectDll();
            
            //TODO: revisar el envio del items file (Pdf name, y pdf base 64)
            foreach (Item item in data.NewDocumentSet.DocumentSet.DocumentSetItems.Item)
            {
                objectDll.pdfFileName = item.ItemName;
                objectDll.pdfB64 = item.ItemPDFContentB64;
            }


            objectDll.senderEmail = data.NewDocumentSet.DocumentSet.DocumentSetSender;
            objectDll.authToken = data.AuthToken.Token;
            objectDll.docSetName = data.NewDocumentSet.DocumentSet.DocumentSetName;
            objectDll.daysRemainder = data.NewDocumentSet.DocumentSet.DocumentSetReminder;
            objectDll.daysExpiration = data.NewDocumentSet.DocumentSet.DocumentSetExpirationDate;
            List<Destinatario> destinatarios = new List<Destinatario>();
            List<Recipient> recipients = data.NewDocumentSet.DocumentSet.DocumentSetRecipients.Recipient;
            List<ItemRecipientAction> itemRecipients = data.NewDocumentSet.DocumentSet.DocumentSetActions.ItemRecipientAction;
            for (int i = 0; i < recipients.Count; i++)
            {
                destinatarios.Add(
                    new Destinatario()
                    {
                        Nombre = recipients[i].RecipientName,
                        Cedula = recipients[i].RecipientIdCard,
                        Telefono = "+57"+recipients[i].RecipientCellPhone,
                        Email = recipients[i].RecipientMail,
                        MetodoFirma = (MetodoFirma)Enum.Parse(typeof(MetodoFirma), itemRecipients[i].RequestedAction),
                        InfoRecuadroFirma = new RecuadroFirma()
                        {
                            Pagina = itemRecipients[i].WidgetPosition.Page,
                            MedidasRecuadro = new MedidasRecuadroFirma()
                            {
                                PosicionX = itemRecipients[i].WidgetPosition.PositionX,
                                PosicionY = itemRecipients[i].WidgetPosition.PositionY,
                                Ancho = itemRecipients[i].WidgetPosition.Width,
                                Alto = itemRecipients[i].WidgetPosition.Height,
                            }
                        }

                    }
                );
            }
            objectDll.destinatarios = destinatarios;
            return objectDll;
        }
    }
}
