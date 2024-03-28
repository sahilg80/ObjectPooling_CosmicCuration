using CosmicCuration.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemy
{
    public class EnemyPool
    {
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyView enemyView;
        private List<PooledEnemy> pooledEnemies;

        public EnemyPool(EnemyScriptableObject enemyScriptableObject, EnemyView enemyView)
        {
            this.enemyScriptableObject = enemyScriptableObject;
            this.enemyView = enemyView;
            pooledEnemies = new List<PooledEnemy>();
        }

        public EnemyController GetEnemy()
        {
            if(pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy = pooledEnemies.FirstOrDefault(enemy => !enemy.IsUsed);
                if(pooledEnemy != null)
                {
                    pooledEnemy.IsUsed = true;
                    return pooledEnemy.Controller;
                }
            }
            return CreateNewEnemy();
        }

        private EnemyController CreateNewEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.Controller = new EnemyController(enemyView, enemyScriptableObject.enemyData);
            pooledEnemy.IsUsed = true;
            pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.Controller;
        }

        public void ReturnEnemy(EnemyController controller)
        {
            PooledEnemy pooledEnemy = pooledEnemies.FirstOrDefault(enemy => enemy.Controller.Equals(controller));
            pooledEnemy.IsUsed = false;
        }

        public class PooledEnemy
        {
            public EnemyController Controller;
            public bool IsUsed;
        }
    }
}
