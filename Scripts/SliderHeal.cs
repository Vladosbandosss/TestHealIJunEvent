using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHeal : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Player _player;

    private float _health;
    private float _smothing = 10f;

    private Coroutine _changeHealth;

    private void Awake()
    {
        _health = _player.CurrentHealth;
        _healthbar.maxValue = _player.MaxHealth;
        _healthbar.value = _health;
        _healthbar.minValue = _player.MinHealth;
    }

    private void OnEnable()
    {
       _player.ChangedHealth += ChangeInfo; 
    }

    private void OnDisable()
    {
       _player.ChangedHealth -= ChangeInfo;
    }

    private void ChangeInfo()
    {
       _changeHealth = StartCoroutine(nameof(Changehealth));
    }

    private IEnumerator Changehealth()
    {
        _health = _player.CurrentHealth;

        while (_healthbar.value != _health)
        {
           
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, _health, _smothing * Time.deltaTime);

            yield return null;

            if(_healthbar.value == _health)
            {

                InterruptHealing();

            }
           
        }

        yield break;
    }

    private void InterruptHealing()
    {
        StopCoroutine(_changeHealth);
    }

}
