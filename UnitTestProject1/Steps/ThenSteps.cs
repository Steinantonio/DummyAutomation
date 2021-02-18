using System;
using SamplesCollection.DTOS

public class ThenSteps : ObjectInstance
{
    private readonly ScenarioContext context;
    public ThenSteps(ScenarioContext injectedContext) { context = injectedContext; }

    [Then(@"the render document service must run successfully")]
    public void ThenTheRenderDocumentServiceMustRunSuccessfully()
    {
        RenderDocumentResponse renderDocumentResponse = context.Get<RenderDocumentResponse>("RenderDocumentResponse"); // map the context to the dto    
        Assert.IsTrue(renderDocumentResponse.responseMessage.Equals("Success"), "Render document failed"); // make the assertion based on the response message or any other atribute 
    }


    [Then(@"the response must contain the documentID")]
    public void ThenTheResponseMustContainTheDocumentUUID()
    {
        RenderDocumentResponse renderDocumentResponse = context.Get<RenderDocumentResponse>("RenderDocumentResponse"); // get the response from dictionary
        Assert.IsFalse(String.IsNullOrEmpty(renderDocumentResponse.documentUUID), "Render document did not respond with the documentID."); // make the assertion checking if there is not an ID
        Assert.IsTrue(renderDocumentResponse.documentID != null || renderDocumentResponse.documentID.length() > 0); // make the assertion checking if its not null and its not blank or doesnt have any value 

        context["documentUUID"] = renderDocumentResponse.documentUUID;
    }

    [Then(@"in the database the following columns are correctly set '(.*)','(.*)'")]
    public void ThenInTheOwccDatabaseTheFollowingColumnsAreCorrectlySet(string docType, string docSubType)
    {
        SensitiveDao sensitiveDao = new SensitiveDao(); // this is DAO made i couldnt reproduce since it contains sensitive data

        string documentID = context.Get<RenderDocumentResponse>("RenderDocumentResponse").documentUUID; // get the ID from the dictionary

        Document getDocumentDatabaseInformation = sensitiveDao.GetDocumentByID(documentID); // makes a query in the database, i cant reproduce the exact dao, but i will reproduce my best in a "dummy file"

        Assert.AreEqual(docType, getDocumentDatabaseInformation.docType, "the expected value of docType column is [" + docType + "] but found [" + getDocumentDatabaseInformation.docType + "]");
        Assert.AreEqual(docSubType, getDocumentDatabaseInformation.docSubtype, "the expected value of docType column is [" + docSubType + "] but found [" + getDocumentDatabaseInformation.docSubtype + "]");
    }

}
