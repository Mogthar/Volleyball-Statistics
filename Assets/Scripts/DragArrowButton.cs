using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragArrowButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] private GameObject dragIndicatorPrefab;
    private GameObject _dragIndicator;
    private RectTransform _indicatorRectTransform;
    private float _indicatorHeight;

    [SerializeField] private GameMenu parentMenu;
    [SerializeField] private AttackPosition _attackPosition;

    public void OnPointerClick(PointerEventData data){
        if(!data.dragging){
            GraphicRaycaster canvasRaycaster = GameManager.UI.appCanvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> raycastHitList = new List<RaycastResult>();
            canvasRaycaster.Raycast(data, raycastHitList);
            foreach(RaycastResult raycastHit in raycastHitList){
                if(raycastHit.gameObject == this.gameObject)
                {
                    parentMenu.OnAttackButtonClick(_attackPosition);
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Vector3 pointerPosition = data.position;
        Vector3 indicatorPosition = (pointerPosition + transform.position) / 2;
        Vector3 indicatorDirection = pointerPosition - transform.position;
        Quaternion indicatorRotation = Quaternion.FromToRotation(Vector3.right, indicatorDirection);
        _dragIndicator = Instantiate(dragIndicatorPrefab, indicatorPosition, indicatorRotation, transform);

        _indicatorRectTransform = _dragIndicator.GetComponent<RectTransform>();
        _indicatorHeight = _indicatorRectTransform.sizeDelta.y;

        float indicatorLength = indicatorDirection.magnitude;
        _indicatorRectTransform.sizeDelta = new Vector2(indicatorLength, _indicatorHeight);
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            Vector3 pointerPosition = data.position;
            Vector3 indicatorPosition = (pointerPosition + transform.position) / 2;
            Vector3 indicatorDirection = pointerPosition - transform.position;
            _dragIndicator.transform.position = indicatorPosition;

            Quaternion indicatorRotation = Quaternion.FromToRotation(Vector3.right, indicatorDirection);
            _dragIndicator.transform.rotation = indicatorRotation;

            float indicatorLength = indicatorDirection.magnitude;
            _indicatorRectTransform.sizeDelta = new Vector2(indicatorLength, _indicatorHeight);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        Destroy(_dragIndicator);

        GraphicRaycaster canvasRaycaster = GameManager.UI.appCanvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> raycastHitList = new List<RaycastResult>();
        canvasRaycaster.Raycast(data, raycastHitList);
        foreach(RaycastResult raycastHit in raycastHitList){
            if(raycastHit.gameObject.TryGetComponent(out Court court))
            {
                Debug.Log("You hit the court");
                parentMenu.OnSuccesfullArrowDrag(data.position, _attackPosition);
            }
        }
    }
}
