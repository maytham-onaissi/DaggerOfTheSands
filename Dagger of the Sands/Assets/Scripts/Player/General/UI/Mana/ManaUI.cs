using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("VFX")]
    [SerializeField] public Slider slider;
    [SerializeField] public Gradient gradiant;
    [SerializeField] public Image fill;

    private void Start()
    {
            
    }

    public void SetMaxMana(float _Amount)
    {
        slider.maxValue = _Amount;
        slider.value = _Amount;

        fill.color = gradiant.Evaluate(1f);
    }

    public void SetMana(float _Amount)
    {
        slider.value = _Amount;
        fill.color = gradiant.Evaluate(slider.normalizedValue);
    }
}
