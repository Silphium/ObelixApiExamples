// /**********************************************************************************
//  * File : StyleProperty.cs
//  * Date: 20250301
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace FluentSilk.Threads;

/// <summary>
/// This is used to store a property declaration for a cascading s 
/// </summary>
public class StyleProperty
{
    /// <summary>
    ///  the name of the CSS property
    /// </summary>
    public string PropertyName { get; } = string.Empty;

    /// <summary>
    /// the value for this CSS property
    /// </summary>
    public string PropertyValue { get; } = string.Empty;


}