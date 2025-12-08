using Skogen.Gameplay.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skogen.Gameplay.Items.Weapons
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        private Rigidbody2D rigidbody;
        private Vector3 shootingTarget;

        private void Update()
        {
            Move(shootingTarget);
        }

        private void OnTriggerEnter2D(Collider2D collision) 
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerController>()?.Context?.Health?.TakeDamage(1);
                Destroy(gameObject);
            }       
        }

        public void Move(Vector3 shootTarget)
        {
            shootingTarget = shootTarget;
            transform.position = Vector3.MoveTowards(transform.position, shootTarget * 100f, Time.deltaTime * speed);
        }

        private void OnBecameInvisible() 
        {
            Destroy(gameObject);
        }

    }
}