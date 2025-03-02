﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
  
    public int damage;

    public float minSpeed;
    public float maxSpeed;

    float speed;

    Player playerScript;

    public GameObject explosion; 



    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D hitObject){
        if (hitObject.tag == "Player"){
            playerScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (hitObject.tag == "Ground"){
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        


    }



}
