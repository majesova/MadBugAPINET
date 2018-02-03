﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(MadBug.WebAPI.Startup))]

namespace MadBug.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            app.UseCors(CorsOptions.AllowAll);

        }
    }
}
