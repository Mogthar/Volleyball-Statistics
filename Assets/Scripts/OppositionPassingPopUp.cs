using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositionPassingPopUp : MonoBehaviour
{
    public Vector3 currentMarkerPosition;
    public AttackPosition currentAttackPosition;

    public void OnPassingScoreEntry(int passingScore){
        GameManager.Session.servingData.CreateHitMark(currentMarkerPosition, passingScore);
        GameManager.UI.servingMenu.ClosePopUp();
    }

    public void OnServiceError(){
        GameManager.Session.servingData.LogServiceError();
        GameManager.UI.servingMenu.ClosePopUp();
    }

    public void OnCancel(){
        GameManager.UI.servingMenu.ClosePopUp();
    }

}
