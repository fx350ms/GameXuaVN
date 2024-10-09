﻿using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace GameXuaVN.Web.Views
{
    public abstract class GameXuaVNRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected GameXuaVNRazorPage()
        {
            LocalizationSourceName = GameXuaVNConsts.LocalizationSourceName;
        }
    }
}
