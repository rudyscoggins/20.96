using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrderItems : Base
  {
    public PurchaseOrderItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderItemsModel Get(string orgCode, int number, int itemSequence)
    {
      return APIUtil.GetPurchaseOrderItem(USISDKClient, orgCode, number, itemSequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PurchaseOrderItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PurchaseOrderItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    public UngerboeckSDKPackage.PurchaseOrderItemsModel Add(PurchaseOrderItemsModel purchaseOrderItemModel)
    {
      return UngerboeckSDKWrapper.APIUtil.AddPurchaseOrderItem(USISDKClient, purchaseOrderItemModel);
    }

    public PurchaseOrderItemsModel Edit(string orgCode, int number, int itemSequence, string orderDesc)
    {
      var purchaseOrderItem = APIUtil.GetPurchaseOrderItem(USISDKClient, orgCode, number, itemSequence);

      if (purchaseOrderItem != null)
      {
        purchaseOrderItem.Description = orderDesc;
      }

      return APIUtil.UpdatePurchaseOrderItem(USISDKClient, orgCode, number, itemSequence, purchaseOrderItem);
    }
  }
}
