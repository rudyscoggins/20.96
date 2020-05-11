using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
 public class PurchaseOrderApproval : Base
  {
    public PurchaseOrderApproval(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderApprovalModel Get(string orgCode, int number, int itemSequence, int sequence)
    {
      return APIUtil.GetPurchaseOrderApproval(USISDKClient, orgCode, number, itemSequence, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PurchaseOrderApprovalModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PurchaseOrderApprovalModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
