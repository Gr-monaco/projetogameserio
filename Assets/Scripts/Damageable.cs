using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{

  ///<summary>
  ///Vida máxima da entidade.
  ///</summary>
  [SerializeField]
  private int maxHealth = 20;

  ///<summary>
  ///Vida atual da entidade
  ///</summary>
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

  /// <summary>
  /// Restaura a vida da entidade em uma determinada quantidade.
  /// </summary>
  /// <param name="healthRestored">A quantidade de vida a ser restaurada.</param>
  public void Heal(int healthRestored)
  {
    Health += healthRestored;
    Health = Mathf.Clamp(Health, 0, maxHealth);
    OnHeal?.Invoke();
  }
}
