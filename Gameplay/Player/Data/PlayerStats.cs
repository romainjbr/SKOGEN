using UnityEngine;

namespace Skogen.Gameplay.Player.Data
{
    [System.Serializable]
    public class PlayerStats
    {
        [Header("Movement")]
        [SerializeField] private readonly float jumpForce = 8f;
        [SerializeField] private readonly float walkSpeed = 5f;

        public float JumpForce => jumpForce;
        public float WalkSpeed => walkSpeed;

        public Vector2 Direction { get; set; }
    }
}