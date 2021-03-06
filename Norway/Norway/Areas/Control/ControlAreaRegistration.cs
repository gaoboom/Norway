﻿using System.Web.Mvc;

namespace Norway.Areas.Control
{
    public class ControlAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Control";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Control_default",
                "Control/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Norway.Areas.Control.Controllers" }
            );
        }
    }
}