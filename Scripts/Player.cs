using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _currentHealth = 50;
    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _damage = 10f;
    private float _heal = 10f;
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;

    public delegate void ChangeHealth();
    public static event ChangeHealth PlayerChangedHealth;

    public void Heal()
    {
        _currentHealth += _heal;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
       
        PlayerChangedHealth();
    }
    public void Damage()
    {
        _currentHealth -= _damage;

        if (_currentHealth < _minHealth)
        {
            _currentHealth = _minHealth;
        }
      
        PlayerChangedHealth();
    }
}
