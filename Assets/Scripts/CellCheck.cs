using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCheck : MonoBehaviour
{
    public Material nonOccupiedCookie;
    public Material occupiedCookie;

    private Material normalCellMaterial;

    private void Awake()
    {
        normalCellMaterial = GetComponent<Projector>().material;
    }

    public bool IsOccupied()
    {
        Collider collider = GetComponent<Collider>();

        foreach (Collider objectInSpace in Physics.OverlapBox(collider.bounds.center, collider.bounds.size / 2))
        {
            string tag = objectInSpace.gameObject.tag;
            Debug.Log("Object in space: " + objectInSpace.gameObject.name + " tag: " + tag);
            if (tag == "Player" || tag == "NPC" || tag == "Monster" || tag == "Wall")
                return true;
        }
        return false;
    }

    public void HighlightOccupied()
    {
        Projector projector = GetComponent<Projector>();

        projector.material = occupiedCookie;
        SetHighlight(true);
    }

    public void HighlightNonOccupied()
    {
        Projector projector = GetComponent<Projector>();

        projector.material = nonOccupiedCookie;
        SetHighlight(true);
    }

    private void OnMouseExit()
    {
        GetComponent<Projector>().material = normalCellMaterial;
        SetHighlight(false);
    }

    public void SetHighlight(bool activate)
    {
        Transform highlighter = transform.Find("Highlighter");
        highlighter.gameObject.SetActive(activate);
    }
}
