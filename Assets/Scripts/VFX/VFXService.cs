using Assets.Scripts.VFX;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool vFXPool;

        public VFXService(VFXView vFXView)
        {
            vFXPool = new VFXPool(vFXView);
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vFXPool.GetVFXFromPool();
            vfxToPlay.Configure(type,spawnPosition);
        }

        public void ReturnVFXToPool(VFXController controller) => vFXPool.ReturnItem(controller);

    } 
}