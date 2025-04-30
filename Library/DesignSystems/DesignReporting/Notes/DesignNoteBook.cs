namespace DesignReporting.Notes;


/// <summary>
/// logging class for the design reporting systems
/// </summary>
internal class DesignNoteBook : IDesignNoteBook
{
    /// <summary>
    /// the date and time of the created
    /// </summary>
    public DateTime CreationTime { get; }

    /// <summary>
    /// the token identifier for th
    /// </summary>
    public string Token { get; }

    /// <summary>
    /// contains both the name and the 
    /// </summary>
    internal DirectoryInfo LogFolder { get; }

    /// <summary>
    /// the folder where this notebook is being written too.
    /// </summary>
    public string NoteBookFolderName => LogFolder.Name;

    /// <summary>
    /// the name of the file 
    /// </summary>
    public string NoteBookFileName { get; } = string.Empty;

    /// <summary>
    /// For the purposes of a thread safe logging system.
    /// </summary>
    private readonly object _SyncObject = new();

    /// <summary>
    /// the log writer
    /// </summary>
    private StreamWriter? NoteWriter =null;

    /// <summary>
    /// the command to open a notebook
    /// </summary>
    internal void OpenNoteBook()
    {
     
    }

    /// <summary>
    /// the command to close a notebook
    /// </summary>
    internal void CloseNoteBook()
    {
     
    }

    /// <summary>
    /// writes a log note based upon the supplied information
    /// </summary>
    /// <param name="note">the note</param>
    public void WriteNode(IDesignNote note)
    {


    }

    /// <summary>
    /// constructor
    /// </summary>
    internal DesignNoteBook(string logFolder, string token)
    {
        CreationTime = DateTime.Now;
        Token = token;
        LogFolder = new DirectoryInfo(logFolder);

        

    }
}