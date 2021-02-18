using System;


namespace SamplesCollection.Steps

public class GivenSteps : ObjectInstance
{
    private readonly ScenarioContext context;
    public GivenSteps(ScenarioContext injectedContext) { context = injectedContext; } 


    [Given(@"I got the template value (.*)")]
    public void GivenTheTemplateValue(string template)
    {
        context["template"] = template;
    }

    [Given(@"I got the DocType (.*)")]
    public void GivenDocTypeValue(string docType)
    {
        context["docType"] = docType;
    }

    [Given(@"the DocSubtype (.*)")]
    public void GivenDocSubtypeValue(string docSubtype)
    {
        context["docSubtype"] = docSubtype;
    }

    [When(@"I update the Canada Invoice document with those metadata values")]
    public void WhenIUpdateTheCanadaInvoiceDocumentWithThoseMetadataValues()
    {
        documentHelper = new DocumentHelper(evidenceHelper);
        context["DocumentXML"] = documentHelper.UpdateSampleInvoice(context.Get<string>("template"),
                                                                                            context.Get<string>("docType"),
                                                                                            context.Get<string>("docSubtype"));
    }


}
