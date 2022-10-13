using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceQualityPopUp : MonoBehaviour
{
    public Vector3 currentMarkerPosition;

    public void OnCancel(){
        GameManager.UI.defenceMenu.ClosePopUp();
    }

    // needs change and some enum
    public void OnPassingScoreEntry(int passingScore){
        GameManager.Session.defenceData.CreateHitMark(currentMarkerPosition, passingScore);
        GameManager.UI.defenceMenu.ClosePopUp();
    }
}
