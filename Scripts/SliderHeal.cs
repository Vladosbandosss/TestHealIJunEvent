using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHeal : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Player _player;

    private float _health;
    private float _smothing = 5f;

    private void Awake()
    {
        _health = _player.CurrentHealth;
        _healthbar.maxValue = _player.MaxHealth;
        _healthbar.value = _health;
        _healthbar.minValue = _player.MinHealth;
    }

    private void OnEnable()
    {
       Player.PlayerChangedHealth += ChangeInfo; 
    }
    private void OnDisable()
    {
       Player.PlayerChangedHealth -= ChangeInfo;
    }
    private void Update()
    {
       ShowInfo();
    }
    private void ShowInfo()
    { 

        if (_healthbar.value != _health)
        {

           _healthbar.value = Mathf.Lerp(_healthbar.value, _health, _smothing * Time.deltaTime);

        }
    }
    
    private void ChangeInfo()
    {
        _health = _player.CurrentHealth;
    }
}
