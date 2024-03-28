using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        public T GetPooledItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.IsUsed);
                if (item != null)
                {
                    item.IsUsed = true;
                    return item.Item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreatePooledItem();
            newItem.IsUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreatePooledItem()
        {
            throw new NotImplementedException();
        }

        public void ReturnPooledItem(T item)
        {
            PooledItem<T> pooledBullet = pooledItems.Find(i => i.Item.Equals(item));
            pooledBullet.IsUsed = false;
        }

        public class PooledItem<U>
        {
            public U Item;
            public bool IsUsed;
        }
    }
}
