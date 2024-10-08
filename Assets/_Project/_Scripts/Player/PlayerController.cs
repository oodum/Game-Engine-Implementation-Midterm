using System;
using _Project._Scripts;
using Managers;
using Game;
using Input;
using UnityEngine;
namespace Player {
    public class PlayerController : MonoBehaviour {
        [SerializeField] PlayerInputProcessor inputProcessor;
        [SerializeField] float moveSpeed;
        [SerializeField] BulletFactory bulletFactory;
        Rigidbody rb;
        Vector3 velocity, direction;
        void OnEnable() {
            inputProcessor.OnMove += Move;
            inputProcessor.OnAttack += Attack;
        }

        void OnDisable() {
            inputProcessor.OnMove -= Move;
            inputProcessor.OnAttack -= Attack;
        }

        void Awake() {
            rb = GetComponent<Rigidbody>();
            direction = Vector3.right;
        }

        void Move(Vector2 direction) {
            if (direction.x != 0) {
                this.direction = Vector3.right * direction.x;
                transform.rotation = Quaternion.Euler(0, Mathf.Sign(direction.x) > 0 ? 0 : 180, 0);
            }
            rb.linearVelocity = new Vector3(direction.x, direction.y, 0) * moveSpeed;
        }

        void Attack() {
            bulletFactory.CreateBullet(transform.position, direction);
        }
        
        void OnCollisionEnter(Collision other) {
            if (other.gameObject.CompareTag("Shell")) {
                GameManager.Instance.Shells++;
                Destroy(other.gameObject);
            }
        }
    }
}
