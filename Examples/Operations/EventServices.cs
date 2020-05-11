using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventServices : Base
  {
    public EventServices(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public EventServicesModel Get(string orgCode, int eventId, int sequenceNumber)
    {
      return APIUtil.GetEventService(USISDKClient, orgCode, eventId, sequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<EventServicesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<EventServicesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example with a constructed EventServicesModel object
    /// </summary> 
    public EventServicesModel Add(EventServicesModel myEventService)
    {
      return APIUtil.AddEventService(USISDKClient, myEventService);
    }

    /// <summary>
    /// A basic edit example with a constructed EventServiceModel object
    /// </summary> 
    public EventServicesModel Edit(EventServicesModel myEventService)
    {
      return APIUtil.UpdateEventService(USISDKClient, myEventService);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string orgCode, int eventId, int sequenceNumber)
    {
      APIUtil.AwaitDeleteEventService(USISDKClient, orgCode, eventId, sequenceNumber).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }
  }
}
