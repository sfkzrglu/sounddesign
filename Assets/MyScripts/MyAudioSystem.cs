using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioSystem : MonoBehaviour
{
    public Transform playerTransform;

    public StudioEventEmitter tavernAmbienceEmitter;
    public StudioEventEmitter musicEmitter;
    public StudioEventEmitter outsideAmbienceEmitter;

    private string lastFloorTag;

    // Start is called before the first frame update
    void Start()
    {
        tavernAmbienceEmitter.Stop();
        musicEmitter.Stop();
        outsideAmbienceEmitter.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        string floorTag=GetFloorTagOfPlayer();
        if (!String.IsNullOrEmpty(floorTag) && lastFloorTag!=floorTag)
        {
            if(floorTag=="Wood" || floorTag == "Stone")
            {
                tavernAmbienceEmitter.Play();
                musicEmitter.Play();
                outsideAmbienceEmitter.Stop();
            }
            else
            {
                tavernAmbienceEmitter.Stop();
                musicEmitter.Stop();
                outsideAmbienceEmitter.Play();
            }
            switch (floorTag)
            {
                case "Wood":                   
                    break;
                case "Stone":
                    break;
                default:
                    break;
            }
            lastFloorTag = floorTag;
        }
        
    }


    private string GetFloorTagOfPlayer()
    {
        RaycastHit hit;
        Debug.DrawLine(playerTransform.position, playerTransform.position+ Vector3.down,Color.red);
        if (Physics.Raycast(playerTransform.position,Vector3.down,out hit))
        {
            return hit.collider.tag;
        }
        return null;
    }
}
