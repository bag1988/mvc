using mvc.Models.Base;
using System.Collections.Generic;

namespace mvc.Areas.Admin.Models
{    
    public partial class newPageHtmlModel
    {
        public string actionName { get; set; }
        
        public List<newValueModulePage> newPageHtml { get; set; }
    }

    public partial class newValueModulePage
    {
        public string id { get; set; }
        public string css { get; set; }
        public string html { get; set; }
        public string data { get; set; }
    }

    /*public class newPage
    {
        public page Npage { get; set; }
        public IEnumerable<IdentityRole> roles { get; set; }
    }*/

    public class viewDirectory
    {
        public List<string> nameDirectory { get; set; }
        public List<string> nameFile { get; set; }
    }
}