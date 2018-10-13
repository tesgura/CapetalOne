using JusticePack.CapetalOne.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JusticePack.CapetalOne.BusinessLogic.Services.Interfaces
{
    public interface IAppSettingQueryService
    {
        Task<AppSettingListRp> GetAppSettings();
        Task<AppSettingGetRp> GetAppSettingById(string id);
    }
}
