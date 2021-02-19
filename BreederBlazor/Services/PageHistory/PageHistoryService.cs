using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.PageHistory
{
    public class PageHistoryService : IPageHistoryService
    {
        private Stack<string> History;

        public PageHistoryService ()
        {
            History = new Stack<string>();
        }

        public List<string> GetHistory()
        {
            return History.ToList<string>();
        }

        public string PopPage()
        {
            if (History.Count > 0)
                return History.Pop();
            else
                return "/";
        }

        public void PushPage(string url)
        {
            History.Push(url);
        }
    }
}
