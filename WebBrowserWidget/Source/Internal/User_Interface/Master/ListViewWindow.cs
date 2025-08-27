using WebBrowserWidget.Source.Internal.User_Interface.Master.Content;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master;

public partial class ListViewWindow : Form
{
    public ListViewWindow(dynamic Instance, List<string> Content, string title = "", string event_type = "navigate")
    {
        myParent = Instance;
        MineContent = Content;
        MineEventType = event_type;
        Text = title;
        if (title == "Favorites")
            minePath = Local.Master.F_path;
        else
            minePath = Local.Master.H_path;
        TopMost = true;
        InitializeComponent();
        BringToFront();
        Activate();
    }

    public dynamic myParent { get; set; }

    private List<string> MineContent { get; }
    public List<UserClick> AllButtons { get; set; } = [];

    public string MineEventType { get; set; }

    private Thread SpawnerItens { get; set; }
    public string minePath { get; } = "";

    private void UpdateUI(ListViewWindow instance)
    {
        try
        {
            AllButtons = new List<UserClick>();

            long i = 0;
            foreach (var thing in MineContent)
            {
                instance.Invoke(new MethodInvoker(delegate
                        {
                            try
                            {
                                var new_button = new UserClick(instance.myParent, instance, thing, MineEventType);
                                instance.panel1.Controls.Add(new_button);
                                instance.AllButtons.Add(new_button);
                                if (i == 0)
                                {
                                    new_button.Visible = false;
                                    new_button.Enabled = false;
                                }
                            }
                            catch
                            {
                            }
                        }
                    )
                );
                i++;
            }

            ;

            instance.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            instance.label1.Dispose();
                        }
                        catch
                        {
                        }
                    }
                )
            );

            if (Text == "Favorites")
                instance.Invoke(new MethodInvoker(delegate
                        {
                            try
                            {
                                var btnadd = new AddToListBTN(this, myParent);
                                Controls.Add(btnadd);
                                btnadd.Dock = DockStyle.Bottom;
                            }
                            catch
                            {
                            }
                        }
                    )
                );
            ;

            instance.Invoke(new MethodInvoker(delegate { instance.panel1.AutoScroll = true; }
                )
            );
        }
        catch
        {
        }
    }

    public void AddPersonalBTN()
    {
        var my_browser = myParent.webView21;
        var documentTitle = "";

        myParent.Invoke(new MethodInvoker(delegate { documentTitle = myParent.webView21.CoreWebView2.DocumentTitle; }));

        if (documentTitle == " " || documentTitle == "") documentTitle = "Loading...";
        ;

        var new_button = new UserClick(myParent, this, $"{documentTitle},{my_browser.Source}", MineEventType);
        panel1.Controls.Add(new_button);
        AllButtons.Add(new_button);
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