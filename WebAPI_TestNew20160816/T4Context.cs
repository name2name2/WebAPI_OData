using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class T4Context : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public T4Context() : base("name=T4Context")
    {
    }

    public System.Data.Entity.DbSet<WebAPI_TestNew20160816.Models.T4> T4 { get; set; }

}
