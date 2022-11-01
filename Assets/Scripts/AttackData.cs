using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : DefenceData
{
    public AttackData(GameObject hitMarkPrefab, GameMenu sisterMenu) : base(hitMarkPrefab, sisterMenu) {
      _defenceScore = new Dictionary<int, int[]>();
      _blockingScore = new Dictionary<int, int[]>();
    }

    public override Color ScoreToColourConversion(int hitMarkScore){
        switch(hitMarkScore){
            default:
                return new Color(1.0f, 0.0f, 0.0f);
            case 0:
                return new Color(0.0f, 1.0f, 0.0f);
            case 1:
                return new Color(1.0f, 0.0f, 0.0f);
        }
    }
}
