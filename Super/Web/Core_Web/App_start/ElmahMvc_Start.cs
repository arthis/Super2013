[assembly: WebActivator.PreApplicationStartMethod(typeof(UI_Web.App_Start.ElmahMvc), "Start")]
namespace UI_Web.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}