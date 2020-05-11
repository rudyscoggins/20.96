using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class CurrencyRates : Base
  {
    public CurrencyRates(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public CurrencyRatesModel Get(string Code, int SequenceNumber)
    {
      return APIUtil.GetCurrencyRate(USISDKClient, Code, SequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<CurrencyRatesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CurrencyRatesModel>(USISDKClient, ref searchMetadata, null, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public CurrencyRatesModel Add()
    {
      var currencyRates = new CurrencyRatesModel
      {
        CurrencyCode = "EUR",
        EffectiveDate = DateTime.UtcNow,
        LocalCurrencyRate = 1,
        ForeignCurrencyRate = 1,
        TriangulationCurrencyRate = 1,
        ExchangeRateCurrencyCode = "USD",
        ExchangeRateOrganizationCode = "10"
      };

      return APIUtil.AddCurrencyRate(USISDKClient, currencyRates);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="code">Currency code of object to Update</param>
    /// <param name="sequenceNumber">Sequence Number of object to update</param>
    /// <returns></returns>
    public CurrencyRatesModel Edit(string code, int sequenceNumber, CurrencyRatesModel currencyRatesModelNew)
    {
      var currencyRates = APIUtil.GetCurrencyRate(USISDKClient, code, sequenceNumber);

      if (currencyRates != null)
      {
        currencyRates.EffectiveDate = currencyRatesModelNew.EffectiveDate;
        currencyRates.LocalCurrencyRate = currencyRatesModelNew.LocalCurrencyRate;
        currencyRates.ForeignCurrencyRate = currencyRatesModelNew.ForeignCurrencyRate;
        currencyRates.TriangulationCurrencyRate = currencyRatesModelNew.TriangulationCurrencyRate;
        currencyRates.ExchangeRateCurrencyCode = currencyRatesModelNew.ExchangeRateCurrencyCode;
        currencyRates.ExchangeRateOrganizationCode = currencyRatesModelNew.ExchangeRateOrganizationCode;
      }

      return APIUtil.UpdateCurrencyRate(USISDKClient, code, sequenceNumber, currencyRatesModelNew);
    }
  }
}
