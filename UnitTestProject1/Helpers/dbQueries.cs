
namespace SamplesCollection.DTOS
public class dbQueries
{

    public const string GET_DOCUMENT_BY_ID = "SELECT D.XDOCTYPE, D.XDOCSUBTYPE, D.XSENSEDATA, R.DOCSENSEDATA " +
                                               "FROM TABLEYZR R  " +
                                               "JOIN DOCSENSITIV1 D ON R.DID = D.DID  " +
                                               "WHERE DCREATEDATE = (select max(DCREATEDATE) from TABLEYZR R join DCREATEDATE D on R.DID = D.DID where R.DDOCNAME = :DOCUMENTID)";
}


