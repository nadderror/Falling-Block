using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    [SerializeField] private Slider healthSlider;
    public event Action onDeath;

    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    void Update()
    {
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + (Vector3.down * 0.7f));
    }

    public void TakeDamage(float damageAmounth)
    {
        healthSlider.value--;
        if (healthSlider.value <= 0)
        {
            onDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}