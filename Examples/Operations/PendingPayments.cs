using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PendingPayments : Base
  {
    public PendingPayments(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public PendingPaymentsModel Get(string orgCode, int pendingPaymentID)
    {
      return APIUtil.GetPendingPayment(USISDKClient, orgCode, pendingPaymentID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PendingPaymentsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PendingPaymentsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
