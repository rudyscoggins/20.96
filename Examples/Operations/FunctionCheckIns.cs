using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class FunctionCheckIns : Base
  {
    public FunctionCheckIns(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public FunctionCheckInsModel Get(int sequence)
    {
      return APIUtil.GetFunctionCheckIn(USISDKClient, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<FunctionCheckInsModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<FunctionCheckInsModel>(USISDKClient, ref searchMetadata, string.Empty, "All");
    }

    public IEnumerable<FunctionCheckInsModel> Retrieve(string searchOData, string orderBy)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<FunctionCheckInsModel>(USISDKClient, ref searchMetadata, string.Empty, searchOData, orderBy);
    }

    /// <summary>
    /// This is shows how you perform a Function Check In on a registrant
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="checkInDateTime">Check-in date</param>
    /// <param name="checkInNote">Check-in note, can be empty</param>
    /// <param name="orderNumber">Registrant order number</param>
    /// <param name="eventId">Event number</param>
    /// <param name="functionId">Registrant function ID</param>
    /// <param name="regSequenceNbr">Order registrant sequnce number</param>
    /// <param name="regAcct">Order registrant account code</param>
    public FunctionCheckInsModel Add(string orgCode,
                                    DateTime checkInDateTime,
                                    string checkInNote,
                                    int orderNumber,
                                    int eventId,
                                    int functionId,
                                    int regSequenceNbr)
    {

      FunctionCheckInsModel functionCheckInModel = new FunctionCheckInsModel
      {
        OrganizationCode = orgCode,
        CheckIn = checkInDateTime,
        CheckInNote = checkInNote,
        OrderNumber = orderNumber,
        Event = eventId,
        Function = functionId,
        RegistrantSequence = regSequenceNbr
      };

      return APIUtil.AddFunctionCheckIn(USISDKClient, functionCheckInModel);
    }

    /// <summary>
    /// This is shows how you perform a Function Check Out on a registrant
    /// </summary> 
    public FunctionCheckInsModel Edit(int sequence, string checkInNote)
    {
      FunctionCheckInsModel functionCheckInModel = APIUtil.GetFunctionCheckIn(USISDKClient, sequence);

      functionCheckInModel.CheckInNote = checkInNote;

      return APIUtil.UpdateFunctionCheckIn(USISDKClient, functionCheckInModel);
    }

    public FunctionCheckInsModel EditAdvanced(int sequence, DateTime checkOutDate, int functionId)
    {
      FunctionCheckInsModel functionCheckInModel = APIUtil.GetFunctionCheckIn(USISDKClient, sequence);

      functionCheckInModel.CheckOut = checkOutDate;
      functionCheckInModel.CheckInNote = "ABC was here";
      functionCheckInModel.Function = functionId;

      return APIUtil.UpdateFunctionCheckIn(USISDKClient, functionCheckInModel);
    }


    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(int sequence)
    {
      APIUtil.AwaitDeleteFunctionCheckIn(USISDKClient, sequence).Wait();
    }
  }
}
