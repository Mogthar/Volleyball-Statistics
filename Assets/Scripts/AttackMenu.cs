using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackMenu : GameMenu
{
    [SerializeField] AttackQualityPopUp attackPopUp;
    [SerializeField] private TMP_Text defenceScoreText;
    [SerializeField] private TMP_Text blockScoreText;
    [SerializeField] private TMP_Text positionNameText;

    private AttackPosition _activeAttackPosition = AttackPosition.NULL;
    private string _activeAttackPositionName = "Total";

    void Start()
    {
        ClosePopUp();
    }

    public override void UpdateGraphics(){
        int[] defenceScore = GameManager.Session.attackData.CalculateDefenceScore(_activeAttackPosition);
        int[] blockScore = GameManager.Session.attackData.CalculateBlockingScore(_activeAttackPosition);
        defenceScoreText.text = defenceScore[1] + " | " + defenceScore[0];
        blockScoreText.text = blockScore[1] + " | " + blockScore[0];
        positionNameText.text = _activeAttackPositionName;
    }

    public override void OnSuccesfullArrowDrag(Vector3 arrowPosition, AttackPosition attackPosition){
        attackPopUp.currentMarkerPosition = arrowPosition;
        attackPopUp.currentAttackPosition = attackPosition;
        attackPopUp.gameObject.SetActive(true);
    }

    public override void OnAttackButtonClick(AttackPosition attackPosition, string positionName){
        if(_activeAttackPosition == attackPosition){
            _activeAttackPosition = AttackPosition.NULL;
            _activeAttackPositionName = "Total";
            GameManager.Session.attackData.ShowAllAttackHitMarks();
        } else {
            _activeAttackPosition = attackPosition;
            _activeAttackPositionName = positionName;
            GameManager.Session.attackData.ShowSpecificAttackHitMarks(attackPosition);
        }
        UpdateGraphics();
    }

    public void Undo(){
        GameManager.Session.attackData.UndoLastCommand();
    }

    public void OnBack(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.sessionMenu);
    }

    public void ClosePopUp(){
        attackPopUp.gameObject.SetActive(false);
    }

    public override void OnTransitionOut(){
        ClosePopUp();
    }

    public override void OnTransitionIn(){
        UpdateGraphics();
    }
}
