using Assets.Scripts.VFX;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool vFXPool;
        private VFXView vfxPrefab;

        public VFXService(VFXView vFXView)
        {
            this.vfxPrefab = vFXView;
            vFXPool = new VFXPool(vFXView);
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = new VFXController(vfxPrefab);
            vfxToPlay.Configure(type,spawnPosition);
        }
    } 
}