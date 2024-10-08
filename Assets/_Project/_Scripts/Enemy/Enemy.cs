using UnityEngine;
public class Enemy : MonoBehaviour {
    [field: SerializeField] public int Health { get; set; }
    [SerializeField] GameObject shell;
    public void TakeDamage(int damage) {
        Health -= damage;
        if (Health <= 0) {
            Instantiate(shell, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
