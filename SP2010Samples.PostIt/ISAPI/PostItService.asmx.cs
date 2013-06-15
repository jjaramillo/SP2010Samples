using System.Web.Script.Services;
using System.Web.Services;

namespace SP2010Samples.PostIt.Services
{
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class PostItService : System.Web.Services.WebService
    {
        [WebMethod]
        public void AddPostIt(string title, string description, string owner, string[] sharedusers)
        {
            
        }


    }
}
