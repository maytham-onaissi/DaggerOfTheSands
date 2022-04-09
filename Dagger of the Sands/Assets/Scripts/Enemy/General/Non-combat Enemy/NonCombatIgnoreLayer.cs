using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCombatIgnoreLayer : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] NonCombatEnemyController nonCombatEnemyController;

    [Header("Specifications")]
    [SerializeField] const int enemyLayer = 9;
    [SerializeField] const int ignoredPlayerLayer = 8;
    [SerializeField] const int groundLayer = 0;
    public bool isIgnoreLayer;

    // Update is called once per frame
    void Update()
    {
        if (isIgnoreLayer)
        {
            IgnoreCollisionLayer();
        }
    }

    void IgnoreCollisionLayer()
    {
        Physics2D.IgnoreLayerCollision(enemyLayer, groundLayer, false);
        Physics2D.IgnoreLayerCollision(enemyLayer, ignoredPlayerLayer, true);
    }
}
