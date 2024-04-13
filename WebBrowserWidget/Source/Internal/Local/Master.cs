using Newtonsoft.Json.Linq;
using System.Reflection;
using WebBrowserWidget.Source.Internal.Customize;
using WebBrowserWidget.Source.Internal.Master;
using WebBrowserWidget.Source.Internal.User_Interface.About;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal class Master
    {
        private NotifyIcon? Icon_x;
        private AboutMe ?AboutOfMe { get; set; } = null;

        private string Ico_path { get; } = "";
        public static string H_path { get; } = System.IO.Path.Combine(Program.basepath, "User", "historic.csv");
        public static string F_path { get; } = System.IO.Path.Combine(Program.basepath, "User", "favorites.csv");
        private string Path { get; } = System.IO.Path.Combine(Program.basepath, "Settings", "User_Settings.json");
        private string DataPath { get; } = System.IO.Path.Combine(Program.basepath, "Data", "EBWebView");
        public string? Base_path { get; set; } = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string ExecutablePath { get; } = Application.ExecutablePath.ToString();

        public bool OnFavorites { get; set; } = false;

        private ToolStripMenuItem ?AutoBoot;
        private ToolStripMenuItem ?Objects;

        private int MaxBSave { get;} = 1;
        private int MaxBSaveCount { get; set; } = 0;

        public List<dynamic> Instances { get; set; } = [];

        public void Init() 
        {
            DeleteDataTask();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Instances = new List<dynamic>();

            try
            {
                if (Base_path == null || Base_path == "")
                {
                    Base_path = AppContext.BaseDirectory;
                }
                SpawnTray();
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            };
        }

        public void SavePeriodically() 
        {
            if (MaxBSaveCount < MaxBSave) 
            {
                MaxBSaveCount++;
            }
            else 
            {
                Customize_Class.Save_Customs(Instances);
                MaxBSaveCount = 0;
            };
        }

        private void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            Customize_Class.Save_Customs(Instances);
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            Customize_Class.Save_Customs(Instances);
        }

        private void SpawnTray() 
        {
            Icon_x = new NotifyIcon();
            try
            {
                Icon_x.Icon = Properties.Resources._16x;
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            Icon_x.MouseClick += List_Instances;
            Icon_x.Visible = true;
            
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem AboutThis = new ToolStripMenuItem("About");
            AboutThis.Click += AboutThisMe;
            contextMenu.Items.Add(AboutThis);

            ToolStripMenuItem Instancer = new ToolStripMenuItem("New Window");
            Instancer.Click += New_Instance;
            contextMenu.Items.Add(Instancer);

            Objects = new ToolStripMenuItem("Instances");
            contextMenu.Items.Add(Objects);

            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Settings");
            contextMenu.Items.Add(menuItem1);

            AutoBoot = new ToolStripMenuItem("Auto Boot");
            AutoBoot.Click += setAutoBoot;
            menuItem1.DropDownItems.Add(AutoBoot);

            ToolStripMenuItem Clear = new ToolStripMenuItem("Clear history");
            Clear.Click += Clear_Historic;
            menuItem1.DropDownItems.Add(Clear);

            ToolStripMenuItem ClearData = new ToolStripMenuItem("Clear User Data");
            ClearData.Click += Clear_User_Data;
            menuItem1.DropDownItems.Add(ClearData);

            ToolStripMenuItem setsclear = new ToolStripMenuItem("Clear settings");
            setsclear.Click += Clear_Settings;
            menuItem1.DropDownItems.Add(setsclear);

            ToolStripMenuItem historic = new ToolStripMenuItem("Historic");
            historic.Click += History;
            contextMenu.Items.Add(historic);

            ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Exit");
            menuItem2.Click += Exit;
            contextMenu.Items.Add(menuItem2);

            Icon_x.ContextMenuStrip = contextMenu;

            JObject? data = AppSettings.ReadSettings();

            if ((bool)data["AutoBoot"])
            {
                AutoBoot.CheckState = CheckState.Checked;
            }
            else
            {
                AutoBoot.CheckState = CheckState.Unchecked;
            };
            Application.Run();
        }

        protected void DeleteDataTask() 
        {
            JObject? data = AppSettings.ReadSettings();
            try
            {
                if ((bool)data["DeleteData"]) 
                {
                    if (System.IO.Path.Exists(DataPath))
                    {
                        Directory.Delete(DataPath, true);
                    };
                    data["DeleteData"] = false;
                    AppSettings.WriteSettings(data);
                };
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            };
        }

        private void Clear_User_Data(object? sender, EventArgs e)
        {
            JObject? data = AppSettings.ReadSettings();

            if (!(bool)data["DeleteData"])
            {
                try
                {
                    data["DeleteData"] = true;
                    AppSettings.WriteSettings(data);
                    MsgClass.Init("Restart to apply settings.", MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                };
            };
        }

        private void AboutThisMe(object? sender, EventArgs e)
        {
            if (AboutOfMe is not null) 
            {
                if (AboutOfMe.IsDisposed) 
                {
                    AboutOfMe = new AboutMe(this);
                    AboutOfMe.Show();
                };
            }
            else 
            {
                AboutOfMe = new AboutMe(this);
                AboutOfMe.Show();
            };
        }

        private void History(object? sender, EventArgs e)
        {
            if (!OnFavorites)
            {
                OnFavorites = true;
                ListClass.Init(this, Db_manager.ReadCSV(H_path), "Historic", "navigate");
            };
        }

        private void Clear_Historic(object? sender, EventArgs e)
        {
            try
            {
                if (File.Exists(H_path))
                {
                    File.Delete(H_path);
                };
            }
            catch (Exception es) 
            {
                MsgClass.Init(es.Message, MessageBoxIcon.Warning);
            };
        }

        private void Clear_Settings(object? sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                };
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            };
        }

        private void List_Instances(object? sender, EventArgs e)
        {
            Objects.DropDownItems.Clear();
            int i = 0;
            foreach (BrowserUI ?object_ in Instances)
            {
                if (object_ is null)
                {
                    Instances.RemoveAt(i);
                }
                else if (object_.IsDisposed) 
                {
                    Instances.RemoveAt(i);
                }
                else
                {
                    try
                    {
                        string documentTitle = "";

                        object_.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                                {
                                    try 
                                    {
                                        documentTitle = object_.webView21.CoreWebView2.DocumentTitle;
                                    }
                                    catch { documentTitle = "Loading..."; };
                                }
                            )
                        );
                        if (documentTitle == " " || documentTitle == "") 
                        {
                            documentTitle = "Loading...";
                        };
                        ToolStripMenuItem Item = new ToolStripMenuItem(documentTitle);
                        Item.Click += (object? sender, EventArgs e) => browser_focus(sender, e, object_);
                        Objects.DropDownItems.Add(Item);
                    }
                    catch { };
                };
                i++;
            };
        }

        private void browser_focus(object? sender, EventArgs e, dynamic index)
        {
            index.Invoke(new System.Windows.Forms.MethodInvoker(delegate { index.Activate(); }));
        }

        private void New_Instance(object sender, EventArgs e) 
        {
            SpawnActor.CreateInstance(this);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setAutoBoot(object sender, EventArgs e)
        {
            JObject? data = AppSettings.ReadSettings();

            if ((bool)data["AutoBoot"])
            {
                try
                {
                    Program.RegStart.DeleteValue("Web_Widget", false);
                    data["AutoBoot"] = false;
                    AutoBoot.CheckState = CheckState.Unchecked;

                }catch (Exception ex) 
                {
                    MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
                };
            }
            else
            {
                try
                {
                    Program.RegStart.SetValue("Web_Widget", ExecutablePath);
                    data["AutoBoot"] = true;
                    AutoBoot.CheckState = CheckState.Checked;
                }
                catch (Exception ex)
                {
                    MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                };
            };
            AppSettings.WriteSettings(data);
        }
    }
}
