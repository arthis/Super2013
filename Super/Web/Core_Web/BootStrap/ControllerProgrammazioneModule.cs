using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Core_Web.Controllers;
using Core_Web.Controllers.Contabilita;
using Core_Web.Controllers.Programmazione;
using Ninject.Modules;

namespace Core_Web.BootStrap
{
    public class ControllerProgrammazioneModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IController>().To<PianoRotabileController>()
                .When(request => request.Target.Member.Name.StartsWith("PianoRotabile"));
            
            

        }
    }
}
