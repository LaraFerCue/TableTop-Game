using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Movement: MonoBehaviour
    {
        public float speed = 0.0f;
        public float angularSpeed = 0.0f;
        private Vector3 destination;
        private Vector3 direction;
        private bool isRotating = false;
        private bool isMoving = false;
        public bool IsMoving { get { return isMoving; } }

        public bool IsRotating { get { return isRotating; } }

        public Vector3 Destination
        {
            get { return destination; }

            set
            {
                this.destination = new Vector3(value.x, transform.position.y, value.z);
                this.isMoving = true;
            }
        }

        public Vector3 Direction
        {
            get { return direction;  }
            set
            {
                this.direction = new Vector3(value.x, transform.position.y, value.z);
                this.isRotating = true;
            }
        }

        public void MoveTorwards(float deltaTime)
        {
            if (isMoving)
            {
                transform.position = Vector3.Lerp(transform.position, destination, deltaTime * speed);

                if (Vector3.Distance(transform.position, destination) < 0.1f)
                    isMoving = false;
            }

        }

        public void LookTorwards(float deltaTime)
        {
            if (isRotating)
            {
                Vector3 direction = (this.direction - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * angularSpeed);
                isRotating = Quaternion.Angle(transform.rotation, lookRotation) > 5.0f;
            }
        }

        public void Stop()
        {
            isMoving = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Wall")
            {
                Stop();
            }
        }


        private void Update()
        {
            MoveTorwards(Time.deltaTime);
            LookTorwards(Time.deltaTime);
        }
    }
}
