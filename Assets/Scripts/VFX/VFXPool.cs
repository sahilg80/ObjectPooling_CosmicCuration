using CosmicCuration.Utilities;
using CosmicCuration.VFX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private List<VFXData> vfxData;

        public VFXPool(List<VFXData> vfxData)
        {
            this.vfxData = vfxData;
        }

        public VFXController GetVFXFromPool<T>(VFXType type)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            return GetItem<T>();
        }

        protected override VFXController CreateItem<T>()
        {
            
        }

    }
}
