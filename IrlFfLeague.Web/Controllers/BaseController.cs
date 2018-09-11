﻿using IrlFfLeague.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IrlFfLeague.Web.Controllers
{
    [LeaguesPopulator]
    [UsersPopulator]
    [SchemesPopulator]
    public class BaseController : Controller
    {
        
    }
}