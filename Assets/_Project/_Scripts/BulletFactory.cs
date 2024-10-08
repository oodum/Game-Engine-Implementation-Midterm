using Game;
using UnityEngine;
using Utility;
namespace _Project._Scripts {
    public class BulletFactory : Singleton<BulletFactory> {
        public Bullet bulletPrefab;
        public Bullet CreateBullet(Vector3 position, Vector3 direction) {
            Bullet bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            bullet.Initialize(direction);
            return bullet;
        }
    }
}
