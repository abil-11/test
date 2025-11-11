using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{    public float speed = 50.0f;

	//PSEUDO CODE: Declare public variable of type float for speed;
	void Update()
	{

	}
	void OnMouseDrag()
	{

		//mouse in is screen space not world space!
		//Get new z distance from camera to object in the screen to select object
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		//get new vector3 for Mouse Input X,Y (Unused), Z(Camera-object ScreenSpace dist var)
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,distance_to_screen));

		transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
	}
}

//From: https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
