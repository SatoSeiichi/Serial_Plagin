using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SerialHandler> ().SerialCallBack = callback;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void callback(string s)
	{
		Debug.Log (s);
	}
}
