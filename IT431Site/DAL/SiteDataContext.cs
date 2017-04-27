using IT431Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT431Site.DAL
{
    public class SiteDataContext:DbContext
    {
        public DbSet<Widget> Widgets { get; set; }
    }
}