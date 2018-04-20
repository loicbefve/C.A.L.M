using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallManager : MonoBehaviour {

    public GameObject wallPrefab;
    List<Vector3> mousePositions = new List<Vector3>();
    bool isMouseDown;
    bool isWallMake;
    Vector3 wallSize;


    // Use this for initialization
    void Start () {
        isMouseDown = false;
        isWallMake = true;
        wallSize = wallPrefab.GetComponent<Renderer>().bounds.size;
        Debug.Log(wallSize.x);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // I track the trajectory of the wall:
        trackWallTrajectory();
        if( !isWallMake)
        {
            placeWalls(mousePositions);
        }
        

	}

    void trackWallTrajectory()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            isWallMake = false;
        }

        if (isMouseDown)
        {
            mousePositions.Add(Input.mousePosition);
            Debug.Log(mousePositions.Count);
        }
    }

    void placeWalls( List<Vector3> theMousePositions)
    {
        Vector3 lastGoodWallPosition = theMousePositions[0];
        foreach (Vector3 pos in theMousePositions)
        {
            if ( Mathf.Abs(pos.x - lastGoodWallPosition.x) >=  wallSize.x || Mathf.Abs(pos.y - lastGoodWallPosition.y) >= wallSize.y)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
                Instantiate(wallPrefab, worldPos, Quaternion.identity);
                lastGoodWallPosition = pos;
            }
        }
        theMousePositions.Clear();
        isWallMake = true;
    }
}
