using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS.Core.Interface;

namespace IMS.Core.Services
{
    public class IMSService
    {
        private static IServiceImpl instance;
        public static IServiceImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    Type servicetype = Type.GetType(System.Configuration.ConfigurationManager.AppSettings["IMSServiceType"]);
                    instance = (IServiceImpl)servicetype.Assembly.CreateInstance(servicetype.FullName);
                }

                return instance;
            }
        }
    }
}
