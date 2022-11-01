using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public MainMenu mainMenu; // {get; private set;}
    public SessionMenu sessionMenu;
    public PassingMenu passingMenu;
    public AttackMenu attackMenu;
    public DefenceMenu defenceMenu;
    public ServingMenu servingMenu;

    public Canvas appCanvas;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.gameObject.SetActive(true);

        sessionMenu.gameObject.SetActive(false);
        passingMenu.gameObject.SetActive(false);
        attackMenu.gameObject.SetActive(false);
        defenceMenu.gameObject.SetActive(false);
        servingMenu.gameObject.SetActive(false);
    }

    // create a method that goes through a list of menu objects (need to define a parent menu and have the rest inherit)
    // and that disables all but main menu?

    // need to make a generic menu object and have all the menus inherit
    public void TransitionBetweenMenus(GameMenu previousMenu, GameMenu nextMenu){
        previousMenu.OnTransitionOut();
        previousMenu.gameObject.SetActive(false);

        nextMenu.gameObject.SetActive(true);
        nextMenu.OnTransitionIn();
    }
}
