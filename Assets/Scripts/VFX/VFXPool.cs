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
        private VFXView vfxPrefab;

        public VFXPool(VFXView vfxPrefab)
        {
            this.vfxPrefab = vfxPrefab;
        }

        public VFXController GetVFXFromPool() => GetItem<VFXController>();

        protected override VFXController CreateItem<T>() => new VFXController(vfxPrefab);

    }
}
