using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class SessionProposalEvaluations : Base
  {
    public SessionProposalEvaluations(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SessionProposalEvaluationsModel Get(int sessionProposalEvaluationId)
    {
      return APIUtil.GetSessionProposalEvaluation(USISDKClient, sessionProposalEvaluationId);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<SessionProposalEvaluationsModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SessionProposalEvaluationsModel>(USISDKClient, ref searchMetadata, string.Empty, "All");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<SessionProposalEvaluationsModel> RetrieveByOData(string oData)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SessionProposalEvaluationsModel>(USISDKClient, ref searchMetadata, string.Empty, oData);
    }


    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="eventRoundEvaluatorID"></param>
    /// <param name="eventRoundSessionProposalID"></param>
    /// <param name="complete">True if all criteria for the session proposal has been responded to by the evaluator, otherwise False</param>
    /// <param name="note">Any extra note text entered by the evaluator pertaining to the evaluation of the session proposal.</param>
    /// <param name="skip">True if the evaluator does not want to evaluate the session proposal.</param>
    /// <returns></returns>
    public SessionProposalEvaluationsModel Add(int eventRoundEvaluatorID, int eventRoundSessionProposalID, bool complete, string note, bool skip)
    {
      SessionProposalEvaluationsModel evl = new SessionProposalEvaluationsModel()
      {
        EventRoundEvaluatorID = eventRoundEvaluatorID,
        EventRoundSessionProposalID = eventRoundSessionProposalID,
        Complete = complete,
        Note = note,
        Skip = skip
      };

      return APIUtil.AddSessionProposalEvaluation(USISDKClient, evl);
    }

    public SessionProposalEvaluationsModel Edit(int sessionProposalEvaluationId, string evaluationNote)
    {
      SessionProposalEvaluationsModel evl = APIUtil.GetSessionProposalEvaluation(USISDKClient, sessionProposalEvaluationId);

      evl.Note = evaluationNote;

      return APIUtil.UpdateSessionProposalEvaluation(USISDKClient, evl);
    }

    /// <summary>
    /// Edit example
    /// </summary> 
    public SessionProposalEvaluationsModel EditAdvanced(int sessionProposalEvaluationId)
    {

      SessionProposalEvaluationsModel evl = APIUtil.GetSessionProposalEvaluation(USISDKClient, sessionProposalEvaluationId);

      evl.Note = "Looks Good";
      evl.Complete = true; // True if all criteria for the session proposal has been responded to by the evaluator, otherwise False
      evl.Skip = false; // True if the evaluator does not want to evaluate the session proposal.

      return APIUtil.UpdateSessionProposalEvaluation(USISDKClient, evl);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sessionProposalEvaluationId)
    {
      APIUtil.AwaitDeleteSessionProposalEvaluation(USISDKClient, sessionProposalEvaluationId).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }
  }
}
