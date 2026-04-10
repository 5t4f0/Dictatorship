using UnityEngine;

public class Moving : PlayerState
{
    CharacterController cc;
    Animator animator;
    public float velocity = 5f;
    public override void Enter(StateMachine stateMachine) 
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogWarning("Hey buddy, you don't have the Animator component in your player. Without it, the animations won't work.");
    }
 
    public override void Tick() 
    {
        CheckInput();
        if (inputCrouch)
        {
            StateMachine.TransitionTo(StateMachine.states[1]);
        }

        if (inputJump && cc.isGrounded )
        {
            StateMachine.TransitionTo(StateMachine.states[2]);
        }
    }

    public override void FixedTick()
    {
        var directionX = Movement(out var directionZ, out var directionY);
    }
    private float Movement(out float directionZ, out float directionY)
    {
        // float velocityAdittion = 0;
        // if ( isSprinting )
        //     velocityAdittion = sprintAdittion;
        // if (isCrouching)
        //     velocityAdittion =  - (velocity * 0.50f); // -50% velocity
        float directionX = inputHorizontal * velocity  * Time.deltaTime;
        directionZ = inputVertical * velocity  * Time.deltaTime;
        directionY = 0;
        return directionX;
        if ( cc.isGrounded && animator != null )
        {
            float minimumSpeed = 0.9f;
            animator.SetBool("run", cc.velocity.magnitude > minimumSpeed );
        }
    }

    public override void Exit()
    {
        
    }
}
