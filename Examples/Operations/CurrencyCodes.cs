using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class CurrencyCodes : Base
  {
    public CurrencyCodes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public CurrencyCodesModel Get(string Code)
    {
      return APIUtil.GetCurrencyCode(USISDKClient, Code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<CurrencyCodesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CurrencyCodesModel>(USISDKClient, ref searchMetadata, null, "All");
    }
  }
}
