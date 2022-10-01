using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingMenu : GameMenu
{
    [SerializeField] PassingQualityPopUp passingPopUp;
    // Start is called before the first frame update
    void Start()
    {
        passingPopUp.gameObject.SetActive(false);
    }

    public void UpdateGraphics(){

    }


    public override void OnTransitionOut(){

    }

    public override void OnTransitionIn(){

    }
}
