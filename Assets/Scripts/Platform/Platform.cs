using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    public void Break()
    {
        PlatformSegment[] platformSegment = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegment)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}
