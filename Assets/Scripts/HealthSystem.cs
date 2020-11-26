using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int healthMax;
    public int defence;

    public HealthSystem(int healthMax) {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth() {
        return health;
    }

    public float GetHealthPercent() {
        return (float) health / healthMax;
    }

    public void Damage(int damageAmount) {
        health -= (damageAmount-defence);
        if (health < 0) {
            health = 0;
            Destroy(gameObject);
        }
        //Debug.Log("Damaged "+health);
    }

    public void Heal(int healAmount) {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        //Debug.Log("Healed "+health);
    }
}
