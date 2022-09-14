using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StuartH
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float rotationSpeed;

      
        private void LateUpdate()
        {
            transform.position = playerMovement.transform.position;
            playerCamera.transform.localPosition = offset;
            var v = (playerMovement.transform.position - playerCamera.transform.position).normalized;
            var t = Quaternion.LookRotation(v);

            playerCamera.transform.rotation = Quaternion.Slerp(transform.rotation, t, rotationSpeed * Time.deltaTime);
        }
    }
}
