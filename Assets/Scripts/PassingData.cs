using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingData : DataModule
{
    private Dictionary<int, List<GameObject>> _hitMarkCollection;

    public PassingData(GameObject hitMarkPrefab) : base(hitMarkPrefab) {
        _hitMarkCollection = new Dictionary<int, List<GameObject>>();
    }

    // might make this method of the parent class but would need to fix the fact that the parents for hit marks are datamodule specific

    public void CreateHitMark(Vector3 markPosition, int score){
        CreateHitMarkCommand command = new CreateHitMarkCommand(markPosition, score, _hitMarkPrefab, GameManager.UI.passingMenu.hitMarkParent);
        command.Execute();
        _commandList.Add(command);

        // refresh graphics of passing
        // add data to Dictation
        //fix issue with Null reference
    }

}
