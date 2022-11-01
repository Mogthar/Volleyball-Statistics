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
    [SerializeField] private TMP_Text positionNameText;

    private AttackPosition _activeAttackPosition = AttackPosition.NULL;
    private string _activeAttackPositionName = "Total";

    void Start()
    {
        ClosePopUp();
    }

    public override void UpdateGraphics(){
        int[] defenceScore = GameManager.Session.defenceData.CalculateDefenceScore(_activeAttackPosition);
        int[] blockScore = GameManager.Session.defenceData.CalculateBlockingScore(_activeAttackPosition);
        defenceScoreText.text = defenceScore[0] + " | " + defenceScore[1];
        blockScoreText.text = blockScore[0] + " | " + blockScore[1];
        positionNameText.text = _activeAttackPositionName;
    }

    public override void OnSuccesfullArrowDrag(Vector3 arrowPosition, AttackPosition attackPosition){
        defencePopUp.currentMarkerPosition = arrowPosition;
        defencePopUp.currentAttackPosition = attackPosition;
        defencePopUp.gameObject.SetActive(true);
    }

    public override void OnAttackButtonClick(AttackPosition attackPosition, string positionName){
        if(_activeAttackPosition == attackPosition){
            _activeAttackPosition = AttackPosition.NULL;
            _activeAttackPositionName = "Total";
            GameManager.Session.defenceData.ShowAllAttackHitMarks();
        } else {
            _activeAttackPosition = attackPosition;
            _activeAttackPositionName = positionName;
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
