namespace my_diary_tests;

public class NoteData
{
    public string Header { get; set; } = "undefined";
    public string Content { get; set; } = "undefined";

    public NoteData()
    {
        
    }
    public NoteData(string header, string content)
    {
        Header = header;
        Content = content;
    }
}