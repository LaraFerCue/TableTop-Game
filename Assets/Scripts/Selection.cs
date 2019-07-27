using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Selection : MonoBehaviour
    {
        private GameObject selected = null;
        private Vector3 direction;
        private Vector3 destination;

        private void DeactivateProjectors()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                Transform projector = player.transform.Find("Projector");
                projector.gameObject.SetActive(false);
            }
        }

        public void SelectPlayer(Transform target)
        {
            DeactivateProjectors();
            if (target.gameObject != selected)
            {
                selected = target.gameObject;

                Transform projector = target.Find("Projector");
                projector.gameObject.SetActive(true);
                destination = target.position;
                direction = destination;
            }
            else
            {
                selected = null;
            }
        }

        public void MoveSelectedPlayer(Vector3 point)
        {
            if (selected == null)
                return;

            Movement movement = selected.GetComponent<Movement>();
            movement.Destination = point;
        }

        public void SetLookDirectionToSelectedPlayer(Vector3 point)
        {
            if (selected == null)
                return;

            Movement movement = selected.GetComponent<Movement>();
            movement.Direction = point;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseSelection();
            }
            if (Input.GetMouseButtonUp(0))
            {
                MouseAction();
            }
        }
        
        private void MouseAction()
        {
            MoveSelectedPlayer(destination);
            SetLookDirectionToSelectedPlayer(direction);
        }

        private void MouseSelection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    SelectPlayer(hit.transform);
                }
                else if (hit.transform.tag == "Floor")
                {
                    destination = hit.point;
                }
            }
        }
    }
}