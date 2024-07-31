using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int maxCapacity; //SerializeField because this will change between levels
    private int index = 0;
    private int lineIndex = 1;
    
    public List<Vector3> positions = new List<Vector3>(); //Create a Vector3 list
    public Vector3 worldPosition;
    public Vector3[] linePoints = new Vector3[10];

    public GameObject indicator;

    public LineRenderer lineRenderer;

    public ColliderCheck ColliderChecker;
    
    public float yLevel;
    
    public bool isCanGo = false;
    public bool isPaused;
    public bool isMoveMade;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = (maxCapacity + 1);
        lineRenderer.enabled = false;
        isMoveMade = false;
    }

    void Update()
    {
        LineRender();
        CharacterInput();
        CharacterMove();

        if (positions.Count == maxCapacity) //I don't want it to move unless the character has used all its rights. So player only move when "position" List equal to Max Capacity 
        {
            isCanGo = true; //set isCanGo to true
        }
        else
        {
            isCanGo = false; 
        }
    }

    void CharacterInput()
    {
        
        if (Input.GetButtonDown("Fire1")) //When MB1 clicked
        {
            if (positions.Count < maxCapacity && isPaused == true) //If "positions" List count less than Max Capacity and while is game paused  
            {
                Vector3 mousePos = Input.mousePosition; //Get where is mouse on screen position info as Vector3
                
                Quaternion indicatorRotation = transform.rotation * Quaternion.Euler(90f, 0f, 0f);
                
                worldPosition = Camera.main.ScreenToWorldPoint(mousePos); //Change the Screen Position data to World Position data
                
                Vector3 vectorPos = new Vector3((worldPosition.x), 0.1f, (worldPosition.z));
                positions.Add(worldPosition); //Add World Position data to "positions" List
                Instantiate(indicator, vectorPos, indicatorRotation);
                lineIndex++;
                Debug.Log(mousePos.x + " " + mousePos.y);
               
                // Ana kamerayı al
                Camera mainCamera = Camera.main;

                if (mainCamera != null)
                {
                    // Kameranın mevcut pozisyonunu al
                    Vector3 cameraPosition = mainCamera.transform.position;

                    // Kameranın Y pozisyonunu 1 birim yukarı çıkar
                    cameraPosition.y += 1.0f;

                    // Yeni pozisyonu kameraya uygulayın
                    mainCamera.transform.position = cameraPosition;
                }

            }
        }

        if (Input.GetButtonDown("Jump")) //When Space clicked
        {
            Time.timeScale = 0; //Pause game and 
            isPaused = true; //change isPaused bool to true
            lineRenderer.enabled = true;
        }
    }

    void CharacterMove()
    {
        if (index <= positions.Count && isCanGo == true && isPaused == true) //If index variable less or equal to "position" List count & isCanGo variable true & isPaused true
        {
            Vector3 controlVector = new Vector3((positions[index].x), yLevel, (positions[index].z)); //Abstaction, set controlVector variable as new Vector3 and set x and z to positions[index] x and z
            Vector3 currentPosition = gameObject.transform.position; //Abstaction
            ColliderChecker.isObstacle = false;
            Debug.Log("isObstacle false");
            gameObject.transform.position = Vector3.MoveTowards(currentPosition, controlVector, 2); //Abstaction, from Current Position move towards to Control Vector 2 unit per call

            lineRenderer.enabled = false;
            
            if (currentPosition == controlVector && index < positions.Count - 1) //Abstaction, If Player's Current Position same as Control Vector and index variable less than "positions" List index 
            {
                index++; //add 1 to index variable
            }
            else if (currentPosition == controlVector && index == positions.Count - 1) //Abstaction, If Player's Current Position same as Control Vector and index variable equal to "positions" List index
            {
                index = 0; //set index to 0
                Time.timeScale = 1; //Unpause game
                isPaused = false; //Set isPaused variable to false
                positions.Clear(); //Clear the "positions" List
                DeleteIndicators();
                isMoveMade = true;
            }
        }
    }

    void LineRender()
    {
            Camera c = Camera.main;
            Vector3 p = c.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, c.nearClipPlane));
            linePoints[lineIndex] = p; 
            
            for (int i = lineIndex + 1; i < (maxCapacity + 1); i++)
            {
                linePoints[i] = p;
            }
            
            lineRenderer.SetPositions (linePoints);
    }

    void DeleteIndicators()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Indicator");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }
    }
}
