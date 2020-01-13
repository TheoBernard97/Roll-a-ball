using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int speed = 500;
	public int count;
	public GUIText countText;

	// Use this for initialization
	void Start () 
	{
		count = 0;
		SetCountText();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float mouveHorizontal = Input.GetAxis ("Horizontal");
		float mouveVertical = Input.GetAxis ("Vertical");

		Vector3 mouvement = new Vector3(mouveHorizontal, 0, mouveVertical);
		GetComponent<Rigidbody>().AddForce(mouvement * speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Cube") {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		} else if (other.gameObject.tag == "Killzone") {
			Application.LoadLevel (1);
		} else if (other.gameObject.tag == "Killzone2") {
			Application.LoadLevel (3);
		} else if (other.gameObject.tag == "Killzone3") {
			Application.LoadLevel (4);
		} else if (other.gameObject.tag == "Killzone4") {
			Application.LoadLevel (5);
		} else if (other.gameObject.tag == "Killzone5") {
			Application.LoadLevel (6);
		}

	}
	void SetCountText()
	{
		countText.text = "Score : " + count.ToString ();

		if(count >= 10)
		{
			Application.LoadLevel (2);
		}
	}
}