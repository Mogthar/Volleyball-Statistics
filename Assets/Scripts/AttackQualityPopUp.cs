using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackQualityPopUp : MonoBehaviour
{
    public Vector3 currentMarkerPosition;
    public AttackPosition currentAttackPosition;

    public void OnCancel(){
        GameManager.UI.attackMenu.ClosePopUp();
    }

    // needs change and some enum
    public void OnSuccessfullAttack(int defenceScore){
        GameManager.Session.attackData.CreateDefenceHitMark(currentMarkerPosition, defenceScore, currentAttackPosition);
        GameManager.UI.attackMenu.ClosePopUp();
    }

    public void OnBlock(int blockScore){
        GameManager.Session.attackData.LogBlockingEvent(blockScore, currentAttackPosition);
        GameManager.UI.attackMenu.ClosePopUp();
    }
}
