// /**********************************************************************************
//  * File : WindowsSystem.cs
//  * Date: 20250307
//  * Author: Keith Douglas
//  **********************************************************************************/

using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace DesignPrinter;

public static class WindowsSystem
{
    /// <summary>
    /// creates the windows system report
    /// </summary>
    /// <returns>the json report as string</returns>
    public static string CreateWindowsSystemReport()
    {

        var BaseBuilder = new StringBuilder();

        using var BaseWriter = new StringWriter(BaseBuilder);
        using var Writer = new JsonTextWriter(BaseWriter);

        Writer.Formatting = Formatting.Indented;

        Writer.WriteStartObject();
        Writer.WritePropertyName("machineName");
        Writer.WriteValue(System.Environment.MachineName);
        Writer.WritePropertyName("os");
        Writer.WriteValue(Environment.OSVersion.VersionString);
        Writer.WritePropertyName("user");
        Writer.WriteValue(Environment.UserName);
        Writer.WritePropertyName("userDomain");
        Writer.WriteValue(Environment.UserDomainName);
        Writer.WritePropertyName("screens");
        Writer.WriteStartArray();

        for (var C = 0; C < Screen.AllScreens.Length; C++)
        {
            Writer.WriteStartObject();

            Writer.WritePropertyName("slot");
            Writer.WriteValue(C + 1);
            Writer.WritePropertyName("isPrimary");
            Writer.WriteValue(Screen.AllScreens[C].Primary);
            Writer.WritePropertyName("BitsPerPixel");
            Writer.WriteValue(Screen.AllScreens[C].BitsPerPixel);
            Writer.WriteBounds("bounds", Screen.AllScreens[C].Bounds);
            Writer.WriteBounds("workingArea", Screen.AllScreens[C].WorkingArea);

            Writer.WriteEndObject();
        }

        Writer.WriteEndArray();
        Writer.WriteEndObject();

        return BaseBuilder.ToString();
    }
}