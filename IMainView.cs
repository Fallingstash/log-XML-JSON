using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public interface IMainView {
    string SourceFolder { get; }
    string TargetFolder { get; }

    bool IsSourcePriority { get; }

    event EventHandler SyncClicked;

    void LogMessage(string message);
  }
}
