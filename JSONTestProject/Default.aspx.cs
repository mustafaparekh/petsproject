using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;



public partial class _Default : System.Web.UI.Page
{
    string PET_TYPE_FILTER = "Cat";
    
    // Loads the JSON data and call main function to start processing
    protected void Page_Load(object sender, EventArgs e)
    {
        string data = loadData(ConfigurationManager.AppSettings["jsonDataUrl"]);
        startProcessing(data, PET_TYPE_FILTER);
    }

    // Loads the JSON data from remote URL 
    private string loadData(string jsonUrl) 
    {
        WebClient webC = new WebClient();
        return webC.DownloadString(jsonUrl);
    }

    // Take Json data and petTypeFilter as arguments, performs processing and prints the output
    private void startProcessing(string data, string petTypeFilter) 
    {
        JArray jsonCollection = JArray.Parse(data);
        Util u = new Util();
        List<string> mGender = u.getDataForGenderGroup(jsonCollection, "Male", petTypeFilter);
        List<string> fGender = u.getDataForGenderGroup(jsonCollection, "Female", petTypeFilter);
        List<string> uGender = u.getDataForGenderGroup(jsonCollection, "Unknown", petTypeFilter);

        ltMale.Text = String.Join("<br/>", mGender.ToArray());
        ltFemale.Text = String.Join("<br/>", fGender.ToArray());
        ltUnknown.Text = String.Join("<br/>", uGender.ToArray());
    }
}