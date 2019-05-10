﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class PlantSeed : MonoBehaviour
{
    public bool planted;
    public GameObject seed;
    public PlantType child;

    public ParticleSystem ps;

    public ParticleSystem w;
    public PlayerStats player;

    bool watering;

    bool playing;
    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, plantSeed);
        child = null;
        planted = false;
        StartCoroutine(seed1()); 
    }

    private void Update() {
        if(child.ready){
            if(!playing){
                ps.Play();
                playing = true;
            }
        }
        else{
            playing = false;
            ps.Stop();
        }

        if(watering){
            w.Play();
            StartCoroutine(stopWatering());
        }
    }

    IEnumerator stopWatering(){
        yield return new WaitForSeconds(3f);
        w.Stop();
        watering = false;
    }



    // Command for click
    // Plants seed if none planted, and waters if tool is on water
    public void plantSeed(){
        //Debug.Log("Planted");
        if(!planted && player.currTool.name == "Plant"){
            GameObject center = gameObject.transform.Find("Plant").gameObject;
            GameObject temp = Instantiate(seed, center.transform.position, Quaternion.identity, center.transform);
            child = temp.GetComponent<PlantType>();
            planted = true;
        }
        else if(planted && player.currTool.name == "Water"){
            Water();
        }
    }
    
    public void Water(){
        
        if(player.currTool.name == "Water" && player.water >= 0.2f){
            if(child.water > 1f){
                child.water = 1.2f;
            }
            else{
                child.water += 0.2f;
            }
            
            if(player.water < 0.2f){
                player.water = 0f;
            }
            else{
                player.water -= 0.2f;
            }
            watering = true;
        }
    }

    IEnumerator seed1(){
        plantSeed();
        yield return new WaitForSeconds(2);
        //plantSeed();
        //Debug.Log("PLanted");
    }
}
