using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public virtual void OnTransitionOut(){

    }

    public virtual void OnTransitionIn(){

    }

    public virtual void OnSuccesfullArrowDrag(Vector3 arrowPosition, AttackPosition attackPosition){

    }

    public virtual void OnAttackButtonClick(AttackPosition attackPosition){

    }

    public virtual void UpdateGraphics(){

    }
}
