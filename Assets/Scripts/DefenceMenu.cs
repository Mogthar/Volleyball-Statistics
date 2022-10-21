using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceMenu : GameMenu
{
    [SerializeField] DefenceQualityPopUp defencePopUp;

    public GameObject hitMarkParent;

    void Start()
    {
        ClosePopUp();
    }

    public override void UpdateGraphics(){
    }

    public override void OnSuccesfullArrowDrag(Vector3 arrowPosition, AttackPosition attackPosition){
        defencePopUp.currentMarkerPosition = arrowPosition;
        defencePopUp.currentAttackPosition = attackPosition;
        defencePopUp.gameObject.SetActive(true);
    }

    public void Undo(){
        GameManager.Session.defenceData.UndoLastCommand();
    }

    public void OnBack(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.sessionMenu);
    }

    public void ClosePopUp(){
        defencePopUp.gameObject.SetActive(false);
    }

    public override void OnTransitionOut(){
        ClosePopUp();
    }

    public override void OnTransitionIn(){
        UpdateGraphics();
    }
}
