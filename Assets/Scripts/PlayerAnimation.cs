using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StuartH;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] PlayerMovement playerMovement;

    void Start()
    {
        anim.SetBool("isDead", false);
        anim.SetBool("isJumping", false);
    }

    public void PlayDeathAnimation()
    {
        anim.SetBool("isDead", true);
    }

    void PlayJumpingAnimation()
    {
        anim.SetBool("isJumping", true);
    }

    void PlayWalkAnimation()
    {
        anim.SetBool("isJumping", false);
    }

    void Update()
    {
        if (playerMovement.JumpVelocity > 0)
        {
            PlayJumpingAnimation();
        }

        if(playerMovement.JumpVelocity < 0)
        {
            PlayWalkAnimation();
        }
    }
}
