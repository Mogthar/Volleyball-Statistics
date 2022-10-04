using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PassingMenu : GameMenu
{
    [SerializeField] PassingQualityPopUp passingPopUp;
    public GameObject hitMarkParent;

    private List<Command> _commandList;
    // Start is called before the first frame update
    void Start()
    {
        passingPopUp.gameObject.SetActive(false);
        _commandList = new List<Command>();
    }

    public void UpdateGraphics(){

    }

    public override void OnSuccesfullArrowDrag(Vector3 arrowPosition){
        passingPopUp.currentMarkerPosition = arrowPosition;
        passingPopUp.gameObject.SetActive(true);
    }

    public void Undo(){
        GameManager.Session.passingData.UndoLastCommand();
    }

    public void ClosePopUp(){
        passingPopUp.gameObject.SetActive(false);
    }


    public override void OnTransitionOut(){

    }

    public override void OnTransitionIn(){

    }
}
