﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAdvancer : MonoBehaviour
{
    public int nextLevel; 
    public AudioSource sound; 
    
    public GameObject present; 
    public GameObject canvas; 

    public GameObject listener; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(present.active == true)
        {   
            StartCoroutine(advance());  
        }
    }

    IEnumerator advance()
    {
        listener.SetActive(true);
        sound.Play();
        present.SetActive(false);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel); 

    }
}
