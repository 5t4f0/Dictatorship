using UnityEngine;

public class Jump : PlayerState
{
   CharacterController cc;
    Animator animator;
    public float velocity = 5f;
    public float gravity = 9.8f;
    public float jumpForce = 18f;
    public float jumpTime = 0.85f;
    bool isJumping = false;
    float jumpElapsedTime = 0;
    public float Multi;
    public float JumpCountUp;
    public float JumpMaxCount;
    public bool JumpAsked;
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

        if (!inputJump && cc.isGrounded )
        {
            StateMachine.TransitionTo(StateMachine.states[3]);
        }
        
        if( animator != null )
            animator.SetBool("air", cc.isGrounded == false );
    }

    public override void FixedTick()
    {
        var directionX = Movement(out var directionZ, out var directionY);
        directionY = directionY - gravity * Time.deltaTime;
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        forward = forward * directionZ;
        right = right * directionX;
        
        if (directionX != 0 || directionZ != 0)
        {
            float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }

        
        Vector3 verticalDirection = Vector3.up * directionY;
        Vector3 horizontalDirection = forward + right;

        Vector3 moviment = verticalDirection + horizontalDirection;
        cc.Move( moviment );
    }
    private float Movement(out float directionZ, out float directionY)
    {
        if ( isJumping )
        {
            directionY = Mathf.SmoothStep(jumpForce, jumpForce * 0.30f, jumpElapsedTime / jumpTime) * Time.deltaTime;
            
            jumpElapsedTime += Time.deltaTime;
            if (jumpElapsedTime >= jumpTime)
            {
                isJumping = false;
                jumpElapsedTime = 0;
                JumpCountUp = 1f;
            }
        }
        // float velocityAdittion = 0;
        // if ( isSprinting )
        //     velocityAdittion = sprintAdittion;
        // if (isCrouching)
        //     velocityAdittion =  - (velocity * 0.50f); // -50% velocity
        float directionX = inputHorizontal * velocity  * Time.deltaTime;
        directionZ = inputVertical * velocity  * Time.deltaTime;
        directionY = 0;
        return directionX;
    }

    public override void Exit()
    {
        
    }
}
