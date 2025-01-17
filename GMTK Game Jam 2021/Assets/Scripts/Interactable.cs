﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    public ObjectTypes type;

    public GameObject goal, particle;

    //Set Variables (enum?) and do different things accordingly 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void noGoal()
    {
        goal = null;
    }



    public void Disable()
    {
        goal.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (particle)
        {
            particle.SetActive(false);
            particle.SetActive(true);
        }
    }

    public void Enable()
    {
        if(particle)
            particle.SetActive(false);
        if (goal)
            goal.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        noGoal();
    }

    public void DestroyMe()
    {
        Debug.Log(this);
        StartCoroutine(effectToDestroy());
    }

    public IEnumerator effectToDestroy()
    {
        if (particle)
        {
            particle.SetActive(false);
            particle.SetActive(true);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }





}
