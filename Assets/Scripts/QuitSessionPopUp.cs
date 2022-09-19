using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSessionPopUp : MonoBehaviour
{

    public void OnQuitSessionWithoutSaving()
    {
        GameManager.UI.TransitionBetweenMenus(GameManager.UI.sessionMenu, GameManager.UI.mainMenu);
    }

    public void OnQuitSessionWithSaving()
    {
        GameManager.Session.SaveCurrentSession();
        GameManager.UI.TransitionBetweenMenus(GameManager.UI.sessionMenu, GameManager.UI.mainMenu);
    }

    public void OnCancelQuitting(){
        GameManager.UI.sessionMenu.ClosePopUp();
    }
}
