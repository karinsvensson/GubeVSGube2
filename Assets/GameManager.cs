using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gube Gube0 = null;
    public Gube Gube1 = null;
    public Gube CurrentlyAttacking = null;
    public Gube NextAttack = null;

    public OnSelectDoThing DmgText0;
    public OnSelectDoThing DmgText1;

    public float StateTimerMax = 1.0f;
    float StateDelta = 0.0f;

    public void Update()
    {
        StateDelta += Time.deltaTime;
        if(StateDelta > StateTimerMax)
        {
            StateDelta = 0.0f;
            if (CurrentlyAttacking != null)
            {
                Gube0.CurrentState = GubStates.IdleDefend;
                Gube1.CurrentState = GubStates.IdleDefend;
                CurrentlyAttacking = null;
            }
            else
            {
                CurrentlyAttacking = NextAttack;
                if (CurrentlyAttacking == Gube0)
                {
                    Gube0.CurrentState = GubStates.Attack;
                    Gube1.CurrentState = GubStates.Damaged;
                    DmgText0.gameObject.SetActive(false);
                    DmgText1.gameObject.SetActive(true);
                    DmgText1.OnSelect(Random.Range(0, 100).ToString());
                    NextAttack = Gube1;
                    
                }
                else
                {
                    Gube0.CurrentState = GubStates.Damaged;
                    Gube1.CurrentState = GubStates.Attack;
                    DmgText1.gameObject.SetActive(false);
                    DmgText0.gameObject.SetActive(true);
                    DmgText0.OnSelect(Random.Range(0, 100).ToString());
                    NextAttack = Gube0;
                }
    
            }
        }
    }
}
