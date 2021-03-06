﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStack : MonoBehaviour {

    private const float BOUNDS_SIZE = 3.5f;
    private const float STACK_MOVING_SPEED = 5.0f;

    private GameObject[] theStack;
    private int scoreCount = 0;
    private int stackIndex;

    private float tileTransition = 0.0f;
    private float tileSpeed = 2.5f;
    private float secundaryPosition;

    private bool isMovingOnX = true;

    private Vector3 desiredPosition;
    
    private void Start ()
    {
        theStack = new GameObject[transform.childCount];
        for(int i = 0; i< transform.childCount;i++)
            theStack[i] = transform.GetChild(i).gameObject;
        stackIndex = theStack.Length - 1;
    }
	
	private void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlaceTile())
                SpawnTile();
            else
                EndGame();
            scoreCount++;
        }
        MoveTile();
        transform.position = Vector3.Lerp(transform.position, desiredPosition,STACK_MOVING_SPEED * Time.deltaTime);
	}

    private void MoveTile()
    {
        tileTransition += Time.deltaTime * tileSpeed;
        if(isMovingOnX)
            theStack[stackIndex].transform.localPosition = new Vector3(Mathf.Sin(tileTransition) * BOUNDS_SIZE, scoreCount, secundaryPosition);
        else
            theStack[stackIndex].transform.localPosition = new Vector3(secundaryPosition, scoreCount, Mathf.Sin(tileTransition) * BOUNDS_SIZE);
    }

    private void SpawnTile()
    {
        stackIndex--;
        if (stackIndex < 0)
            stackIndex = theStack.Length - 1;
        desiredPosition = Vector3.down * scoreCount;
        theStack[stackIndex].transform.localPosition = new Vector3(0, scoreCount, 0);
    }
    
    private bool PlaceTile() 
    {
        Transform t = theStack[stackIndex].transform;

        if (isMovingOnX)
        {
           
        }
        secundaryPosition = isMovingOnX ? t.localPosition.x : t.localPosition.z;
        isMovingOnX = !isMovingOnX; 
        return true;
    }

    private void EndGame()
    {

    }
}