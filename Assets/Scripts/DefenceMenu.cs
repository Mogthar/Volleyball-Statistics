using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenceMenu : GameMenu
{
    [SerializeField] DefenceQualityPopUp defencePopUp;
    [SerializeField] private TMP_Text defenceScoreText;
    [SerializeField] private TMP_Text blockScoreText;

    public GameObject hitMarkParent;

    private AttackPosition _activeAttackPosition = AttackPosition.NULL;

    void Start()
    {
        ClosePopUp();
    }

    public override void UpdateGraphics(){
        int[] defenceScore = GameManager.Session.defenceData.CalculateDefenceScore(_activeAttackPosition);
        int[] blockScore = GameManager.Session.defenceData.CalculateBlockingScore(_activeAttackPosition);
    }

    public override void OnSuccesfullArrowDrag(Vector3 arrowPosition, AttackPosition attackPosition){
        defencePopUp.currentMarkerPosition = arrowPosition;
        defencePopUp.currentAttackPosition = attackPosition;
        defencePopUp.gameObject.SetActive(true);
    }

    public override void OnAttackButtonClick(AttackPosition attackPosition){
        if(_activeAttackPosition == attackPosition){
            _activeAttackPosition = AttackPosition.NULL;
            GameManager.Session.defenceData.ShowAllAttackHitMarks();
        } else {
            _activeAttackPosition = attackPosition;
            GameManager.Session.defenceData.ShowSpecificAttackHitMarks(attackPosition);
        }
        UpdateGraphics();
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
