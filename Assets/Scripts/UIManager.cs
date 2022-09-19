using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public MainMenu mainMenu; // {get; private set;}
    public SessionMenu sessionMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.gameObject.SetActive(true);

        sessionMenu.gameObject.SetActive(false);
    }

    // create a method that goes through a list of menu objects (need to define a parent menu and have the rest inherit)
    // and that disables all but main menu?

    // figure out a better way of transitioning
    public void MainToSessionTransition(){
        mainMenu.gameObject.SetActive(false);
        sessionMenu.gameObject.SetActive(true);
    }

    // need to make a generic menu object and have all the menus inherit
    public void TransitionBetweenMenus(GameMenu previousMenu, GameMenu nextMenu){
        previousMenu.OnTransitionOut();
        previousMenu.gameObject.SetActive(false);

        nextMenu.gameObject.SetActive(true);
        nextMenu.OnTransitionIn();
    }
}
