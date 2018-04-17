using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarburstGaming;


public class BoxManager : MonoBehaviour {

    public GameObject boxPrefab;

    Dictionary<int, Transform> boxes;
    Topic.CometReceiver newBoxTopic;
    Comet boxComet;

	// Use this for initialization
	void Start () {

        boxes = new Dictionary<int, Transform>();

        if (SatelliteLibrary.Running)
        {

            newBoxTopic = new Topic.CometReceiver("NewBox", Topic.CometReceiver.StorageType.QUEUE); //TODO: Change to stream

            boxComet = new Comet("Box");

            newBoxTopic.OnCometReceived(NewBox);

        }
		
	}
    //What happend when a new Box is send
    void NewBox(Comet c)
    {
        Debug.Log("Ok je suis rentré dans NewBOX");
        Vector2 pos = c["Position"].AsVector2();

        boxes.Add(boxes.Count, Instantiate(boxPrefab, new Vector3(pos.x, pos.y), Quaternion.identity).transform);
        SendBoxes();

    }

    void SendBoxes()
    {
        Debug.Log("Ok je suis dans SendBoxes");
        foreach (var box in boxes)
        {
            Debug.Log(box);
            Vector3 pos = box.Value.position;

            boxComet["ID"].Set(box.Key);
            boxComet["Position"].Set(new Vector2(pos.x, pos.y));

            Topic.SendComet("Boxes", boxComet);

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
