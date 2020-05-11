using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Exhibitors : Base
  {
    public Exhibitors(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExhibitorsModel Get(string orgCode, int exhibitorID) 
    {
      return APIUtil.GetExhibitor(USISDKClient, orgCode, exhibitorID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ExhibitorsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ExhibitorsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public IEnumerable<ExhibitorsModel> SearchForUserFields(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;

      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Exhibitors user fields of Issue Class = C (event sales), Issue Type code = 42, organization code = 10, and User Text 01 (TXT_01).  It will return exhibitors where the value is '8'      
      return APIUtil.GetSearchList<ExhibitorsModel>(USISDKClient, ref searchMetadata, orgCode, "C|42|10|UserText01 eq '8'");
    }

    /// <summary>
    /// How to retrieve all exhibitors per event. 
    /// </summary> 
    public IEnumerable<ExhibitorsModel> GetByEvent(string orgCode, int eventID)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ExhibitorsModel>(USISDKClient, ref searchMetadata, orgCode, $"Event eq {eventID}");
    }

    /// <summary>
    /// A basic add example for event and account
    /// </summary>  
    public ExhibitorsModel Add(string orgCode, int eventID, string accountCode)
    {
      var myExhibitor = new ExhibitorsModel
      {
        OrganizationCode = orgCode,
        Event = eventID,
        AccountCode = accountCode
      };

      return APIUtil.AddExhibitor(USISDKClient, myExhibitor);
    }

    /// <summary>
    /// A basic add example with a constructed Exhibitors Model object
    /// </summary>  
    public ExhibitorsModel Add(ExhibitorsModel myExhibitor)
    {
      return APIUtil.AddExhibitor(USISDKClient, myExhibitor);
    }

    /// <summary>
    /// A basic edit example for comments
    /// </summary> 
    public ExhibitorsModel Edit(string orgCode, int exhibitorID, string newComments)
    {
      var myExhibitor = APIUtil.GetExhibitor(USISDKClient, orgCode, exhibitorID);

      myExhibitor.Comments = newComments;

      return APIUtil.UpdateExhibitor(USISDKClient, myExhibitor);
    }

    /// <summary>
    /// A basic edit example with a constructed Exhibitors Model object
    /// </summary> 
    public ExhibitorsModel Edit(ExhibitorsModel myExhibitor)
    {
      return APIUtil.UpdateExhibitor(USISDKClient, myExhibitor);
    }

  }
}
