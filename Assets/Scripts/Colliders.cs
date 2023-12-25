using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    private void Start()
    {
        CreateEdgeColliders();
    }
    
    private void CreateEdgeColliders()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        float screenHeight = mainCamera.orthographicSize * 2f;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Calculate screen edges in world coordinates
        Vector2 topLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 bottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        // Create box colliders
        CreateCollider(topLeft, topRight, "TopCollider");
        CreateCollider(topLeft, bottomLeft, "LeftCollider");
        CreateCollider(topRight, bottomRight, "RightCollider");
        CreateCollider(bottomLeft, bottomRight, "BottomCollider");
    }

    private void CreateCollider(Vector2 startPoint, Vector2 endPoint, string colliderName)
    {
        GameObject colliderObj = new GameObject(colliderName);
        colliderObj.transform.parent = transform;

        BoxCollider2D collider = colliderObj.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(Vector2.Distance(startPoint, endPoint), 0.1f);
        collider.offset = (startPoint + endPoint) / 2f;
    }
}
