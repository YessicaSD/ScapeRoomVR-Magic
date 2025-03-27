using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class Fly : MonoBehaviour
{

    public InputActionReference customToggleReference;
    private InputAction toggleReference;
    public Transform leftHand;
    public Transform head;
    public Transform foots;
    public float flyingSpeed;
    private float targetFlyingSpeed = 0;
    private float currentFlyingSpeed = 0;
    private bool isFlying = false;
    private bool canFly = true;
    [SerializeField] private LayerMask _layerMask;


    private void Start()
    {
        toggleReference = customToggleReference.action;
        toggleReference.started += ToggleJetpackAction;
        toggleReference.canceled += ToggleJetpackAction;
        toggleReference.Enable();
    }


    private void Update()
    {
        Thrust();
    }

    public void SetCanFlyFalse()
    {
        canFly = false;
        targetFlyingSpeed = 0;

    }

    private void ToggleJetpackAction(InputAction.CallbackContext context)
    {
        if (canFly)
        {
            isFlying = !isFlying;
            targetFlyingSpeed = isFlying ? flyingSpeed : 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 flyDirection = leftHand.transform.position - head.transform.position;
        Gizmos.DrawLine(foots.position, foots.position + flyDirection * currentFlyingSpeed);
    }
    private void Thrust()
    {
        Vector3 flyDirection = leftHand.transform.position - head.transform.position;
        currentFlyingSpeed = Mathf.Lerp(currentFlyingSpeed, targetFlyingSpeed, Time.deltaTime);
        if (currentFlyingSpeed != 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(foots.position, flyDirection, out hit, currentFlyingSpeed * Time.deltaTime, _layerMask) ||
                Physics.Raycast(leftHand.position, flyDirection, out hit, currentFlyingSpeed * Time.deltaTime, _layerMask))
            {
                targetFlyingSpeed = 0;
                currentFlyingSpeed = 0;
            }

        }

        transform.position += flyDirection.normalized * Time.deltaTime * currentFlyingSpeed;
    }

}