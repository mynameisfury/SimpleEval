using System;
using System.Collections.Generic;
using SimpleEval.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleEval
{
    public class ApplicationContext : DbContext
    {
        public System.Data.Entity.DbSet<SimpleEval.Models.Product> Products { get; set; }
    }
}