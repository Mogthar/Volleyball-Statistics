using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassingMenu : GameMenu
{
    [SerializeField] PassingQualityPopUp passingPopUp;
    [SerializeField] private TMP_Text averageScoreText;
    [SerializeField] private Slider[] graphColumns;
    [SerializeField] private TMP_Text[] graphColumnPercentages;

    public GameObject hitMarkParent;
    // Start is called before the first frame update
    void Start()
    {
        passingPopUp.gameObject.SetActive(false);
    }

    public override void UpdateGraphics(){
        UpdateGraphColumns();
        UpdateAverageScoreText();
    }

    void UpdateAverageScoreText()
    {
        averageScoreText.text = "Avg score: " + GameManager.Session.passingData.CalculateAverageScore().ToString("0.00");
    }

    void UpdateGraphColumns()
    {
        float[] passingPercentages = GameManager.Session.passingData.CalculatePassingPercentages(graphColumns.Length);
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
