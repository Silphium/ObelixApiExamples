using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DesignPrinter.Missives.State;

namespace DesignPrinter.Missives.Error;


/// <summary>
/// this exception is thrown when the missive's status
/// code is out of range
/// </summary>
public class MissiveOutOfRangeException : Exception
{
    /// <summary>
    /// The missive which is the cause of this system failure
    /// </summary>
    public ISystemFailureMissive FailedMissive { get; }
    
    /// <summary>
    /// the list of all the valid status codes this missive 
    /// </summary>
    private readonly List<MissiveStatusCodes> _ValidStatusCodeList = new List<MissiveStatusCodes>();

    /// <summary>
    /// list of all the valid status codes 
    /// </summary>
    public IReadOnlyList<MissiveStatusCodes> ValidStatusCodesList => _ValidStatusCodeList;

    /// <summary>
    /// the calling method
    /// </summary>
    public string CallingMethod { get; }

    /// <summary>
    /// what source file the method was called from
    /// </summary>
    public string CallingSourcePath { get; }

    /// <summary>
    /// the line number 
    /// </summary>
    public int CallingSourceLineNumber = 0;

    /// <summary>
    /// the offending status code
    /// </summary>
    public MissiveStatusCodes InvalidStatusCode { get; }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="failedMissive">the missive where the exception was thrown</param>
    /// <param name="validCodeList">the list of all valid codes for that missive</param>
    /// <param name="invalidStatusCode">the invalid status code</param>
    /// <param name="memberName">the name of the calling method</param>
    /// <param name="sourceFilePath">the source file the exception was thrown</param>
    /// <param name="sourceLineNumber">the line number</param>
    public MissiveOutOfRangeException(IMissive? failedMissive, IList<MissiveStatusCodes> validCodeList, 
                                        MissiveStatusCodes invalidStatusCode,
                                        [CallerMemberName] string memberName = "", 
                                        [CallerFilePath] string sourceFilePath = "", 
                                        [CallerLineNumber] int sourceLineNumber = 0)
    {

        InvalidStatusCode = invalidStatusCode;
        _ValidStatusCodeList.AddRange(validCodeList);
        
        CallingMethod = memberName;
        CallingSourcePath = sourceFilePath;
        CallingSourceLineNumber = sourceLineNumber;

        FailedMissive = new SystemFailureMissive(failedMissive);

    }

} 