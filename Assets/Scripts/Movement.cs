using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Movement: MonoBehaviour
    {
        public float speed = 0.0f;
        private Vector3 destination;
        private Quaternion direction;
        private bool isRotating = false;
        private bool isMoving = false;
        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
        }

        public bool IsRotating
        {
            get
            {
                return isRotating;
            }
        }

        public Vector3 Destination
        {
            get
            {
                return destination;
            }
        }

        public Quaternion Direction
        {
            get
            {
                return direction;
            }
        }
        public void Rotate(Vector3 direction)
        {
            this.direction = Quaternion.LookRotation(direction);
            isRotating = true;
        }

        public void SetDestination(Vector3 destination)
        {
            this.destination = new Vector3(destination.x, transform.position.y, destination.z);
            isMoving = true;
            Rotate(destination);
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

            if (isRotating)
            {
                Debug.Log("Rotating -> Rotation: " + transform.rotation + " direction: " + direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, direction, Time.deltaTime * speed);

                if (Quaternion.Dot(transform.rotation, direction) > 0.9f)
                    isRotating = false;
            }
        }
    }
}
