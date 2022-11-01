using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceData : DataModule
{
  protected Dictionary<int, int[]> _defenceScore;
  protected Dictionary<int, int[]> _blockingScore;

  public DefenceData(GameObject hitMarkPrefab, GameMenu sisterMenu) : base(hitMarkPrefab, sisterMenu) {
    _defenceScore = new Dictionary<int, int[]>();
    _blockingScore = new Dictionary<int, int[]>();
  }

  public void CreateDefenceHitMark(Vector3 markPosition, int score, AttackPosition attackPosition){
      CreateDefenceHitMarkCommand command = new CreateDefenceHitMarkCommand(markPosition, score, _hitMarkPrefab, _sisterMenu.hitMarkParent, this, attackPosition);
      command.Execute();
      _commandList.Add(command);

      _sisterMenu.UpdateGraphics();
  }

  public void LogBlockingEvent(int score, AttackPosition attackPosition){
      LogBlockingScoreCommand command = new LogBlockingScoreCommand(score, attackPosition, this);
      command.Execute();
      _commandList.Add(command);

      _sisterMenu.UpdateGraphics();
  }

  public void AddBlockingScore(int score, AttackPosition attackPosition){
      int attackPositionLabel = (int) attackPosition;
      if(_blockingScore.ContainsKey(attackPositionLabel)){
          _blockingScore[attackPositionLabel][0] += score;
          _blockingScore[attackPositionLabel][1] += 1;
      }
      else{
          _blockingScore.Add(attackPositionLabel, new int[2]);
          _blockingScore[attackPositionLabel][0] += score;
          _blockingScore[attackPositionLabel][1] += 1;
      }
  }

  public void RemoveBlockingScore(int score, AttackPosition attackPosition){
      int attackPositionLabel = (int) attackPosition;
      _blockingScore[attackPositionLabel][0] -= score;
      _blockingScore[attackPositionLabel][1] -= 1;
  }

  public void AddDefenceScore(AttackPosition attackPosition, int score){
      int attackPositionLabel = (int) attackPosition;
      if(_defenceScore.ContainsKey(attackPositionLabel)){
          _defenceScore[attackPositionLabel][0] += score;
          _defenceScore[attackPositionLabel][1] += 1;
      }
      else{
          _defenceScore.Add(attackPositionLabel, new int[2]);
          _defenceScore[attackPositionLabel][0] += score;
          _defenceScore[attackPositionLabel][1] += 1;
      }
  }

  public void ShowSpecificAttackHitMarks(AttackPosition attackPosition){
      int attackPositionLabel = (int) attackPosition;
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
      _defenceScore[attackPositionLabel][1] -= 1;
  }

  // returns an array int[]{num passes, num fails}
  public int[] CalculateDefenceScore(AttackPosition attackPosition){
      int[] defenceScore = new int[] {0,0};

      if(attackPosition == AttackPosition.NULL){
          int totalSuccessfullDefence = 0;
          int totalFailedDefence = 0;
          foreach(int key in _defenceScore.Keys){
              totalSuccessfullDefence += _defenceScore[key][0];
              totalFailedDefence += _defenceScore[key][1] - _defenceScore[key][0];
          }
          defenceScore[0] = totalSuccessfullDefence;
          defenceScore[1] = totalFailedDefence;
      } else if (_defenceScore.ContainsKey((int) attackPosition)){
          defenceScore[0] = _defenceScore[(int) attackPosition][0];
          defenceScore[1] =_defenceScore[(int) attackPosition][1] - _defenceScore[(int) attackPosition][0];
      }

      return defenceScore;
  }

  // returns an array int[]{num good blocks, num wipes}
  public int[] CalculateBlockingScore(AttackPosition attackPosition){
      int[] blockScore = new int[] {0,0};

      if(attackPosition == AttackPosition.NULL){
          int totalSuccessfullBlocks = 0;
          int totalWipedBlocks = 0;
          foreach(int key in _blockingScore.Keys){
              totalSuccessfullBlocks += _blockingScore[key][0];
              totalWipedBlocks += _blockingScore[key][1] - _blockingScore[key][0];
          }
          blockScore[0] = totalSuccessfullBlocks;
          blockScore[1] = totalWipedBlocks;
      } else if (_blockingScore.ContainsKey((int) attackPosition)){
          blockScore[0] = _blockingScore[(int) attackPosition][0];
          blockScore[1] =_blockingScore[(int) attackPosition][1] - _blockingScore[(int) attackPosition][0];
      }

      return blockScore;
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
