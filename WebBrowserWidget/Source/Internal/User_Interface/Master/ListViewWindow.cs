using System;
using WebBrowserWidget.Source.Internal.User_Interface.Master.Content;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master
{
    public partial class ListViewWindow : Form
    {
        private dynamic myParent { get; set; }

        private List<string> MineContent { get; set; }
        private string MineEventType { get; set; }

        private Thread SpawnerItens { get; set; }

        public ListViewWindow(dynamic Instance, List<string> Content, string title = "", string event_type = "navigate")
        {
            myParent = Instance;
            MineContent = Content;
            MineEventType = event_type;
            this.Text = title;
            InitializeComponent();
            BringToFront();
            Activate();
        }

        private void UpdateUI(ListViewWindow instance)
        {
            try
            {
                long i = 0;
                foreach (string thing in MineContent)
                {
                    if (i > 0)
                    {
                        instance.Invoke(new System.Windows.Forms.MethodInvoker(delegate { panel1.Controls.Add(new UserClick(instance.myParent, instance, thing, MineEventType)); }));
                    };
                    i++;
                };

                instance.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            instance.panel1.AutoScroll = true;
                        }
                    )
                );
            }
            catch (ThreadInterruptedException) { }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            SpawnerItens.Interrupt();
            myParent.OnFavorites = false;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            SpawnerItens = new Thread(() => UpdateUI(this));
            SpawnerItens.Start();
        }
    }
}
