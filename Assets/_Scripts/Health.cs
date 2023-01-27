using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float health;
    [SerializeField]private Slider healthSlider;
    void Start()
    {
        health = 10;
        healthSlider.value = health;
    }
    void Update()
    {
        
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position+(Vector3.down*0.7f));
    }
}
