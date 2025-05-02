using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class SyncLogEntry {
    public DateTime Timestamp { get; set; }
    public string FileName { get; set; }
    public string ChangeType { get; set; } // "Created", "Modified", "Deleted"
    public string SourcePath { get; set; }
    public string TargetPath { get; set; }
    public long FileSize { get; set; }
    public DateTime LastModified { get; set; }
  }
}
