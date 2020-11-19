using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace NestedJsonTestPomelo
{
    public class Blog
    {
        public string BlogId { get; set; }

        [Column(TypeName = "json")]
        public JObject Metadata { get; set; }
    }
}