using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public interface ILogger {
    void AddEntry(SyncLogEntry entry);
    bool NeedsSync(string filePath, DateTime lastModified);
    string GetLogStatistics();
  }
}
