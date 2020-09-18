using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SessionProposalEvaluationCriteriaResponses : Base
  {
    public SessionProposalEvaluationCriteriaResponses(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SessionProposalEvaluationCriteriaResponsesModel Get(int sessionProposalEvaluationCriteriaResponseId)
    {
      return APIUtil.GetSessionProposalEvaluationCriteriaResponse(USISDKClient, sessionProposalEvaluationCriteriaResponseId);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<SessionProposalEvaluationCriteriaResponsesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SessionProposalEvaluationCriteriaResponsesModel>(USISDKClient, ref searchMetadata, string.Empty, "All");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<SessionProposalEvaluationCriteriaResponsesModel> RetrieveByOData(string oData)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SessionProposalEvaluationCriteriaResponsesModel>(USISDKClient, ref searchMetadata, string.Empty, oData);
    }


    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="sessionProposalEvaluationId">Session proposal evaluation sequence number</param>
    /// <param name="evaluationResponseId">Session proposal criteria response id</param>
    /// <returns></returns>
    public SessionProposalEvaluationCriteriaResponsesModel Add(int sessionProposalEvaluationId, int evaluationResponseId)
    {
      SessionProposalEvaluationCriteriaResponsesModel sessionProposalEvaluationCriteriaResponse = new SessionProposalEvaluationCriteriaResponsesModel()
      {
        SessionProposalEvaluation = sessionProposalEvaluationId,
        EvaluationResponse = evaluationResponseId
      };

      return APIUtil.AddSessionProposalEvaluationCriteriaResponse(USISDKClient, sessionProposalEvaluationCriteriaResponse);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="sessionProposalEvaluationCriteriaResponseId">Session proposal evaluation criteria response ID</param>
    /// <param name="evaluationResponseId">Session proposal criteria response id</param>
    /// <returns></returns>
    public SessionProposalEvaluationCriteriaResponsesModel Edit(int sessionProposalEvaluationCriteriaResponseId, int evaluationResponseId)
    {
      SessionProposalEvaluationCriteriaResponsesModel sessionProposalEvaluationCriteriaResponse = APIUtil.GetSessionProposalEvaluationCriteriaResponse(USISDKClient, sessionProposalEvaluationCriteriaResponseId);

      sessionProposalEvaluationCriteriaResponse.EvaluationResponse = evaluationResponseId;

      return APIUtil.UpdateSessionProposalEvaluationCriteriaResponse(USISDKClient, sessionProposalEvaluationCriteriaResponse);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sessionProposalEvaluationCriteriaResponseId)
    {
      APIUtil.AwaitDeleteSessionProposalEvaluationCriteriaResponse(USISDKClient, sessionProposalEvaluationCriteriaResponseId).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }
  }
}
