using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class MainPresenter {
    private readonly IMainView _view;
    private readonly FileSync _fileSync;
    private readonly ILogger _logger;

    public MainPresenter(IMainView view, ILogger logger) {
      _view = view;
      _logger = logger;
      _fileSync = new FileSync(_logger, _view.LogMessage);

      _view.SyncClicked += OnSyncClicked;
    }

    private void OnSyncClicked(object sender, EventArgs e) {
      _view.LogMessage("=== Синхронизация начата ===");
      _fileSync.SyncFolders(_view.SourceFolder, _view.TargetFolder, _view.IsSourcePriority);
      _view.LogMessage("=== Синхронизация завершена ===");

      // Дополнительно: показать статистику
      if (_logger is XmlLogger xmlLogger) {
        _view.LogMessage($"Лог сохранён в XML: {xmlLogger.GetLogStatistics()}");
      } else if (_logger is JsonLogger jsonLogger) {
        _view.LogMessage($"Лог сохранён в JSON: {jsonLogger.GetLogStatistics()}");
      }
    }
  }
}
