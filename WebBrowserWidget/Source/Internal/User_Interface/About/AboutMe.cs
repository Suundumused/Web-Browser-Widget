using System.Reflection;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.User_Interface.About;

internal partial class AboutMe : Form
{
    public AboutMe(Local.Master master)
    {
        Manager = master;
        InitializeComponent();
        //this.Text = String.Format("About {0}", AssemblyTitle);
        //this.labelProductName.Text = AssemblyProduct;
        labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
        //this.labelCopyright.Text = AssemblyCopyright;
        //this.labelCompanyName.Text = AssemblyCompany;
        //his.textBoxDescription.Text = AssemblyDescription;
    }

    protected Local.Master Manager { get; set; }

    private void labelProductName_Click(object sender, EventArgs e)
    {
        SpawnActor.CreateInstance(Manager, "https://example.com/");
    }

    private void Clicked(object sender, MouseEventArgs e)
    {
        Close();
    }

    private void Logo_Clicked(object sender, MouseEventArgs e)
    {
        SpawnActor.CreateInstance(Manager, "https://example.com/");
    }

    private void AboutMe_Load(object sender, EventArgs e)
    {

    }

    #region Assembly Attribute Accessors

    public string AssemblyTitle
    {
        get
        {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "") return titleAttribute.Title;
            }

            return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }
    }

    public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public string AssemblyDescription
    {
        get
        {
            var attributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
    }

    public string AssemblyProduct
    {
        get
        {
            var attributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
        }
    }

    public string AssemblyCopyright
    {
        get
        {
            var attributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }

    public string AssemblyCompany
    {
        get
        {
            var attributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }

    #endregion
}