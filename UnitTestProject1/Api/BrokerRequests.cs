using System;
using SamplesCollection.DTOS;


namespace SamplesCollection.Api
public class BrokerRequests
{
    public static RenderDocumentRequest GetRenderDocumentRequest(string base64DocumentContent)
    {
        return new RenderDocumentRequest()
        {
            correlationID = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddmmHHssfff")), // id for the request
            systemOfOrigin = "DOCMGMTAUTOMATION", // origin system of the request
            Account = EnvironmentProperties.GetAutomationUser(), // this is the account performing the action, the method returns sensitive data
            inputXml = new InputXml()  // the document that will be used and his data
            {
                content = base64DocumentContent,
                mimetype = "text/xml",
                name = "automation_test_document.xml"
            }
        };
    }
}
