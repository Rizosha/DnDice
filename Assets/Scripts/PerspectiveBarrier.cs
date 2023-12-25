using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveBarrier : MonoBehaviour
{
 
    [Tooltip("What camera to poll viewport information from. Uses Camera.main when this is not specified.")]
    public Camera cam;
    [Tooltip("How far the colliders are scaled in the camera's forward direction.")]
    public float depth = 100f;
    [Tooltip("When camera is in perspective mode, what distance to sample at to get the correct bounding box."), Range(0f, 1f)]
    public float distanceQuery = 1f;

    GameObject top, bottom, left, right;
    GameObject[] barriers;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        CreatePerspectiveBarriers();
    }

    private void CreatePerspectiveBarriers()
    {
        top = GameObject.CreatePrimitive(PrimitiveType.Cube);
        top.name = "Top";
        top.transform.localScale = new Vector3(0f, 0f, depth);

        bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bottom.name = "Bottom";
        bottom.transform.localScale = new Vector3(0f, 0f, depth);

        left = GameObject.CreatePrimitive(PrimitiveType.Cube);
        left.name = "Left";
        left.transform.localScale = new Vector3(0f, 0f, depth);

        right = GameObject.CreatePrimitive(PrimitiveType.Cube);
        right.name = "Right";
        right.transform.localScale = new Vector3(0f, 0f, depth);

        barriers = new GameObject[] { top, bottom, left, right };

        foreach (var b in barriers)
        {
            DestroyImmediate(b.GetComponent<Collider>());
            DestroyImmediate(b.GetComponent<Renderer>());

            b.transform.parent = cam.transform;

            var bc = b.AddComponent<BoxCollider>();
            var rb = b.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }

        SetScales();
        SetPositions();
    }

    private void SetScales()
    {
        float verticalSize = 2f * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad) * distanceQuery;
        float horizontalSize = verticalSize * cam.aspect;

        top.transform.localScale = new Vector3(horizontalSize, 0.01f, depth);
        bottom.transform.localScale = new Vector3(horizontalSize, 0.01f, depth);
        left.transform.localScale = new Vector3(0.01f, verticalSize, depth);
        right.transform.localScale = new Vector3(0.01f, verticalSize, depth);
    }

    private void SetPositions()
    {
        var camRot = cam.transform.rotation;
        cam.transform.rotation = Quaternion.identity;

        top.transform.position = cam.ViewportToWorldPoint(new Vector3(0.5f, 1.1f, distanceQuery));
        bottom.transform.position = cam.ViewportToWorldPoint(new Vector3(0.5f, -0.1f, distanceQuery));
        left.transform.position = cam.ViewportToWorldPoint(new Vector3(-0.04f, 0.5f, distanceQuery));
        right.transform.position = cam.ViewportToWorldPoint(new Vector3(1.04f, 0.5f, distanceQuery));

        top.transform.localRotation = Quaternion.identity;
        bottom.transform.localRotation = Quaternion.identity;
        left.transform.localRotation = Quaternion.identity;
        right.transform.localRotation = Quaternion.identity;

        foreach (var b in barriers)
            b.transform.localPosition = ZeroZ(b.transform);

        cam.transform.rotation = camRot;
    }

    private Vector3 ZeroZ(Transform t)
    {
        var pos = t.localPosition;
        pos.z = depth / 2f;
        return pos;
    }

    void FixedUpdate()
    {
        if (cam == null)
            cam = Camera.main;

        distanceQuery = Mathf.Clamp01(distanceQuery);
        SetScales();
        SetPositions();
    }
}


