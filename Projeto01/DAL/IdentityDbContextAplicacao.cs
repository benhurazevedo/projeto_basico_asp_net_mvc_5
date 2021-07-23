using Microsoft.AspNet.Identity.EntityFramework;
using Projeto01.Areas.Seguranca.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto01.DAL
{
    public class IdentityDbContextAplicacao: IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base ("IdentityDb")
        {

        }

        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDbInit());
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new DAL.IdentityDbContextAplicacao();
        }

        public class IdentityDbInit: DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
        {

        }
    }
}