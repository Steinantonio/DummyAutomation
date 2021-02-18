using System;
using SamplesCollection.Helpers

public class sensitiveDao
{

    public Document GetDocumentByID(string documentID)
    {

        OracleParameter parameterDocumentID = new OracleParameter("DOCUMENTID", OracleDbType.Varchar2)
        {
            Value = documentID
        };


        DataTable dataTable = Connection.ExecuteQuery(Databases.SENSITIVE - DB, dbQueries.GET_DOCUMENT_BY_ID, new List<OracleParameter> { parameterDocumentID });


        if (dataTable.Rows.Count > 0)
        {

            Document document = new Document()
            {
                data1 = dataTable.Rows[0].ItemArray[0].ToString(),
                data2 = dataTable.Rows[0].ItemArray[1].ToString(),
                data3 = dataTable.Rows[0].ItemArray[2].ToString(),
                data4 = dataTable.Rows[0].ItemArray[3].ToString(),
                data5 = dataTable.Rows[0].ItemArray[3].ToString()
            };
            return document;
        }
        else
        {
            throw new DocumentVaultDataException("Document not found!");
        }

    }
}
