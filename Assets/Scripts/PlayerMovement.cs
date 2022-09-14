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
            characterController.Move(Time.deltaTime * move);
        }

        public void SetEnabled(bool b) => isActive = b;
    }
}
