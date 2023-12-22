

using TaskSharedWpf.Models;

namespace TaskSharedWpf.Interfaces;

internal interface IFileService
{
    bool SaveContentToFile(string filePath, string content);

    string GetContentFromFile(string filePath);
    
}
