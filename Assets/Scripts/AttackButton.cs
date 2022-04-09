using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    LineRenderer myLineRenderer;
    Vector3 offsetVector;
    Defence defence;
    void Start()
    {
        defence = FindObjectOfType<Defence>();
        myLineRenderer = GetComponent<LineRenderer>();
        myLineRenderer.enabled = false;
        offsetVector = new Vector3 (0f, 0f, Camera.main.transform.position.z);
    }

    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData data)
    {
        // Should the mouseWorldPosition be defined as a property of the class rather than a variable that gets defined over and over again each frame?
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(data.position);
        myLineRenderer.SetPosition(0, transform.position);
        myLineRenderer.SetPosition(1, mouseWorldPosition - offsetVector);
        myLineRenderer.enabled = true;
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(data.position);
            myLineRenderer.SetPosition(1, mouseWorldPosition - offsetVector);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(data.position);
        myLineRenderer.enabled = false;
        defence.CreateHitMark(mouseWorldPosition - offsetVector, this.gameObject);
    }

}
