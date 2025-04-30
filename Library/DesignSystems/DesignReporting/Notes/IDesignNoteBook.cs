namespace DesignReporting.Notes;


/// <summary>
/// a logging notebook 
/// </summary>
public interface IDesignNoteBook
{
    /// <summary>
    /// the date and time of the created
    /// </summary>
    DateTime CreationTime { get; }

    /// <summary>
    /// the token identifier for th
    /// </summary>
    string Token { get; }

    /// <summary>
    /// the folder where this notebook is being written too.
    /// </summary>
    string NoteBookFolderName { get; }

    /// <summary>
    /// the name of the file 
    /// </summary>
    string NoteBookFileName { get; }

    /// <summary>
    /// writes a log note based upon the supplied information
    /// </summary>
    /// <param name="note">the note</param>
    void WriteNode(IDesignNote note);


}