using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class FileSync {
    private readonly ILogger _logger;
    private readonly Action<string> _logAction;

    public FileSync(ILogger logger, Action<string> logAction) {
      _logger = logger;
      _logAction = logAction;
    }

    public void SyncFolders(string sourceDir, string targetDir, bool isSourcePriority) {
      if (!Directory.Exists(sourceDir) || !Directory.Exists(targetDir)) {
        _logAction("Ошибка: одна из папок не существует!");
        return;
      }

      if (isSourcePriority) {
        SyncDirectory(sourceDir, targetDir);
        DeleteExtraFiles(sourceDir, targetDir);
      } else {
        SyncDirectory(targetDir, sourceDir);
        DeleteExtraFiles(targetDir, sourceDir);
      }
    }

    private void SyncDirectory(string source, string target) {
      foreach (string sourceFile in Directory.GetFiles(source)) {
        string fileName = Path.GetFileName(sourceFile);
        string targetFile = Path.Combine(target, fileName);
        DateTime lastModified = File.GetLastWriteTime(sourceFile);

        if (!File.Exists(targetFile)) {
          PerformSyncOperation(sourceFile, targetFile, "Created");
        } else if (_logger.NeedsSync(sourceFile, lastModified)) {
          PerformSyncOperation(sourceFile, targetFile, "Modified");
        }
      }
    }

    private void PerformSyncOperation(string sourceFile, string targetFile, string operationType) {
      try {
        File.Copy(sourceFile, targetFile, true);
        var fileInfo = new FileInfo(sourceFile);

        _logger.AddEntry(new SyncLogEntry {
          Timestamp = DateTime.Now,
          FileName = Path.GetFileName(sourceFile),
          ChangeType = operationType,
          SourcePath = Path.GetDirectoryName(sourceFile),
          TargetPath = Path.GetDirectoryName(targetFile),
          FileSize = fileInfo.Length,
          LastModified = File.GetLastWriteTime(sourceFile)
        });

        _logAction($"Файл {Path.GetFileName(sourceFile)} {GetRussianOperationName(operationType)}");
      }
      catch (Exception ex) {
        _logAction($"Ошибка при {operationType} файла {Path.GetFileName(sourceFile)}: {ex.Message}");
      }
    }

    private string GetRussianOperationName(string operationType) {
      switch (operationType) {
        case "Created":
          return "создан";
        case "Modified":
          return "изменён";
        case "Deleted":
          return "удалён";
        default:
          return operationType;
      }
    }

    private void DeleteExtraFiles(string source, string target) {
      foreach (string targetFile in Directory.GetFiles(target)) {
        string fileName = Path.GetFileName(targetFile);
        string sourceFile = Path.Combine(source, fileName);

        if (!File.Exists(sourceFile)) {
          try {
            File.Delete(targetFile);
            _logger.AddEntry(new SyncLogEntry {
              Timestamp = DateTime.Now,
              FileName = fileName,
              ChangeType = "Deleted",
              SourcePath = source,
              TargetPath = target,
              FileSize = 0,
              LastModified = DateTime.MinValue
            });
            _logAction($"Файл {fileName} удалён");
          }
          catch (Exception ex) {
            _logAction($"Ошибка при удалении файла {fileName}: {ex.Message}");
          }
        }
      }
    }
  }
}