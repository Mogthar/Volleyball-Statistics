using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PassingMenu : GameMenu
{
    [SerializeField] PassingQualityPopUp passingPopUp;
    public GameObject hitMarkPrefab;

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

    public void CreateHitMark(Vector3 markPosition, int score){
        CreateHitMarkCommand command = new CreateHitMarkCommand(markPosition, score, hitMarkPrefab, this);
        command.Execute();
        _commandList.Add(command);

        // need to add a bit that keeps track of score but also of hit marks so that they can be loaded
        // should this be in the data module??
        // Need to update graphics
    }

    public void UndoLastCommand(){
        if(_commandList.Count > 0){
            // need to update graphics

            _commandList.Last().Undo();
            // Does this fully remove the command object? I guess yes since the only reference it ceases to exist
            _commandList.RemoveAt(_commandList.Count - 1);
        }
    }

    public void ClosePopUp(){
        passingPopUp.gameObject.SetActive(false);
    }


    public override void OnTransitionOut(){

    }

    public override void OnTransitionIn(){

    }
}
