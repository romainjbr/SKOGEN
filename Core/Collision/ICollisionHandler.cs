using UnityEngine;

namespace Skogen.Core.Collision
{
    public interface ICollisionHandler
    {
        void CollisionEnter(string colliderName, GameObject other, bool isEnter);
        void CollisionExit(string colliderName, GameObject other);
    }
}
