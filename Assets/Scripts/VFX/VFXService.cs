using Assets.Scripts.VFX;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private List<VFXData> vfxData = new List<VFXData>();
        private VFXPool vFXPool;

        public VFXService(VFXScriptableObject vfxScriptableObject)
        {
            vfxData = vfxScriptableObject.vfxData;
            vFXPool = new VFXPool(vfxData);
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            VFXController vfxToPlay = new VFXController(prefabToSpawn);
            vfxToPlay.Configure(spawnPosition);
        }
    } 
}