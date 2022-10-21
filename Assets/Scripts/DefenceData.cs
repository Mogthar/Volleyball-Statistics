using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceData : DataModule
{
  private Dictionary<int, int[]> _defenceScore;
  private Dictionary<int, int[]> _blockingScore;

  public DefenceData(GameObject hitMarkPrefab, GameMenu sisterMenu) : base(hitMarkPrefab, sisterMenu) {
    _defenceScore = new Dictionary<int, int[]>();
    _blockingScore = new Dictionary<int, int[]>();
  }

  public void CreateDefenceHitMark(Vector3 markPosition, int score, AttackPosition attackPosition){
      CreateDefenceHitMarkCommand command = new CreateDefenceHitMarkCommand(markPosition, score, _hitMarkPrefab, GameManager.UI.defenceMenu.hitMarkParent, this, attackPosition);
      command.Execute();
      _commandList.Add(command);

      GameManager.UI.defenceMenu.UpdateGraphics();
  }

  public void LogBlockingEvent(int score, AttackPosition attackPosition){
      LogBlockingScoreCommand command = new LogBlockingScoreCommand(score, attackPosition, this);
      command.Execute();
      _commandList.Add(command);

      GameManager.UI.defenceMenu.UpdateGraphics();
  }

  public void AddBlockingScore(int score, AttackPosition attackPosition){
      int attackPositionLabel = (int) attackPosition;
      if(_blockingScore.ContainsKey(attackPositionLabel)){
          _blockingScore[attackPositionLabel][0] += score;
          _blockingScore[attackPositionLabel][0] += 1;
      }
      else{
          _blockingScore.Add(attackPositionLabel, new int[2]);
          _blockingScore[attackPositionLabel][0] += score;
          _blockingScore[attackPositionLabel][0] += 1;
      }
  }

  public void RemoveBlockingScore(int score, AttackPosition attackPosition){
      int attackPositionLabel = (int) attackPosition;
      _blockingScore[attackPositionLabel][0] -= score;
      _blockingScore[attackPositionLabel][0] -= 1;
  }

  public void AddDefenceScore(AttackPosition attackPosition, int score){
      int attackPositionLabel = (int) attackPosition;
      if(_defenceScore.ContainsKey(attackPositionLabel)){
          _defenceScore[attackPositionLabel][0] += score;
          _defenceScore[attackPositionLabel][0] += 1;
      }
      else{
          _defenceScore.Add(attackPositionLabel, new int[2]);
          _defenceScore[attackPositionLabel][0] += score;
          _defenceScore[attackPositionLabel][0] += 1;
      }
  }

  public void RemoveDefenceScore(AttackPosition attackPosition, int score){
      int attackPositionLabel = (int) attackPosition;
      _defenceScore[attackPositionLabel][0] -= score;
      _defenceScore[attackPositionLabel][0] -= 1;
  }

  public override Color ScoreToColourConversion(int hitMarkScore){
      switch(hitMarkScore){
          default:
              return new Color(1.0f, 0.0f, 0.0f);
          case 0:
              return new Color(1.0f, 0.0f, 0.0f);
          case 1:
              return new Color(0.0f, 1.0f, 0.0f);
      }
  }
}
