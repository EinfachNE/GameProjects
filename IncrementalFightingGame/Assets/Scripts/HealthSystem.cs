using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private int currentHealth;
    private bool isAlive;
    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

    public void TakeDamage(int damageValue)
    {
        currentHealth -= damageValue;
        if (currentHealth < 0)
        {
            isAlive = false;
        }
    }
}


