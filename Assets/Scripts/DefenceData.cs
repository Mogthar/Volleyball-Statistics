using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceData : DataModule
{
  public DefenceData(GameObject hitMarkPrefab, GameMenu sisterMenu) : base(hitMarkPrefab, sisterMenu) {}

  // might make this method of the parent class but would need to fix the fact that the parents for hit marks are datamodule specific

  public void CreateHitMark(Vector3 markPosition, int score){
      CreateHitMarkCommand command = new CreateHitMarkCommand(markPosition, score, _hitMarkPrefab, GameManager.UI.defenceMenu.hitMarkParent, this);
      command.Execute();
      _commandList.Add(command);

      GameManager.UI.defenceMenu.UpdateGraphics();
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
