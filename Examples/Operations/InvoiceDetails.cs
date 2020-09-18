using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InvoiceDetails : Base
  {
    public InvoiceDetails(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public InvoiceDetailsModel Get(string orgCode,int invoiceNumber, int orderNumber, int orderLine)
    {
      return APIUtil.GetInvoiceDetail(USISDKClient, orgCode, invoiceNumber, orderNumber, orderLine);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<InvoiceDetailsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<InvoiceDetailsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
