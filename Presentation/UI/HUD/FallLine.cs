using Skogen.UI.Menus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

namespace Skogen.UI.HUD
{
    public class FallLine : MonoBehaviour
    {
        public CinemachineCamera Vcam { get; set; }

        private void OnTriggerEnter2D(Collider2D collision) {

            if (collision.tag == "Player")
            {
                GameOverMenu.Instance.Show();
                Vcam.gameObject.SetActive(false);
            }
        }
    }
}