using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateMachine StateMachine;
    public virtual void Enter(StateMachine stateMachine) 
    {
        StateMachine = stateMachine;
        Debug.Log("Enter ");
    }
 
    public virtual void Tick() 
    {
        Debug.Log("Update ");
        
    }
    public virtual void FixedTick() 
    {
        Debug.Log("Update ");
        
    }
 
    public virtual void Exit()
    {
        Debug.Log("Exit ");
    }
    
}
