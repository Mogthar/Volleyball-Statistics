using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingData : DataModule
{
    private int _servingErrors;
    public ServingData(GameObject hitMarkPrefab, GameMenu sisterMenu) : base(hitMarkPrefab, sisterMenu) {
        _servingErrors = 0;
    }

    // might make this method of the parent class but would need to fix the fact that the parents for hit marks are datamodule specific

    public void CreateHitMark(Vector3 markPosition, int score){
        CreateHitMarkCommand command = new CreateHitMarkCommand(markPosition, score, _hitMarkPrefab, GameManager.UI.servingMenu.hitMarkParent, this);
        command.Execute();
        _commandList.Add(command);

        // change this to sister menu!
        _sisterMenu.UpdateGraphics();
    }

    public void LogServiceError(){
        LogServiceErrorCommand command = new LogServiceErrorCommand(this);
        command.Execute();
        _commandList.Add(command);

        _sisterMenu.UpdateGraphics();
    }

    public void AddServiceError(){
        _servingErrors += 1;
    }

    public void RemoveServiceError(){
        _servingErrors -= 1;
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

    public float[] CalculatePassingPercentages(int numDistinctScoreValues){
        float[] passingPercentages = new float[numDistinctScoreValues];
        int totalNumberOfPasses = CalculateTotalNumberOfPasses();

        for(int scoreValue = 0; scoreValue < numDistinctScoreValues; scoreValue++){
            int numPassesPerScore = 0;
            // check if i is a key in _hitMarkCollection
            if(_hitMarkCollection.ContainsKey(scoreValue)){
                numPassesPerScore = _hitMarkCollection[scoreValue].Count;
            }
            if(totalNumberOfPasses > 0){
                passingPercentages[scoreValue] = (float)numPassesPerScore / totalNumberOfPasses;
            } else {
                passingPercentages[scoreValue] = 0.0f;
            }

        }
        return passingPercentages;
    }

    public int CalculateTotalNumberOfPasses(){
        int numberOfPasses = 0;
        foreach(int score in _hitMarkCollection.Keys){
            numberOfPasses += _hitMarkCollection[score].Count;
        }
        return numberOfPasses;
    }

    public int CalculateTotalNumberOfServes(){
        int totalServes = 0;
        int totalPasses = CalculateTotalNumberOfPasses();
        totalServes = totalPasses + _servingErrors;
        return totalServes;
    }

    public float CalculateServingErrorPercentage(){
        float errorPercentage = 0.0f;
        int totalServes = CalculateTotalNumberOfServes();
        if(totalServes > 0){
            errorPercentage = (float) _servingErrors / totalServes;
        }
        return errorPercentage;
    }

    public override Color ScoreToColourConversion(int hitMarkScore){
        switch(hitMarkScore){
            default:
                return new Color(1.0f, 0.0f, 0.0f);
            case 0:
                return new Color(0.0f, 0.0f, 0.0f);
            case 1:
                return new Color(1.0f, 0.0f, 0.0f);
            case 2:
                return new Color(1.0f, 1.0f, 0.0f);
            case 3:
                return new Color(0.0f, 1.0f, 0.0f);
        }
    }

}
