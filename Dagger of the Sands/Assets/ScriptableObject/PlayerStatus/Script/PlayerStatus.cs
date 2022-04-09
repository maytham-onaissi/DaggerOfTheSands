using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "status", menuName = "Player status" )]
public class PlayerStatus : ScriptableObject
{
    [SerializeField] public float totalMana;
    [Range(6, 10)]
    [SerializeField] public float totalHealth;
    [SerializeField] public float currentMana;
    [SerializeField] public float currentHealth;
    [SerializeField] public int currentDamage;
    [SerializeField] public bool daggerAquired;
    [SerializeField] public bool firstGemAquired;
    [SerializeField] public bool secondGemAquired;
}
