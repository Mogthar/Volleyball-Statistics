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

  public void ShowSpecificAttackHitMarks(AttackPosition attackPosition){
      int attackPositionLabel = (int) attackPosition;
      if(_hitMarkCollection.ContainsKey(attackPositionLabel)){
          foreach(int key in _hitMarkCollection.Keys){
              for(int i = 0; i < _hitMarkCollection[key].Count; i++){
                  if(key == attackPositionLabel){
                      _hitMarkCollection[key][i].SetActive(true);
                  } else {
                      _hitMarkCollection[key][i].SetActive(false);
                  }
              }
          }
      }
  }

  public void ShowAllAttackHitMarks(){
      foreach(int key in _hitMarkCollection.Keys){
          for(int i = 0; i < _hitMarkCollection[key].Count; i++){
              _hitMarkCollection[key][i].SetActive(true);
          }
      }
  }

  public void RemoveDefenceScore(AttackPosition attackPosition, int score){
      int attackPositionLabel = (int) attackPosition;
      _defenceScore[attackPositionLabel][0] -= score;
      _defenceScore[attackPositionLabel][0] -= 1;
  }

  public int[] CalculateDefenceScore(AttackPosition attackPosition){
      int[] defenceScore = new int[2];

      if(attackPosition == AttackPosition.NULL){
          int totalSuccessfullDefence = 0;
          int totalFailedDefence = 0;
          foreach(int key in _defenceScore.Keys){
              totalSuccessfullDefence += _defenceScore[key][0];
              totalFailedDefence += _defenceScore[key][1] - _defenceScore[key][0];
          }
          defenceScore[0] = totalSuccessfullDefence;
          defenceScore[1] = totalFailedDefence;
      }

      return defenceScore;
  }

  public int[] CalculateBlockingScore(AttackPosition attackPosition){
    int[] blockingScore = new int[2];
    return blockingScore;
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
