﻿

using System.Diagnostics;
using TaskSharedWpf.Interfaces;

namespace TaskSharedWpf.Services;

public class FileService : IFileService
{

    public bool SaveContentToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false; 
    }

    public string GetContentFromFile(string filePath)
    {
        try
        {

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

 
}
