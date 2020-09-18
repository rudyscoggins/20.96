using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class ARDemographics : Base
  {
    public ARDemographics(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ARDemographicsModel Get(string orgCode, string account)
    {
      return APIUtil.GetARDemographic(USISDKClient, orgCode, account);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ARDemographicsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ARDemographicsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// Add new ARDemographic
    /// </summary>
    /// <param name="aRDemographicsModel"></param>
    /// <returns></returns>
    public ARDemographicsModel Add(string orgCode, string account)
    {
      var aRDemographicModel = new ARDemographicsModel()
      {
        Organization = orgCode,
        Account = account,
        Terms = "30",
        CreditLimit = 100,
        HoldOrders = "W",
        EnteredBy = "JEFFK",
        EnteredOn = DateTime.UtcNow,
        ChangedBy = "JEFFK",
        ChangedOn = DateTime.UtcNow
      };

      return APIUtil.AddARDemographic(USISDKClient, aRDemographicModel);
    }

    /// <summary>
    /// A basic edit ARDemographic example
    /// </summary> 
    public ARDemographicsModel EditWithPartialMode(string orgeCode, string account, decimal newCreditLimit)
    {
      ARDemographicsModel aRDemographicsModel = APIUtil.GetARDemographic(USISDKClient, orgeCode, account);
      if (aRDemographicsModel != null)
      {
        aRDemographicsModel.CreditLimit = newCreditLimit;
      }

      return APIUtil.UpdateARDemographic(USISDKClient, aRDemographicsModel);
    }

    /// <summary>
    /// A basic delete ARDemographic example
    /// </summary>    
    public void Delete(string orgCode, string account)
    {
      APIUtil.AwaitDeleteARDemographic(USISDKClient, orgCode, account).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }
  }
}
