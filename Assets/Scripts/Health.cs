using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            Debug.Log($"Get Damage By {damageDealer.GetDamage()}");
            damageDealer.Hit();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}