using System;
using UnityEngine;
using UnityEngine.VFX;
namespace Game {
    public class Bullet : MonoBehaviour {
        [SerializeField] float speed;
        Rigidbody rb;
        Vector3 direction;
        public void Initialize(Vector3 direction) {
            this.direction = direction;
        }

        void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        void Update() {
            rb.linearVelocity = direction * speed;
        }

        void OnCollisionEnter(Collision other) {
            if (other.gameObject.GetComponentInParent<Enemy>() != null){
                other.gameObject.GetComponentInParent<Enemy>().TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}
