using UnityEngine;
public class AttackHitBox : MonoBehaviour
{
    [Header("…À∫¶")]
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Vector2 hitDirection =(other.transform.position - transform.position).normalized;
                enemyHealth.TakeDamage(damage, hitDirection);
            }
        }
    }
}
