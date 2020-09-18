using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PublicLanguages : Base
  {
    public PublicLanguages(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public PublicLanguagesModel Get(int sequence)
    {
      return APIUtil.GetPublicLanguage(USISDKClient, sequence);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<PublicLanguagesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PublicLanguagesModel>(USISDKClient, ref searchMetadata, string.Empty, "All");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<PublicLanguagesModel> RetrieveByOData(string oData)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PublicLanguagesModel>(USISDKClient, ref searchMetadata, string.Empty, oData);
    }


    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="languageCode">Language code</param>
    /// <param name="dictionarySequence">Dictionary to be used for system phrases</param>
    /// <param name="descriptionToUse">Description</param>
    /// <param name="region">Enter the region the site will use for times, dates and formatting</param>
    /// <param name="applicationCode">Application code of the application the configuration was built with: SPA=Speaker Management, REG=Registration</param>
    /// <param name="configurationCode">Application sequence</param>
    /// <param name="defaultLanguage">"Y" or "N". Default language to be used when usersland on the site for the first time, using the base link that has no language information predefined.</param>
    /// <returns></returns>
    public PublicLanguagesModel Add(string orgCode,
                                    string languageCode, 
                                    int dictionarySequence, 
                                    string descriptionToUse, 
                                    string region, 
                                    string applicationCode,
                                    string configurationCode,
                                    string defaultLanguage)
    {
      PublicLanguagesModel language = new PublicLanguagesModel()
      {
        Organization = orgCode,
        ApplicationCode = applicationCode,
        ConfigurationCode = configurationCode,
        Language = languageCode,
        Dictionary = dictionarySequence,
        Region = region,
        DescriptionToUse = descriptionToUse,
        DefaultLanguage = defaultLanguage
      };

      return APIUtil.AddPublicLanguage(USISDKClient, language);
    }

    public PublicLanguagesModel Edit(int sequence, string languageCode)
    {
      PublicLanguagesModel language = APIUtil.GetPublicLanguage(USISDKClient, sequence);

      language.Language = languageCode;

      return APIUtil.UpdatePublicLanguage(USISDKClient, language);
    }

    /// <summary>
    /// Edit example
    /// </summary> 
    public PublicLanguagesModel EditAdvanced(int sequence)
    {

      PublicLanguagesModel language = APIUtil.GetPublicLanguage(USISDKClient, sequence);

      language.DescriptionToUse = "03"; // Alternate description 2
      language.DefaultLanguage = "N";
      language.WebSkin = 1346;
      language.Dictionary = 121; // Dictionary sequence number
      language.Region = "en-AU";

      return APIUtil.UpdatePublicLanguage(USISDKClient, language);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sequence)
    {
      APIUtil.AwaitDeletePublicLanguage(USISDKClient, sequence).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }
  }
}
