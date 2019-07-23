using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Movement: MonoBehaviour
    {
        public float speed = 0.0f;

        public void Rotate(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public void Move(Vector3 destination)
        {
            transform.position = destination;
        }
    }
}
