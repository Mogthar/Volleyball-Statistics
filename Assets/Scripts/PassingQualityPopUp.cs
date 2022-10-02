using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingQualityPopUp : MonoBehaviour
{
    public Vector3 currentMarkerPosition;

    public void OnPassingScoreEntry(int passingScore){
        GameManager.UI.passingMenu.CreateHitMark(currentMarkerPosition, passingScore);
        GameManager.UI.passingMenu.ClosePopUp();
    }

    public void OnCancel(){
        GameManager.UI.passingMenu.ClosePopUp();
    }

}
