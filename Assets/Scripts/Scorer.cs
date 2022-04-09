using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    // passing score
    int[] totalPasses = new int[] {0,0,0,0};
    
    void Start()
    {
        
    }

    public void LogPass(int score)
    {
        totalPasses[score] += 1;
    }

    public void RemovePass(int score)
    {
        totalPasses[score] -= 1;
    }

    int CalculateTotalNumberOfPasses()
    {
        int sum = 0;
        for(int i = 0; i < 4; i++)
        {
            sum += totalPasses[i];
        }
        return sum;
    }
    

    public float[] CalculatePassingPercentages()
    {
        float[] passingPercentages = new float[] {0f,0f,0f,0f};
        int totalNumberOfPasses = CalculateTotalNumberOfPasses();
        for(int i = 0; i < 4; i++)
        {
            if(totalNumberOfPasses != 0)
            {
                passingPercentages[i] = (float) totalPasses[i] / totalNumberOfPasses;
            }
            else
            {
                passingPercentages[i] = 0.0f;
            }
             
        }
        return passingPercentages;
    }

    int CalculateTotalPassingScore()
    {
        int sum = 0;
        for(int i = 0; i < 4; i++)
        {
            sum += i * totalPasses[i];
        }
        return sum;
    }

    public float CalculateAverageScore()
    {
        if(CalculateTotalNumberOfPasses() != 0)
        {
            return (float)CalculateTotalPassingScore() / CalculateTotalNumberOfPasses();
        }
        else
        {
            return 0.0f;
        }
    }

    public void ResetScorer()
    {
        totalPasses = new int[] {0,0,0,0};
    }

}

// potentially merge scorer into the passing canvas because it is obsolete
