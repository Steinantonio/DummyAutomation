using System;

namespace SamplesCollection.Steps
public class WhenSteps : ObjectInstance
{
    private readonly ScenarioContext context;
    public WhenSteps(ScenarioContext injectedContext) { context = injectedContext; }

    [When(@"the document is sent to WebService through the create document service")]
    public void WhenTheDocumentIsSentToWebServiceTheRenderDocumentService()
    {
        brokerClient = new BrokerClient(); 
        var documentXml = context.Get<string>("DocumentXML"); // get the document from the context dictionary 
        context["RenderDocumentResponse"] = brokerClient.RenderDocument(FileUtils.Base64Encode(documentXml)); // set in the dictionary the json response of the service

    }
}