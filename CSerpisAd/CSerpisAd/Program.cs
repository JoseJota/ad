using System;
using Gtk;

namespace CSerpisAd {
    class MainClass {
        public static void Main(string[] args) {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
