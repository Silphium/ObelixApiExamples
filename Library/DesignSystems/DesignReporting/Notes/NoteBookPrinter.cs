namespace DesignReporting.Notes;

/// <summary>
///  
/// </summary>
public static class NoteBookPrinter
{
    /// <summary>
    /// list of all the folders used by created notebooks. This is to prevent
    /// the creation of more than one active log file in a directory
    /// </summary>
    private static readonly IList<DesignNoteBook> _OpenBooks = new List<DesignNoteBook>();

    /// <summary>
    /// Creates a notebook instance
    /// </summary>
    /// <param name="logFolder"></param>
    /// <returns></returns>
    public static IDesignNoteBook CreateNoteBook(string logFolder, string token)
    {
        
        if (!_OpenBooks.Any())
        {
            var LogBook = new DesignNoteBook(logFolder, token);
            LogBook.OpenNoteBook();
            _OpenBooks.Add(LogBook);
            return LogBook;
        }


        return new DesignNoteBook(logFolder, token);
    }


    public static void CloseNoteBook(IDesignNoteBook logBook)
    {

        var LogBook = (DesignNoteBook)logBook;
        LogBook.CloseNoteBook();


        _OpenBooks.Remove(LogBook);

    }

}