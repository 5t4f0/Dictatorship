using UnityEngine;

public class PlayerState : State
{
   public float inputHorizontal;
   public float inputVertical;
   public bool inputJump;
   public bool inputCrouch;
   public bool inputSprint;
   public bool inputJumpRelease;
    
    public void CheckInput()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        inputJump = Input.GetAxis("Jump") == 1f;
        inputJumpRelease = Input.GetAxis("Jump") == 0f;
        inputSprint = Input.GetAxis("Fire3") == 1f;
        inputCrouch = Input.GetAxis("Fire1") == 1f;
    }
}
