using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private LineRenderer myLineRenderer;
    private Vector3 offsetVector;

    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
        myLineRenderer.enabled = false;
        offsetVector = new Vector3 (0f, 0f, Camera.main.transform.position.z);
    }

    public void OnBeginDrag(PointerEventData data)
    {
        //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(data.position);
        myLineRenderer.SetPosition(0, transform.position);
        // myLineRenderer.SetPosition(1, mouseWorldPosition - offsetVector);
        Vector3 tipPosition = new Vector3(data.position.x, data.position.y, 0.0f);
        myLineRenderer.SetPosition(1, tipPosition);
        myLineRenderer.enabled = true;
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            // Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(data.position);
            // myLineRenderer.SetPosition(1, mouseWorldPosition - offsetVector);
            Vector3 tipPosition = new Vector3(data.position.x, data.position.y, 0.0f);
            myLineRenderer.SetPosition(1, tipPosition);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(data.position);
        myLineRenderer.enabled = false;
        //defence.CreateHitMark(mouseWorldPosition - offsetVector, this.gameObject);
    }

}
