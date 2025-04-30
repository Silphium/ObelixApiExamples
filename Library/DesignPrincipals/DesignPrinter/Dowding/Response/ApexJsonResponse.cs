// /**********************************************************************************
//  * File : ApexJsonResponse.cs
//  * Date: 20250308
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Drawing.Printing;
using System.Runtime.InteropServices.ComTypes;
using DesignPrinter.Missives.Details;

namespace DesignPrinter.Dowding.Response;

/// <summary>
/// a json response type
/// </summary>
public class ApexJsonResponse : IMissiveResponse
{
    /// <summary>
    /// the type of response 
    /// </summary>
    public string ResponseType => "application/json";

    /// <summary>
    /// the data for the response
    /// </summary>
    public string ResponseData { get; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseData"></param>
    public ApexJsonResponse(string responseData)
    {
        ResponseData = responseData;
    }
}