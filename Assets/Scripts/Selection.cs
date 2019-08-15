using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Selection : MonoBehaviour
    {
        private GameObject selected = null;
        private Vector3 direction;
        private Vector3 destination;
        private bool setDestinationAndDirection = false;

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
                MouseSelection();
            if (Input.GetMouseButton(0))
                FloorChecker();
            if (Input.GetMouseButtonUp(0))
                MouseAction();
        }
        
        private Transform GetObjectUnderCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                return hit.transform;
            return null;
        }

        private void MouseAction()
        {
            if (!setDestinationAndDirection)
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                direction = hit.point;
            }
            //MoveSelectedPlayer(destination);
            //SetLookDirectionToSelectedPlayer(direction);
            setDestinationAndDirection = false;
        }

        private void FloorChecker()
        {
            Transform hittedObject = GetObjectUnderCursor();

            if (hittedObject != null && hittedObject.tag == "Floor")
            {
                setDestinationAndDirection = true;
                destination = hittedObject.position;

                CellCheck cellCheck = hittedObject.gameObject.GetComponent<CellCheck>();
                if (cellCheck != null)
                {
                    if (cellCheck.IsOccupied())
                        cellCheck.HighlightOccupied();
                    else
                        cellCheck.HighlightNonOccupied();
                }
            }
        }

        private void MouseSelection()
        {
            Transform hittedObject = GetObjectUnderCursor();
            if (hittedObject != null && hittedObject.tag == "Player")
            {
                SelectPlayer(hittedObject);
            }
        }
    }
}