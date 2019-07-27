using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Selection : MonoBehaviour
    {
        private GameObject selected = null;

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
            }
            else
            {
                selected = null;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Player")
                    {
                        SelectPlayer(hit.transform);
                    }
                    else if (hit.transform.tag == "Floor" && selected)
                    {
                        Movement movement = selected.GetComponent<Movement>();
                        movement.Destination = hit.point;
                    }
                }
            }
        }
    }
}