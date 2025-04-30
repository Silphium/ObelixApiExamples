using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;

namespace DesignReporting.Notes;

internal static class DesignBookContextExtender
{

    /// <summary>
    /// set of characters not available to be used in file naming
    /// </summary>
    private static IList<char> _InvalidCharacters = [];

    /// <summary>
    /// verified set of the above
    /// </summary>
    private static IList<char> InvalidFileCharacters
    {
        get
        {
            if (_InvalidCharacters.Any())
            {
                _InvalidCharacters = Path.GetInvalidFileNameChars().ToList();
            }

            return _InvalidCharacters;
        }
    }
    
    
    
    /// <summary>
    /// performs a query against an existing notebook to check if 
    /// </summary>
    /// <param name="logBook"></param>
    /// <param name="logFolderQuery"></param>
    /// <returns></returns>
    internal static bool IsDirectoryUsed(this DesignNoteBook logBook, string logFolderQuery) 
                    => string.CompareOrdinal(logBook.NoteBookFolderName, logFolderQuery) == 0;



    /// <summary>
    /// makes the token file safe 
    /// </summary>
    /// <param name="logBook"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private static string MakeTokenFileSafe(this DesignNoteBook logBook, string token)
    {

        foreach (var TestChar in InvalidFileCharacters)
        {
            if(!token.Contains(TestChar)) continue;

            token = token.Replace(TestChar, '_');
        }
        return token;

    }

}