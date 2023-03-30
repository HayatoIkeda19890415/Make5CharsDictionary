string PATH_DICT = init_Dictionary();
Dictionary<char, StreamWriter> dict = new Dictionary<char, StreamWriter>();
create_Files(PATH_DICT, dict);
string PATH_INPUT = check_OutPath();
write_Dictinary(dict, PATH_INPUT);

Console.WriteLine("finished.");
Console.ReadLine();

static string init_Dictionary()
{
    const string PATH_DICT = @".\Dictionary\";
    if (Directory.Exists(PATH_DICT))
    {
        Console.WriteLine(PATH_DICT + " Exists. Can I delete directory? y/else");
        string? input = Console.ReadLine();
        if (input != null && input.ToLower() == "y")
        {
            Directory.Delete(PATH_DICT, true);
            Directory.CreateDirectory(PATH_DICT);
        }
    }
    else
    {
        Directory.CreateDirectory(PATH_DICT);
    }

    return PATH_DICT;
}

static void create_Files(string PATH_DICT, Dictionary<char, StreamWriter> dict)
{
    for (char a = 'a'; a <= 'z'; a++)
    {
        string filepath = PATH_DICT + a + ".txt";
        if (File.Exists(filepath))
        {
            Console.WriteLine(filepath + " Exists. Please check the file.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        else
        {
            dict.Add(a, new StreamWriter(File.Create(PATH_DICT + a + ".txt")));
        }
    }
}

static string check_OutPath()
{
    const string PATH_INPUT = @".\input\words.txt";
    if (!File.Exists(PATH_INPUT))
    {
        Console.WriteLine(PATH_INPUT + " doesn't exists. Please check the path.");
        Console.ReadLine();
        Environment.Exit(0);
    }

    return PATH_INPUT;
}

static void write_Dictinary(Dictionary<char, StreamWriter> dict, string PATH_INPUT)
{
    StreamReader inputReader = new StreamReader(PATH_INPUT);
    while (inputReader.Peek() != -1)
    {
        string? word = inputReader.ReadLine();
        if (word == null || word.Length != 5)
        {
            continue;
        }
        char initial = word.First();
        if (!System.Text.RegularExpressions.Regex.Match(initial.ToString().ToLower(), @"[a-z]").Success)
        {
            continue;
        }
        StreamWriter? dictWriter = dict.GetValueOrDefault(initial);
        if (dictWriter == null)
        {
            continue;
        }
        dictWriter.WriteLine(word);
    }
    foreach (var item in dict.Values)
    {
        item.Close();
    }
}