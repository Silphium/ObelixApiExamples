// /**********************************************************************************
//  * File : JsonWriterExtensions.cs
//  * Date: 20250307
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Drawing;
using Newtonsoft.Json;

namespace DesignPrinter;

public static class JsonWriterExtensions
{

    /// <summary>
    /// writes the bounds information for the supplied rectangle
    /// </summary>
    /// <param name="writer">the json text writer</param>
    /// <param name="propertyName">the property group name</param>
    /// <param name="bounds">the rectangle to be transcribed</param>
    /// <returns>the mutated json text writer</returns>
    public static JsonTextWriter WriteBounds(this JsonTextWriter writer, string propertyName, Rectangle bounds)
    {

        writer.WritePropertyName(propertyName);
        writer.WriteStartObject();
        writer.WritePropertyName("deltaX");
        writer.WriteValue(bounds.X);
        writer.WritePropertyName("deltaY");
        writer.WriteValue(bounds.Y);
        writer.WritePropertyName("height");
        writer.WriteValue(bounds.Height);
        writer.WritePropertyName("width");
        writer.WriteValue(bounds.Width);
        writer.WriteEndObject();
        return writer;
    }
}