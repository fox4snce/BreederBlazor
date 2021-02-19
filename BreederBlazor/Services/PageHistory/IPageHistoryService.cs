using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.PageHistory
{
    public interface IPageHistoryService
    {
        void PushPage(string url);

        string PopPage();

        List<string> GetHistory();

    }
}
