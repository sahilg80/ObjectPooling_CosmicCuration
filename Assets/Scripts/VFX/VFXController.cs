using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXController
    {
        private VFXView vfxView;

        public VFXController(VFXView vfxPrefab)
        {
            vfxView = Object.Instantiate(vfxPrefab);
            vfxView.SetController(this);
        }

        public void Configure(VFXType type, Vector2 spawnPosition)
        {
            vfxView.gameObject.SetActive(true);
            vfxView.ConfigureAndPlay(spawnPosition);
        }
    } 
}