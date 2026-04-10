using System;
using UnityEngine;

public class ScalingJumpbar : MonoBehaviour
{
    public ThirdPersonController controller;
    public float NewScale;
    public float multi;

    private void Update()
    {
        NewScale = (controller.JumpCountUp-1)*multi;
        transform.localScale = new Vector3(NewScale, transform.localScale.y, transform.localScale.z);
    }
}
