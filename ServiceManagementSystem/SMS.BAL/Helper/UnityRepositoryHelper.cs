using SBS.DAL;
using SBS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace SBS.BAL.Helper
{
    public class UnityRepositoryHelper:UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IServiceRepository,ServiceRepository>();
        }
    }
}
