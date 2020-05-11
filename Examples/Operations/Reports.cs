using System.Collections.Generic;
using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System;

namespace Examples.Operations
{
  public class Reports : Base
  {

    public Reports(HttpClient USISDKClient) : base(USISDKClient) { }

    /// <summary>
    /// Tests the Get Parameters for the Controls Test
    /// </summary>
    public ParametersModel GetReportParameters(string astrOrgCode, int aintSequenceNumber)
    {
      ParametersModel parametersModel = APIUtil.GetReportParameters(USISDKClient, astrOrgCode, aintSequenceNumber);

      return parametersModel;
    }

    /// <summary>
    /// Tests the running of the controls text exported to pdf
    /// </summary>
    public ReportResponseModel RunReport(string astrOrgCode, int aintSequenceNumber, ReportRequestModel reportRequestModel)
    {
      ReportResponseModel reportResponseModel = APIUtil.RunReport(USISDKClient, astrOrgCode, aintSequenceNumber, reportRequestModel);

      return reportResponseModel;
    }

    /// <summary>
    /// Tests the running of the controls text exported to word
    /// </summary>
    public ReportResponseModel RunReport(string astrOrgCode, int aintSequenceNumber)
    {
      ParameterValues parameter;
      ReportRequestModel reportRequestModel = new ReportRequestModel();
      reportRequestModel.ExportType = USISDKConstants.ReportConstants.ExportType.PDF;

      parameter = new ParameterValues();
      parameter.ParameterName = "Single Select Text Custom Values";
      parameter.Values.Add("Value_2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Single Select No Custom Values";
      parameter.Values.Add("Value_1");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Multi Select No Custom Values";
      parameter.Values.Add("Value_1");
      parameter.Values.Add("Value_2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Number Type";
      parameter.Values.Add("8");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Single Date";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Currency Type";
      parameter.Values.Add("8.95");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Multi Select Text Box Custom Values";
      parameter.Values.Add("Value_1");
      parameter.Values.Add("I'm Custom");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Time Field";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Date Time Field";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Numeric Range Dropdown";
      parameter.Values.Add("1");
      parameter.Values.Add("2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Numeric Range";
      parameter.Values.Add("1");
      parameter.Values.Add("2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Date Range";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      parameter.Values.Add(DateTime.Now.AddDays(7).ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Boolean Value with Text";
      parameter.Values.Add(true.ToString());
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Boolean Value No Text";
      parameter.Values.Add("True");
      reportRequestModel.Parameters.Add(parameter);

      ReportResponseModel reportResponseModelTest = APIUtil.RunReport(USISDKClient, astrOrgCode, aintSequenceNumber, reportRequestModel);

      return reportResponseModelTest;
    }

  }
}
