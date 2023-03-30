// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

const string PATH_DICT = @".\Dictionary\";
if (!Directory.Exists(PATH_DICT))
{
    Directory.CreateDirectory(PATH_DICT);
}

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
        File.Create(PATH_DICT + a + ".txt");
    }
}
