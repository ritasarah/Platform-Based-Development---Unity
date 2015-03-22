using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private bool isForce;
	private Vector3 fc;
	
	// Use this for initialization
	void Start () {
		isForce = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isForce){
			isForce = false;
			GetComponent<Rigidbody>().AddForce(fc);
			//Debug.Log(fc.x+" "+fc.y+" "+fc.z);
		}
	}
	
	void OnCollisionEnter(Collision col){
		UnityChan.UnityChanControlScriptWithRgidBody un;
		if ((un = col.collider.gameObject.GetComponent<UnityChan.UnityChanControlScriptWithRgidBody>()) != null){
			float mul = 100f;
			fc = (new Vector3(mul*(GetComponent<Rigidbody>().position.x-un.GetComponent<Rigidbody>().position.x),
			                               0,//mul * (rigidbody.position.y-un.rigidbody.position.y),
			                               mul * (GetComponent<Rigidbody>().position.z-un.GetComponent<Rigidbody>().position.z)
			));
			isForce = true;
		}
	}
	
}
