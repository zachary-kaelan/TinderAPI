using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderAPI.Models
{
    public class V2BaseModel<T>
    {
        public T data { get; protected set; }
        public Dictionary<string, object> meta { get; protected set; }
    }

    public class V2ResultsModel<T>
    {
        public T results { get; protected set; }
        public int status { get; protected set; }
        public string page_token { get; protected set; }
    }
}
