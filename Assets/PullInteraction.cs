using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PullInteraction : XRBaseInteractable
{
    public static event Action<float> pullActionRelease;
    public Transform start, end;
    public GameObject notch;
    public Transform stringGrab;

    public float pullAmount { get; private set; } = 0.0f;

    private IXRSelectInteractor pullingInteractor = null;

    protected override void Awake()
    {
        base.Awake();

    }

    public void SetPullInteractor(SelectEnterEventArgs args)
    {
        pullingInteractor = args.interactorObject;
    }

    public void Release()
    {
        pullActionRelease?.Invoke(pullAmount);
        pullingInteractor = null;
        pullAmount = 0.0f;
        //notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, 0f);
        UpdateString();
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
            {
                Vector3 pullPosition = pullingInteractor.transform.position;
                pullAmount = CalculatePull(pullPosition);
                UpdateString();
            }
        }
    }
    Vector3 pos = Vector3.zero;
    private float CalculatePull(Vector3 pullPosition)
    {
        pos = pullPosition;
        Vector3 pullDirection = pullPosition - start.position;
        Vector3 targetDirection = end.position - start.position; // this should be the other way, but the dot product is returning negative values
        float maxLength = targetDirection.magnitude;
        targetDirection.Normalize();
        float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0, 1);
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(start.position, pos);
    }
    private void UpdateString()
    {

        Vector3 linePosition = Vector3.Lerp(start.position, end.position, pullAmount);
        stringGrab.position = linePosition;

    }

}
