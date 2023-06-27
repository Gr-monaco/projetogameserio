using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{

  public int maxHealth = 20;

  [SerializeField]
  private int health;

  public int Health
  {
    get => health;
    set
    {
      health = value;
      OnHealthChange?.Invoke((float)Health / maxHealth);
      Debug.Log("OnHealthChange");
    }
  }

  public UnityEvent OnDead;
  public UnityEvent<float> OnHealthChange;
  public UnityEvent OnHit;
  public UnityEvent OnHeal;

  // Start is called before the first frame update
  void Start()
  {
    if (health == 0)
    {
      Health = 10;
    }
  }

  internal void Hit(int damagePoints)
  {
    Health -= damagePoints;
    if (Health <= 0)
    {
      OnDead?.Invoke();
    }
    else
    {
      OnHit?.Invoke();
    }
  }

  public void Heal(int healthRestored)
  {
    Health += healthRestored;
    Health = Mathf.Clamp(Health, 0, maxHealth);
    OnHeal?.Invoke();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
