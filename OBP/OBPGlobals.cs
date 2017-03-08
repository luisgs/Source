using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBP
{
    public static class OBPGlobals
    {
        public static string[] coveredLanguages = new string[10] { "English", "Czech", "German", "Spanish", "French", "Italian", "Dutch", "Polish", "Russian", "Compete" };
        public static string templateDirectory;
        public static string templatePathFromLanguage(string language)
        {
            switch (language)
            {
                case "English": return templateDirectory + "OBP_SFDC_EN.oft";
                case "Czech": return templateDirectory + "OBP_SFDC_CS.oft";
                case "German": return templateDirectory + "OBP_SFDC_DE.oft";
                case "Spanish": return templateDirectory + "OBP_SFDC_ES.oft";
                case "French": return templateDirectory + "OBP_SFDC_FR.oft";
                case "Italian": return templateDirectory + "OBP_SFDC_IT.oft";
                case "Dutch": return templateDirectory + "OBP_SFDC_EN.oft";
                case "Polish": return templateDirectory + "OBP_SFDC_PL.oft";
                case "Russian": return templateDirectory + "OBP_SFDC_RU.oft";
                case "Compete": return templateDirectory + "OBP_SFDC_Compete.oft";
                default: return templateDirectory + "OBP_SFDC_EN.oft";
            }
        }
        public static string mailBoxFromLanguage(string language)
        {
            switch (language)
            {
                case "English": return @"\\OBP Technical Presales Support - English\Inbox\Mailbox - OBP Tech EN";
                case "Czech": return @"\\OBP Technical Presales Support - Czech\Inbox\Mailbox - OBP Tech CS";
                case "German": return @"\\OBP Technical Presales Support - German\Inbox\Mailbox - OBP Tech DE";
                case "Spanish": return @"\\OBP Technical Presales Support - Spanish\Inbox\Mailbox - OBP Tech ES";
                case "French": return @"\\OBP Technical Presales Support - French\Inbox\Mailbox - OBP Tech FR";
                case "Italian": return @"\\OBP Technical Presales Support - Italian\Inbox\Mailbox - OBP Tech IT";
                case "Dutch": return @"\\OBP Technical Presales Support - Dutch\Inbox\Mailbox - OBP Tech NL";
                case "Polish": return @"\\OBP Technical Presales Support - Polish\Inbox\Mailbox - OBP PL";
                case "Russian": return @"\\OBP Technical Presales Support - Russian\Inbox\Mailbox - OBP Tech RU";
                case "Compete": return @"\\OBP.Compete@hp.com\Inbox\OBP Competitive Mailbox";
                default: return @"\\OBP Technical Presales Support\Inbox\Mailbox - OBP Tech";
            }
        }
        public static string fromAddressFromLanguage(string language)
        {
            switch (language)
            {
                case "English": return "techub.emea.en@hpe.com";
                case "Czech": return "techub.emea.cz@hpe.com";
                case "German": return "techub.emea.de@hpe.com";
                case "Spanish": return "techub.emea.es@hpe.com";
                case "French": return "techub.emea.fr@hpe.com";
                case "Italian": return "techub.emea.it@hpe.com";
                case "Dutch": return "techub.emea.en@hpe.com";
                case "Polish": return "techub.emea.pl@hpe.com";
                case "Russian": return "techub.emea.ru@hpe.com";
                case "Compete": return "techub.emea.en@hpe.com";
                default: return "techub.emea.en@hpe.com";
            }
        }
        public static List<string> selectedLanguages;
        public static string salesForceTrackingAddress;
        public static string consultantName;
    }
}
