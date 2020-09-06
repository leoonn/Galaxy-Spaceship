﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : shoot
{
    //variable
    shoot shootScript;
    public powerUp typePower;
    public int TimeRemaningPowerUp = 15;
    public GameObject shield;
    public bool pointsDouble = false;

    private void Start()
    {

        shootScript = GameObject.Find("Spaceship Galaga white").GetComponent<shoot>(); // get component script in player

        typePower = powerUp.empty; //set empty state
    }

    private void Update()
    {
        switch (typePower) // check state of typepower
        {
            case powerUp.doubleShoot:  // check state 
                StartCoroutine(DoubleShoot()); //start timer of power up double shoot
                if (Input.GetButton("Shoot") && countTime > fireRate) // if true ? shoot !!
                {

                    Instantiate(bulletprefab, Gunplayer[1].position, Gunplayer[1].rotation); //instanteate one bullet
                    ResetTime(); //call the method 

                }

                countTime++;
                break;
            case powerUp.tripleShoot: //check state 
                StartCoroutine(TripleShoot()); //start timer of power up triple shoot
                if (Input.GetButton("Shoot") && countTime > fireRate) // if true ? shoot !!
                {

                    Instantiate(bulletprefab, Gunplayer[1].position, Gunplayer[1].rotation); //instanteate one bullet
                    Instantiate(bulletprefab, Gunplayer[2].position, Gunplayer[2].rotation); //instanteate one bullet
                    ResetTime(); //call the method 

                }

                countTime++;
                break;
            case powerUp.shootFast:
                StartCoroutine(FastShoot()); //start timer of power up fast shoot
                shootScript.fireRate = 8; //set value of fire rate
                break;
            case powerUp.shield:

                shield.SetActive(true);

                break;
            case powerUp.doubleScore:

                StartCoroutine(DoubleScore());
                pointsDouble = true;
                break;

        }



    }
    IEnumerator DoubleShoot() //timer power up
    {
        yield return new WaitForSeconds(TimeRemaningPowerUp);
        typePower = powerUp.empty; //set state after timer

    }
    IEnumerator TripleShoot()
    {
        yield return new WaitForSeconds(TimeRemaningPowerUp);//set state after timer
        typePower = powerUp.empty;//set state after timer
    }
    IEnumerator FastShoot()
    {
        yield return new WaitForSeconds(TimeRemaningPowerUp);
        typePower = powerUp.empty;//set state after timer
        shootScript.fireRate = 25; //set value of fire rate
    }
    public void Shield()
    {
        typePower = powerUp.empty;//set state after timer
        shield.SetActive(false);
    }
    IEnumerator DoubleScore()
    {
        yield return new WaitForSeconds(TimeRemaningPowerUp);
        typePower = powerUp.empty;//set state after timer
        pointsDouble = false;
    }
}
