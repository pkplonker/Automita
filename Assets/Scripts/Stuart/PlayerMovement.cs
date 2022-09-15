using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuartH
{
    /// <summary>
    ///PlayerMovement - simple player movement controller
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float panSpeed = 1.5f;
        [SerializeField] private bool isActive = true;
        [SerializeField] private float maxMoveAmount = 100f;


        private CharacterController characterController;
        public event Action<float> SpeedChange;
        private void Awake() => characterController = GetComponent<CharacterController>();
        public float GetSpeed() => moveSpeed;


        public float JumpVelocity = 0.0f; //made it public to access for animation
        [SerializeField] private float jumpForce;
        [SerializeField] private float mGravity = 19.2f;
        
        [SerializeField] private float mCrouchedHeight = 1.0f;
        [SerializeField] private float mStandingHeight = 2.0f;


        private void OnEnable() => CountDown.OnGameStart += OnGameStart;

        private void OnGameStart() => SetEnabled(true);

        public void SetSpeed(float s)
        {
            moveSpeed = s;
            SpeedChange?.Invoke(moveSpeed);
        }

      

        private void Update()
        {
            if (!isActive) return;
            var move = transform.forward * moveSpeed;
            if (Input.GetKey(KeyCode.A)) move -= transform.right * panSpeed;
            if (Input.GetKey(KeyCode.D)) move += transform.right * panSpeed;


            if (Input.GetKey(KeyCode.C))
            {
                characterController.height = mCrouchedHeight;
            }
            else
            {
                characterController.height = mStandingHeight;
            }

            //Jump
            if (characterController.isGrounded)
            {
                JumpVelocity = -0.5f;

                if (Input.GetKey(KeyCode.Space))
                {
                    JumpVelocity = moveSpeed * jumpForce;
                }
            }
            else
            {
                JumpVelocity -= mGravity * Time.deltaTime;
            }
            move += transform.up * JumpVelocity;

        


            characterController.Move(Time.deltaTime * move);


            if(DeathCheck.isDead)
            {
                isActive = false;
            }
        }

        public void SetEnabled(bool b) => isActive = b;
    }
}