using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class OrderRegistrants : Base
  {
    public OrderRegistrants(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    public OrderRegistrantsModel Get(string orgCode, int registrantSequenceNbr)
    {
      return APIUtil.GetOrderRegistrant(USISDKClient, orgCode, registrantSequenceNbr);
    }

    /// <summary>
    /// Retrieve all order registrants per event. 
    /// </summary> 
    public IEnumerable<OrderRegistrantsModel> GetByEvent(string orgCode, int eventID)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OrderRegistrantsModel>(USISDKClient, ref searchMetadata, orgCode, $"Event eq {eventID}");
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<OrderRegistrantsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OrderRegistrantsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public IEnumerable<OrderRegistrantsModel> SearchForUserFields(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;

      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Order user fields of Issue Class = R (registration), Issue Type code = 01, organization code = 10, and User Text 02 (TXT_02).  It will return registrants where the value is '2'      
      return APIUtil.GetSearchList<OrderRegistrantsModel>(USISDKClient, ref searchMetadata, orgCode, "R|01|10|UserText02 eq '2'");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public OrderRegistrantsModel Edit(string orgCode, int registrantSequenceNbr, string strNewUserFieldText)
    {
      var myOrderRegistrant = APIUtil.GetOrderRegistrant(USISDKClient, orgCode, registrantSequenceNbr);

      myOrderRegistrant.RegistrantUserFields.UserText01 = strNewUserFieldText;

      return APIUtil.UpdateOrderRegistrant(USISDKClient, myOrderRegistrant);
    }

    /// <summary>
    /// A edit example updating approval status
    /// </summary> 
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// <param name="approvalAction">Action for the Registration Approval. Either 'A' for Approved or 'R' for Rejected</param>
    /// <param name="approvalLevel">Integer value representing the Approval Level</param>
    /// <param name="approvalComment">string value for comments regarding the approval or rejection</param>
    public HttpResponseMessage EditUpdatingApprovalStatus(string orgCode, int registrantSequenceNbr, string approvalAction, int approvalLevel, string approvalComment)
    {
      var myOrderRegistrantApproval = new UngerboeckSDKPackage.RegistrationApprovalsModel();
      myOrderRegistrantApproval.OrganizationCode = orgCode;
      myOrderRegistrantApproval.RegistrantSequenceNbr = registrantSequenceNbr;
      myOrderRegistrantApproval.RegistrantApprovalAction = approvalAction;
      myOrderRegistrantApproval.RegistrantApprovalLevel = approvalLevel;
      myOrderRegistrantApproval.ApprovalComment = approvalComment;

      return APIUtil.SetRegistrantApproval(USISDKClient, myOrderRegistrantApproval);      
    }

    /// <summary>
    /// This is an example of check-in registrant order
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// /// <param name="eventId">Event ID</param>
    public void CheckIn(string orgCode, int registrantSequenceNbr, int eventId)
    {
      //Note that only error responses are returned from this action call --.Wait() allows errors to catch properly here.
      APIUtil.AwaitCheckIn(USISDKClient, orgCode, registrantSequenceNbr, eventId).Wait();
    }

    /// <summary>
    /// This is an example of clear check-in registrant order
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// /// <param name="eventId">Event ID</param>
    public void ClearCheckIn(string orgCode, int registrantSequenceNbr, int eventId)
    {
      //Note that only error responses are returned from this action call --.Wait() allows errors to catch properly here.
      APIUtil.AwaitClearCheckIn(USISDKClient, orgCode, registrantSequenceNbr, eventId).Wait();
    }
  }
}
