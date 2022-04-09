using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float mana;
    public float health;
    public float[] position;

    public PlayerData (PlayerController player)
    { 
        health = player.playerStatus.currentHealth;
        level = player.GetCurrentScene();
        mana = player.playerStatus.currentMana;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
