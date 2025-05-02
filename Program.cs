using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSyncApp {
  public static class Program {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainForm view = new MainForm();

      XmlLogger xmlLogger = new XmlLogger("sync_log.xml");

      // JsonLogger jsonLogger = new JsonLogger("sync_log.json");

      MainPresenter presenter1 = new MainPresenter(view, xmlLogger); // xmlLogger на jsonLogger

      Application.Run(view);
    }
  }
}
