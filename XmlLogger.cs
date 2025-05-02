using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FolderSyncApp {
  public class XmlLogger : ILogger {
    private readonly string _logPath;
    private List<SyncLogEntry> _logEntries;

    public XmlLogger(string logPath) {
      _logPath = logPath;
      _logEntries = LoadLogs();
    }

    public void AddEntry(SyncLogEntry entry) {
      _logEntries.Add(entry);
      SaveLogs();
    }

    private List<SyncLogEntry> LoadLogs() {
      if (!File.Exists(_logPath)) return new List<SyncLogEntry>();

      var serializer = new XmlSerializer(typeof(List<SyncLogEntry>));
      using (var reader = new StreamReader(_logPath)) {
        return (List<SyncLogEntry>)serializer.Deserialize(reader);
      }
    }

    private void SaveLogs() {
      var serializer = new XmlSerializer(typeof(List<SyncLogEntry>));
      using (var writer = new StreamWriter(_logPath)) {
        serializer.Serialize(writer, _logEntries);
      }
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
      return $"Всего записей: {entries.Count}, " +
             $"Последняя запись: {entries.LastOrDefault()?.Timestamp.ToString() ?? "нет"}";
    }
  }
}
