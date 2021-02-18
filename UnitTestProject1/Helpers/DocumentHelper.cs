using System;

namespace SamplesCollection.DocumentHelpers
public class DocumentHelper
{
    public string UpdateSampleInvoice(string templateName, string docType, string docSubtype, string? documentXMLName) // last parameter is optional, because other instances used to call this using this last parameter
    {
        string innerData = string.Empty;

        if (documentXMLName == null)
        {
            innerData = File.ReadAllText(SharedEnvironmentProperties.Test_File_Canada);
        }
        else if (documentXMLName.Equals("SampleDocType") || documentXMLName.Equals("SampleDocType2") ) 
        {

            innerData = File.ReadAllText(SharedEnvironmentProperties.Test_File_Canada_LeaseInvoiceTags); // The"sharedEnv" here belongs to a sensitive data file containing all our env files and shared docs
        }

        innerData = File.ReadAllText(SharedEnvironmentProperties.Test_File_Canada);
        string jobId = DateTime.Now.ToString("yyyyMMddmmHHssfff") + "AUTOMATIONTESTJOBID";  // this is to give a number for the operation to be identified for 


        // the replaces here are for changing the default template gotten before to the specific values sent before in the examples
        innerData = Regex.Replace(innerData, "<jobId>.*?</jobId>", "<jobId>" + jobId + "</jobId>");
        innerData = Regex.Replace(innerData, "<jobDate>.*?</jobDate>", "<jobDate>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "</jobDate>");
        innerData = Regex.Replace(innerData, "<templateName>.*?</templateName>", "<templateName>" + templateName + "</templateName>");
        innerData = Regex.Replace(innerData, "<documentId>.*?</documentId>", "<documentId>" + docSubtype + "</documentId>");
        innerData = Regex.Replace(innerData, "<docIndicator>.*?</docIndicator>", "<docIndicator>" + docType + "</docIndicator>");

        return innerData;
    }
}
