using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class NewBehaviourScript : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 viewportPosition = new Vector3(0.5f, 0.5f, 5f); // Center of the screen with 5 units away from the camera
    public float moveSpeed = 0.1f; // Speed of the movement
    public bool moveUp;
    public bool isMoving; // Flag to indicate if the object is currently moving

    public Animator anim;
    public float targetY;

    public GameObject buttonUp;
    public GameObject[] buttonDown;
    

    void Start()
    {
        // Set initial position using ViewportToWorldPoint
       // UpdatePosition();
       moveUp = false;
    }

    public void UpdatePosition()
    {
        // Convert the viewport position to world position
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        float newY = Mathf.MoveTowards(viewportPosition.y, moveUp ? 0.30f : -0.45f, moveSpeed * Time.deltaTime);

        if (Mathf.Approximately(newY, targetY))
        {
            isMoving = true; // Object has reached its destination
        }
        else
        {
            isMoving = false; // Object is still moving
        }

        if (viewportPosition.y >= 0.29f)
        {
            anim.SetBool("Open", true);
        }
        else
        {
            anim.SetBool("Open", false);
        }
        
        // Smooth the movement using Lerp
        float smoothTime = 0.1f; // Adjust this value to control the smoothness
        float smoothY = Mathf.SmoothDamp(viewportPosition.y, newY, ref targetY, smoothTime);

        viewportPosition.y = smoothY;
        transform.position = worldPosition;
    }
    
    public void MoveUp()
    {
       moveUp = true; buttonUp.SetActive(false);
       
    
    }

    public void SetDownOn()
    {
        //for each gammeobject in buttondown set actve fasle
        foreach (GameObject button in buttonDown)
        {
            button.SetActive(true);
        }
    }

    public void AnimDown()
    {
        anim.SetBool("Open", false);
        foreach (GameObject button in buttonDown)
        {
            button.SetActive(false);
        }
     // buttonUp.SetActive(true);
    }

    public void MoveDown()
    {
        moveUp = false;
        StartCoroutine(ButtonActive());

    }
    
    IEnumerator ButtonActive()
    {
        yield return new WaitForSeconds(0.9f);
        buttonUp.SetActive(true);
    }

    void FixedUpdate()
    {
        // If you need to update the position dynamically, call UpdatePosition
        UpdatePosition();
        
    }
}


