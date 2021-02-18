using System;
using RestUtils;
using SamplesCollection.Api

namespace SamplesCollection.Api

public class BrokerClient
{
    public RenderDocumentResponse RenderDocument(string base64DocumentContent)  // this is the API we call it render document 
    {

        var client = EnvironmentProperties.GetBrokerRenderDocumentRestURL();  // here we would have the URL of the api endpoint and the route
        var renderDocumentRequest = BrokerRequest.GetRenderDocumentRequest(base64DocumentContent);  // the function here return the request 
        var renderDocumentRequestJSON = JsonConvert.SerializeObject(renderDocumentRequest); // serializing the request. 

        var renderDocumentResponse = RestUtils.CallService<RenderDocumentResponse>(client, Method.POST, renderDocumentRequestJSON); // uses the restSharp framework

     
        return renderDocumentResponse;
    }
}
