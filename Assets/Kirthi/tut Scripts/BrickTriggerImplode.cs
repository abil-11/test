using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class BrickTriggerImplode : MonoBehaviour

{

    private GameObject brickArrayT;


    // Use this for initialization

    void Start()

    {

        brickArrayT = GameObject.FindGameObjectWithTag("BrickArrayTag");

    }


    // Update is called once per frame

    void Update()

    {


    }


    public void OnMouseDown()

    {

        brickArrayT.GetComponent<Animator>().Play("Implode");


    }


}