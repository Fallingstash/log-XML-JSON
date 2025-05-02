using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class JsonLogger : ILogger {
    private readonly string _logPath;
    private List<SyncLogEntry> _logEntries;

    public JsonLogger(string logPath) {
      _logPath = logPath;
      _logEntries = LoadLogs();
    }

    public void AddEntry(SyncLogEntry entry) {
      _logEntries.Add(entry);
      SaveLogs();
    }

    private List<SyncLogEntry> LoadLogs() {
      if (!File.Exists(_logPath)) return new List<SyncLogEntry>();

      var json = File.ReadAllText(_logPath);
      return JsonSerializer.Deserialize<List<SyncLogEntry>>(json);
    }

    private void SaveLogs() {
      var options = new JsonSerializerOptions { WriteIndented = true };
      var json = JsonSerializer.Serialize(_logEntries, options);
      File.WriteAllText(_logPath, json);
    }

    public bool NeedsSync(string filePath, DateTime lastModified) {
      var fileName = Path.GetFileName(filePath);
      SyncLogEntry lastEntry = null;

      foreach (var entry in _logEntries) {
        if (entry.FileName == fileName) {
          if (lastEntry == null || entry.Timestamp > lastEntry.Timestamp) {
            lastEntry = entry;
          }
        }
      }

      return lastEntry == null || lastEntry.LastModified < lastModified;
    }

    public string GetLogStatistics() {
      var entries = LoadLogs();
      var stats = entries
          .GroupBy(e => e.ChangeType)
          .ToDictionary(g => g.Key, g => g.Count());

      return $"Всего записей: {entries.Count}, " +
             $"Статистика: {string.Join(", ", stats.Select(kv => $"{kv.Key}: {kv.Value}"))}";
    }
  }
}
