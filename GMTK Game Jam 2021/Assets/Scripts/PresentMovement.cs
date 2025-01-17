﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentMovement : Movement
{

    public GameObject[] weapon; 
    public bool canAttack; 

    public GameObject[] enemies; 

    public AudioSource attackSound; 
    Vector3 spawnpoint; 

    bool pickUp;

    // Start is called before the first frame update
    void Start()
    {
        //canAttack = true; 
        spawnpoint = gameObject.transform.position; 
    }
    void Update()
    {
        this.getMovement();
        if(Input.GetKeyDown("escape"))
        {
            menu.SetActive(true);
        }
        if(Input.GetKeyDown("t"))
        {
            this.SwitchTimelines();
        }
        if (Input.GetKeyDown("space") && canInteract)
        {
            collision.gameObject.GetComponent<PastInteractable>().OnInteract(this);
        }

        if(Input.GetKeyDown("space")&&pickUp)
        {
            if (collision.gameObject.tag == "Sword")
            {
                canAttack = true;
                pickUp = false;
                collision.gameObject.SetActive(false); 
            }
        }
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            attackSound.Play();
            switch(direction)
            {
                case Directions.Up:
                    StartCoroutine(attack(weapon[0]));
                    break; 
                case Directions.Right:
                    StartCoroutine(attack(weapon[1]));
                    break; 
                case Directions.Left:
                    StartCoroutine(attack(weapon[1]));
                    break; 
                case Directions.Down:
                   StartCoroutine(attack(weapon[3]));
                    break; 
            }
        }
        
    }

    void FixedUpdate() 
    {
        this.updatePosition();
         
    }

    private void OnCollisionEnter2D(Collision2D other) {

        Collided(other);
        if(other.gameObject.tag == "Enemy")
        {
            gameObject.transform.position = spawnpoint; 
            foreach (GameObject enemy in enemies)
            {   
                enemy.SetActive(true);
                enemy.GetComponent<SpriteRenderer>().enabled = true;
                enemy.GetComponent<BoxCollider2D>().enabled = true;
                enemy.active = true; 
                enemy.transform.position = enemy.GetComponent<Enemy>().spawnpoint; 
            }
    
        }
        if (other.gameObject.tag == "Sword")
        {
            pickUp = true; 
        }
    }

    private IEnumerator attack(GameObject weapon)
    {
        canAttack = false; 
        weapon.SetActive(true); 
        yield return new WaitForSeconds(0.1f); 
        weapon.SetActive(false);
        canAttack = true; 

    }

    void respawn(){

    }
}
