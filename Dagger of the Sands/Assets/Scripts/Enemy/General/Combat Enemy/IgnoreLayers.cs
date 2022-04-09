using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayers : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] EnemyController enemyController;

    [Header("Specifications")]
    [SerializeField] const int enemyLayer = 9;
    [SerializeField] const int ignoredPlayerLayer = 8;
    [SerializeField] const int groundLayer = 0;
    public bool isIgnoreLayer;

    // Update is called once per frame
    void Update()
    {
        if (isIgnoreLayer == true)
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
