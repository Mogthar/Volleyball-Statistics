using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingData : DataModule
{
    public PassingData(GameObject hitMarkPrefab, GameMenu sisterMenu) : base(hitMarkPrefab, sisterMenu) {}

    // might make this method of the parent class but would need to fix the fact that the parents for hit marks are datamodule specific

    public void CreateHitMark(Vector3 markPosition, int score){
        CreateHitMarkCommand command = new CreateHitMarkCommand(markPosition, score, _hitMarkPrefab, GameManager.UI.passingMenu.hitMarkParent, this);
        command.Execute();
        _commandList.Add(command);

        GameManager.UI.passingMenu.UpdateGraphics();
    }

    public float CalculateAverageScore(){
        int totalScore = 0;
        int numberOfPasses = CalculateTotalNumberOfPasses();

        foreach(int score in _hitMarkCollection.Keys){
            totalScore += _hitMarkCollection[score].Count * score;
        }

        if(numberOfPasses > 0){
            return (float)totalScore / numberOfPasses;
        }
        return 0.0f;
    }

    /*
    public float[] CalculatePassingPercentages(){
        float[] passingPercentages = new float[_hitMarkCollection.Keys.Count];
        int totalNumberOfPasses = CalculateTotalNumberOfPasses();

        for(int i = 0; i < passingPercentages.Length; i++){

        }
    }
    */

    public int CalculateTotalNumberOfPasses(){
        int numberOfPasses = 0;
        foreach(int score in _hitMarkCollection.Keys){
            numberOfPasses += _hitMarkCollection[score].Count;
        }
        return numberOfPasses;
    }

}
