using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_0 : Enemy
{
    [Header("Inscribed")]
    public Transform player;        
    public float rotateSpeed = 3f;  

    void Start()
    {
        // If Player isn't assigned find object with tag player
        if (player == null)
        {
            GameObject heroGO = GameObject.FindGameObjectWithTag("Player");
            if (heroGO != null)
            {
                player = heroGO.transform;
            }
        }
    }

    public override void Move()
    {
        // If player isn't found default to downward movement
        if (player == null)
        {
            base.Move();
            return;
        }

        // Find the direction from enemy to player
        Vector3 direction = (player.position - transform.position).normalized;

        // Rotate the enemy toward the player
        Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);

        // Move the enemy forward to the player
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}