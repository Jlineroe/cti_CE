using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavegaTIC_CTI.Models
{
    public class ConstProject
    {
        //public static string RutaDestinoAdjuntos = @"\\ginebra2\c$\Sitios\ATLAS\Uploads\WorkOrder\";
        public static string RutaDestinoAdjuntos = @"\\ginebra2\c$\Sitios\AIBTicketsTest\Uploads\WorkOrder\";
        //public static string RutaDestinoAdjuntos = Directory.GetCurrentDirectory() + "\\Uploads\\WorkOrder\\";
        public const string ConexStringTickets = @"Data Source=SQLAIB;MultipleActiveResultSets=True;Initial Catalog=TicketsUnificado;Persist Security Info=True;User ID=apps_user;Password=B0got0Qq.AIB;Connect Timeout=300";
        //Informacion del proyecto actual
        public string WinUser { get; set; } = Environment.UserName;
        public string NombreEquipo = Environment.MachineName;
        public const string NameProject = "Soporte web Gestion Centro de Experiencia Interna";
        public const string NameEnvio = "Gestion Soporte Web Chat Centro de experiencia Interna";
        public const string LlaveLogApp = "3980FC44-B3E1-4050-BEC6-8228050C1EE1";
        //Constantes Envio de mensajes
        public const string SmtpPort = "587";
        public const string SmtpHost = "smtp.office365.com";
        public const string SmtpMail = "atlanterexperience@atlanticqi.com";
        public const string SmtpPwd = "Atlantic2020*";
        //Constantes Conex Office 365
        //public static ExchangeService OutlookService = new ExchangeService
        //{
        //    Credentials = new WebCredentials("pagos@aib.com.co", "Claro2019**"),
        //    Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx")
        //};
        public const string SessionListAttach = "ListAttachment";

        public const string CarpetaOrigen = "Testing";
        public const string CarpetaDestino = "Testing Robot";
        public static string[] TextoInnecesario = {
            @"Aviso: Este mensaje de correo electrónico es confidencial y solo puede ser usado por el destinatario. En caso de recibirlo por error, por favor bórrelo de inmediato, avísele al remitente, absténgase de distribuirlo y/o difundirlo. Gracias. The content of this
 message is confidential and to be used only by the intended recipient. In case this mail is not for the intended recipient or you receive it as an error, please delete it and inform the sender. Please do not forward or transmit this message. Thanks.",
            @"Aviso: Este mensaje de correo electrónico es confidencial y solo puede ser usado por el destinatario. En caso de recibirlo por error, por favor bórrelo de inmediato, avísele al remitente, absténgase de distribuirlo y/o difundirlo. Gracias. The content of this message is confidential and to be used only by the intended recipient. In case this mail is not for the intended recipient or you receive it as an error, please delete it and inform the sender. Please do not forward or transmit this message. Thanks."
        };
    }
 }