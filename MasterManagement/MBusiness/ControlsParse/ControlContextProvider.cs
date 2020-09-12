using System;
using System.Collections.Generic;
using System.Text;

namespace MBusiness.ControlsParse
{
    /// <summary>
    /// ControlContext提供者
    /// </summary>
    internal class ControlContextProvider
    {
        public ControlContext Provider(Dictionary<string, object> pars)
        {
            ControlContext con = new ControlContext();

            //controlsdescription buillder
            con.Control = new ControlDescription(pars);
            //actiondescription builder;
            con.Action = con.Control.Action;
            return con;
        }
    }
}
