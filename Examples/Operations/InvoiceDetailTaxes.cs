using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class InvoiceDetailTaxes : Base
  {
    public InvoiceDetailTaxes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public InvoiceDetailTaxesModel Get(string orgCode, int invoiceNumber, int orderNumber, int orderLineNumber, int sequenceNbr)
    {
      return APIUtil.GetInvoiceDetailTax(USISDKClient, orgCode, invoiceNumber, orderNumber, orderLineNumber, sequenceNbr);
    }


    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<InvoiceDetailTaxesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<InvoiceDetailTaxesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
