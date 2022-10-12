using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceMenu : GameMenu
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBack(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.sessionMenu);
    }
}
