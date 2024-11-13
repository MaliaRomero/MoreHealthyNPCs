using System;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    public GameObject crown;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float) currentHealth / (float) startingHealth; }
    }

    public void TakeDamage(int amount)
    {   
        if (startingHealth >= 1000)
        {
            if (crown != null)
            {
                crown.SetActive(!crown.activeSelf);
            } else {
                crown.SetActive(true);
            }
        } 
        else 
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

            currentHealth -= amount;

            OnHPPctChanged(CurrentHpPct);

            if (CurrentHpPct <= 0)
                Die();            
        }
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}