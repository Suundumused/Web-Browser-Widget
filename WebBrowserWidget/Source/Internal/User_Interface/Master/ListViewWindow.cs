using System;
using System.Drawing.Drawing2D;
using WebBrowserWidget.Source.Internal.User_Interface.Master.Content;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master
{
    public partial class ListViewWindow : Form
    {
        private dynamic myParent { get; set; }

        private List<string> MineContent { get; set; }
        public List<UserClick> AllButtons { get; set; } = [];

        private string MineEventType { get; set; }

        private Thread SpawnerItens { get; set; }
        public string minePath { get; } = "";

        public ListViewWindow(dynamic Instance, List<string> Content, string title = "", string event_type = "navigate")
        {
            myParent = Instance;
            MineContent = Content;
            MineEventType = event_type;
            this.Text = title;
            if (title == "Favorites") 
            {
                minePath = Path.Combine(Program.basepath, "User", "favorites.csv");
            }
            else 
            {
                minePath = Path.Combine(Program.basepath, "User", "historic.csv");
            }
            this.TopMost = true;
            InitializeComponent();
            BringToFront();
            Activate();
        }

        private void UpdateUI(ListViewWindow instance)
        {
            try
            {
                AllButtons = new List<UserClick>();

                long i = 0;
                foreach (string thing in MineContent)
                {
                    instance.Invoke(new System.Windows.Forms.MethodInvoker(delegate { 
                                try{
                                    UserClick new_button = new UserClick(instance.myParent, instance, thing, MineEventType);
                                    panel1.Controls.Add(new_button);
                                    AllButtons.Add(new_button);
                                    if (i == 0) 
                                    {
                                        new_button.Visible = false;
                                        new_button.Enabled = false;
                                    }
                                }catch{}
                            }
                        )
                    );
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
