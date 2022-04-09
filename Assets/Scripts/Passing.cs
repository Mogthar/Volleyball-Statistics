using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Passing : MonoBehaviour
{
    [SerializeField] GameObject[] scoringButtons;
    [SerializeField] GameObject returnButton;
    [SerializeField] GameObject undoButton;
    [SerializeField] TextMeshProUGUI averageScoreText;
    [SerializeField] TextMeshProUGUI[] graphColumnPercentages;
    [SerializeField] Slider[] graphColumns;
    Scorer scorer;
    private List<LogPassCommand> commandList = new List<LogPassCommand>();

    public class LogPassCommand
    {
        private int scoreToLog;
        private Passing parentPassing;
        private Scorer gameScorer;
        public LogPassCommand(int scoreInput, Passing parent, Scorer gameScorerInstance)
        {
            gameScorer = gameScorerInstance;
            scoreToLog = scoreInput;
            parentPassing = parent;
        }
        public void Execute()
        {
            if(parentPassing == null)
            {
                return;
            }
            else
            {
                gameScorer.LogPass(scoreToLog);
                parentPassing.UpdateGraphics();
            }
        }
        public void Undo()
        {
            if(parentPassing == null)
            {
                return;
            }
            else
            {
                gameScorer.RemovePass(scoreToLog);
                parentPassing.UpdateGraphics();
            }
        }
    }
    // implement a command class for undo functiionality
    // in the class store a reference to the scorer and maybe to the parent class ? all should be good

    void Awake() 
    {
        scorer = FindObjectOfType<Scorer>();
    }
    
    public void OnScoreButtonPressed(int score)
    {
        LogPassCommand command = new LogPassCommand(score, this, scorer);
        commandList.Add(command);
        command.Execute();
        // old code
        /*
        scorer.LogPass(score);
        UpdateGraphics();
        */
    }

    void UpdateAverageScoreText()
    {
        averageScoreText.text = "Avg score: " + scorer.CalculateAverageScore().ToString("0.00");
    }

    void UpdateGraphColumns()
    {
        float[] passingPercentages = scorer.CalculatePassingPercentages();
        float maxPercentage = 0.0f;
        // find the max percentage
        for(int i = 0; i < 4; i++)
        {
            if(passingPercentages[i] > maxPercentage)
            {
                maxPercentage = passingPercentages[i];
            }
        }

        for(int i = 0; i < 4; i++)
        {
            graphColumnPercentages[i].text = (100 * passingPercentages[i]).ToString("0.0") + "%";
            // this scales the columns so that the max one is filled all the way to the top irrespective of the percentage
            if(maxPercentage > 0.0f)
            {
                graphColumns[i].value = passingPercentages[i] / maxPercentage;
            }
            else
            {
                graphColumns[i].value = passingPercentages[i];
            }
        }
    }

    public void UpdateGraphics()
    {
        UpdateGraphColumns();
        UpdateAverageScoreText();
    }

    public void OnUndoButtonPress()
    {
        UndoLastCommand();
    }

    private void UndoLastCommand()
    {
        int numberOfCommands = commandList.Count;
        if(numberOfCommands > 0)
        {
            LogPassCommand lastCommand = commandList[numberOfCommands-1];
            commandList.RemoveAt(numberOfCommands - 1);
            lastCommand.Undo();
            // potentially set last command to null if need be
        }
    }
    public void ResetPassing()
    {
        
    }
}
