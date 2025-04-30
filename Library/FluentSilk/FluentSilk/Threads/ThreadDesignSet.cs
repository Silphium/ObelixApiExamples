using DesignReporting.Missives;

namespace FluentSilk.Threads;


/// <summary>
/// CSS 
/// </summary>
public class ThreadDesignSet
{

    private delegate void ReadFileLine();
    
    /// <summary>
    /// list of any saas variables used by this style
    /// sheet
    /// </summary>
    public readonly List<StyleProperty> Variables = [];
    
    /// <summary>
    /// list of all the declarations in the css file
    /// </summary>
    public readonly List<DesignStyle> Lines = [];
    

    /// <summary>
    /// loads the css file into memory
    /// </summary>
    /// <param name="fileLocation">the location of the css file</param>
    public IMissive Load(string fileLocation)
    {
        var SourceLines = File.ReadAllLines(fileLocation);
        var LineCount = SourceLines.Length;
        _ReadFileLine = LiminalReadState;

        for (var C = 0; C < LineCount; C++)
            _ReadFileLine(SourceLines[C]);


        return MissivePrinter.PrintFailure(null);
    }

    /// <summary>
    /// this is the 
    /// </summary>
    private Action<string> _ReadFileLine;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sourceLine"></param>
    private  void LiminalReadState(string sourceLine)
    {
        if (string.IsNullOrWhiteSpace(sourceLine)) return;





    }




    /// <summary>
    /// saves the css file
    /// </summary>
    /// <param name="fileName">the file name</param>
    public void Save(string fileName)
    {   

    }
}