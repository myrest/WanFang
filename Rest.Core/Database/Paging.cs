using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rest.Core
{
    public class Paging
    {
        /// <summary>
        /// The current page number contained in this page of result set
        /// </summary>
        public long CurrentPage
        {
            get;
            set;
        }

        /// <summary>
        /// The total number of pages in the full result set
        /// </summary>
        public long TotalPages
        {
            get;
            set;
        }

        /// <summary>
        /// The total number of records in the full result set
        /// </summary>
        public long TotalItems
        {
            get;
            set;
        }

        /// <summary>
        /// The number of items per page
        /// </summary>
        public long ItemsPerPage
        {
            get;
            set;
        }

        /// <summary>
        /// User property to hold anything.
        /// </summary>
        public object Context
        {
            get;
            set;
        }

        public void Convert<T>(Rest.Core.PetaPoco.Page<T> DatabaseObject)
        {
            this.Context = DatabaseObject.Context;
            this.CurrentPage = DatabaseObject.CurrentPage;
            this.ItemsPerPage = DatabaseObject.ItemsPerPage;
            this.TotalItems = DatabaseObject.TotalItems;
            this.TotalPages = DatabaseObject.TotalPages;
        }

    }
}
