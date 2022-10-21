using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceQualityPopUp : MonoBehaviour
{
    public Vector3 currentMarkerPosition;
    public AttackPosition currentAttackPosition;

    public void OnCancel(){
        GameManager.UI.defenceMenu.ClosePopUp();
    }

    // needs change and some enum
    public void OnSuccessfullAttack(int defenceScore){
        GameManager.Session.defenceData.CreateDefenceHitMark(currentMarkerPosition, defenceScore, currentAttackPosition);
        GameManager.UI.defenceMenu.ClosePopUp();
    }

    public void OnBlock(int blockScore){
        GameManager.Session.defenceData.LogBlockingEvent(blockScore, currentAttackPosition);
        GameManager.UI.defenceMenu.ClosePopUp();
    }
}
