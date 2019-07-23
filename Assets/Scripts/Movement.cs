using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Movement: MonoBehaviour
    {
        public float speed = 0.0f;
        private Vector3 destination;
        private bool isMoving = false;

        public void Rotate(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public Vector3 GetDestination()
        {
            return this.destination;
        }

        public bool GetIsMoving()
        {
            return this.isMoving;
        }

        public void SetDestination(Vector3 destination)
        {
            this.destination = new Vector3(destination.x, transform.position.y, destination.z);
            isMoving = true;
        }

        private void Update()
        {
            if (isMoving)
            {
                Debug.Log("Moving -> Position: " + transform.position + " destination: " + destination);
                transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);

                if (Vector3.Distance(transform.position, destination) < 0.1f)
                    isMoving = false;
            }
        }
    }
}
