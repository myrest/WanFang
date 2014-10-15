using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.About;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using WanFang.DAL.AboutContent;
using WanFang.DAL.Binding;
using Rest.Core;

namespace WanFang.BLL
{
    public class AboutBindingListing_Manage
    {
        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter)
        {
            return new AboutBindingListing_Repo().GetByParam(Filter);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page)
        {
            return new AboutBindingListing_Repo().GetByParam(Filter, Page, null, "");
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby)
        {
            return new AboutBindingListing_Repo().GetByParam(Filter, null, null, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby, Paging Page)
        {
            return new AboutBindingListing_Repo().GetByParam(Filter, Page, null, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return new AboutBindingListing_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }


    }
}