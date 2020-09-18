
using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class JournalEntries : Base
  {
    public JournalEntries(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public JournalEntriesModel Get(string orgCode, int year, int period, string source, string entryNumber)
    {
      return APIUtil.GetJournalEntry(USISDKClient, orgCode, year, period, source, entryNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<JournalEntriesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<JournalEntriesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// Adds a Journal Entry 
    /// </summary>
    public JournalEntriesModel Add(string orgCode, int Event, int year, int period, string source, string entryNumber, string status, string description, System.DateTime transactionDate)
    {
      var myJournalEntry = new JournalEntriesModel
      {
        Organization = orgCode,
        Event = Event,
        Year = year,
        Period = period,
        Source = source,
        EntryNumber = entryNumber,
        Status = status,
        Description = description,
        TransactionDate = transactionDate
      };

      return APIUtil.AddJournalEntry(USISDKClient, myJournalEntry);
    }
   
    /// <summary>
    /// Updates an existing journal entry by updating the description value
    /// </summary>
    public JournalEntriesModel Edit(string orgCode, int year, int period, string source, string entryNumber)
    {
      JournalEntriesModel journalEntryModel = APIUtil.GetJournalEntry(USISDKClient, orgCode, year, period, source, entryNumber);
      string description = "Journal entry description edited via test " + System.DateTime.Now.ToString();
      journalEntryModel.Description = description;


      journalEntryModel = APIUtil.UpdateJouralEntry(USISDKClient, journalEntryModel);
      return journalEntryModel;
    }

    /// <summary>
    /// You can retrieve journal entries attached to journal entries items by utilizing the Select ability of the odata string.  
    /// Be sure to include the [], as this denotes it's a nested model.
    /// </summary> 
    public IEnumerable<JournalEntriesModel> GetWithJournalEntryDetails(string orgCode, int year, int period, string source, string entryNumber)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<JournalEntriesModel>(USISDKClient, ref searchMetadata, orgCode, $"Year eq {year} and Period eq {period} and Source eq {source} and EntryNumber eq {entryNumber}", "", 10000, 10000, new List<string> { "[JournalEntryDetails]" });
    }

  }
}
