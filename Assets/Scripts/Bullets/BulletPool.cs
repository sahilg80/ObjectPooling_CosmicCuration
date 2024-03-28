using CosmicCuration.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets;

        public BulletPool(BulletScriptableObject bulletScriptableObject, BulletView bulletView)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
            pooledBullets = new List<PooledBullet>();
        }

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.FirstOrDefault(bullet => !bullet.IsUsed);
                if (pooledBullet != null)
                {
                    pooledBullet.IsUsed = true;
                    return pooledBullet.Controller;
                }
            }
            return CreateNewBullet();
        }

        private BulletController CreateNewBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Controller = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.IsUsed = true;
            pooledBullets.Add(pooledBullet);
            return pooledBullet.Controller;
        }

        public void ReturnBullet(BulletController controller)
        {
            PooledBullet pooledBullet = pooledBullets.FirstOrDefault(bullet => bullet.Controller.Equals(controller));
            pooledBullet.IsUsed = false;
        }

        public class PooledBullet
        {
            public BulletController Controller;
            public bool IsUsed;
        }
    }
}
