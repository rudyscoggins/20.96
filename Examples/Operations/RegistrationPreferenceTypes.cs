using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RegistrationPreferenceTypes : Base
  {
    public RegistrationPreferenceTypes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RegistrationPreferenceTypesModel Get(int registrationPreferenceID)
    {
      return APIUtil.GetRegistrationPreferenceType(USISDKClient, registrationPreferenceID);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<RegistrationPreferenceTypesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RegistrationPreferenceTypesModel>(USISDKClient, ref searchMetadata, string.Empty, "All");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<RegistrationPreferenceTypesModel> RetrieveByOData(string oData)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RegistrationPreferenceTypesModel>(USISDKClient, ref searchMetadata, string.Empty, oData);
    }


    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="preferenceType">Preference Type</param>
    /// <param name="active">True if active</param>
    /// <param name="mandatory">"Y" or "N".</param>
    /// <param name="configurationCode">Application configuration code</param>
    /// <param name="defaultLanguage">"Y" or "N". Default language to be used when usersland on the site for the first time, using the base link that has no language information predefined.</param>
    /// <returns></returns>
    public RegistrationPreferenceTypesModel Add(string orgCode,
                                                int preferenceType,
                                                string active,
                                                string mandatory,
                                                string configurationCode)
    {
      RegistrationPreferenceTypesModel registrationPreferenceType = new RegistrationPreferenceTypesModel()
      {
        OrgCode = orgCode,
        PreferenceType = preferenceType,
        Active = active,
        Mandatory = mandatory,
        ConfigurationCode = configurationCode
      };

      return APIUtil.AddRegistrationPreferenceType(USISDKClient, registrationPreferenceType);
    }

    public RegistrationPreferenceTypesModel Edit(int registrationPreferenceID, string active, string mandatory)
    {
      RegistrationPreferenceTypesModel registrationPreferenceType = APIUtil.GetRegistrationPreferenceType(USISDKClient, registrationPreferenceID);

      registrationPreferenceType.Active = active;
      registrationPreferenceType.Mandatory = mandatory;

      return APIUtil.UpdateRegistrationPreferenceType(USISDKClient, registrationPreferenceType);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int registrationPreferenceID)
    {
      APIUtil.AwaitDeleteRegistrationPreferenceType(USISDKClient, registrationPreferenceID).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }
  }
}
