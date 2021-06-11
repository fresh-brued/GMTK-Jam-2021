﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMediator : MonoBehaviour
{
    // Start is called before the first frame update
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(GameObject presentObject)
    {
        PresentObjectTypes type = presentObject.GetComponent<PresentInteractable>().type;
        switch(type)
        {
            case PresentObjectTypes.Destroyable:
                Destroy(presentObject);
                break; 
            case PresentObjectTypes.Moveable: 
                presentObject.transform.position =  new Vector2(presentObject.transform.position.x + 5f, presentObject.transform.position.y + 5f);
                break; 
        }
        
    }
}
