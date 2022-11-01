using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServingMenu : GameMenu
{
    [SerializeField] OppositionPassingPopUp passingPopUp;
    [SerializeField] private TMP_Text averageScoreText;
    [SerializeField] private TMP_Text errorRateText;
    [SerializeField] private Slider[] graphColumns;
    [SerializeField] private TMP_Text[] graphColumnPercentages;

    // Start is called before the first frame update
    void Start()
    {
        ClosePopUp();
    }

    public override void UpdateGraphics(){
        UpdateGraphColumns();
        UpdateAverageScoreText();
        UpdateErrorRateText();
    }

    void UpdateAverageScoreText()
    {
        averageScoreText.text = "Avg: " + GameManager.Session.servingData.CalculateAverageScore().ToString("0.0");
    }

    void UpdateErrorRateText(){
        errorRateText.text = "Error: " + GameManager.Session.servingData.CalculateServingErrorPercentage().ToString("0.0");
    }

    void UpdateGraphColumns()
    {
        float[] passingPercentages = GameManager.Session.servingData.CalculatePassingPercentages(graphColumns.Length);
        float maxPercentage = 0.0f;
        // find the max percentage - there should be a function for that!!!
        for(int i = 0; i < graphColumns.Length; i++)
        {
            if(passingPercentages[i] > maxPercentage)
            {
                maxPercentage = passingPercentages[i];
            }
        }

        for(int i = 0; i < graphColumns.Length; i++)
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

    public override void OnSuccesfullArrowDrag(Vector3 arrowPosition, AttackPosition attackPosition){
        passingPopUp.currentMarkerPosition = arrowPosition;
        passingPopUp.currentAttackPosition = attackPosition;
        passingPopUp.gameObject.SetActive(true);
    }

    public void Undo(){
        GameManager.Session.servingData.UndoLastCommand();
    }

    public void ClosePopUp(){
        passingPopUp.gameObject.SetActive(false);
    }

    public void OnBack(){
        GameManager.UI.TransitionBetweenMenus(this, GameManager.UI.sessionMenu);
    }

    public override void OnTransitionOut(){
        ClosePopUp();
    }

    public override void OnTransitionIn(){
        UpdateGraphics();
    }
}
