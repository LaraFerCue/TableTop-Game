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
                player.transform.Find("Projector").gameObject.SetActive(false);
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
                        DeactivateProjectors();
                        if (hit.transform.gameObject != selected)
                        {
                            selected = hit.transform.gameObject;

                            Transform projector = hit.transform.Find("Projector");
                            projector.gameObject.SetActive(true);
                        } else
                        {
                            selected = null;
                        }
                    }
                    else if (hit.transform.tag == "Floor" && selected)
                    {
                        Movement movement = selected.GetComponent<Movement>();
                        movement.SetDestination(hit.point);
                    }
                }
            }
        }
    }
}