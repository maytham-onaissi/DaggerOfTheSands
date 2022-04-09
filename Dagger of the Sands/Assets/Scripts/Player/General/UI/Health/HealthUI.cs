using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{

    [Header("General")]
    [SerializeField] Health health;


    [Header("Specifications")]
    [SerializeField] public Image totalHealth;
    [SerializeField] public Image currentHealth;

    private void Start()
    {

    }

    public void ReturnToFullHealth()
    {
        totalHealth.fillAmount = health.totalHealth / 10;
        currentHealth.fillAmount = health.currentHealth / 10;

    }

    public void SetHealUI()
    {
        currentHealth.fillAmount = health.currentHealth / 10;
    }

}
