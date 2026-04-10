using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State startState;
    private State currentState;
    public State[] states;

    private void Start()
    {
        currentState = states[0];
        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.Tick();
    }

    private void FixedUpdate()
    {
        currentState.FixedTick();
    }

    public void TransitionTo(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter(this);
    }
}
