using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class BrickTriggerExplode : MonoBehaviour

{

    public GameObject brickArray;


    // Use this for initialization

    void Start()

    {

    }


    // Update is called once per frame

    void Update()

    {


    }


    public void OnMouseDown()

    {

        brickArray.GetComponent<Animator>().Play("Explode");


    }


}