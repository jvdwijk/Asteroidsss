using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {


	public Dictionary<string, KeyCode> inputs = new Dictionary<string, KeyCode> ();
	float horizontal, vertical;

	void Start(){
		inputs.Add ("pauzeButton", KeyCode.Escape); 
		inputs.Add ("shootButton", KeyCode.Space);
		inputs.Add ("reloadButton", KeyCode.R);
		inputs.Add ("forwardButton", KeyCode.W);
		inputs.Add ("leftButton", KeyCode.A);
		inputs.Add ("breakButton", KeyCode.S);
		inputs.Add ("rightButton", KeyCode.D);
		inputs.Add ("watchBehindButton", KeyCode.LeftShift);
	}
		
	public void ChangeKey(string key){
		StartCoroutine (checkkey(key));
	}

	void Update() {

		if (Input.GetKey (inputs["leftButton"]) && !Input.GetKey (inputs["rightButton"])) {
			if (horizontal <= 1) {
				horizontal -= Time.deltaTime * 3;
			}
		} else if (Input.GetKey (inputs["rightButton"]) && !Input.GetKey (inputs["leftButton"])) {
			if (horizontal >= -1) {
				horizontal += Time.deltaTime * 3;
			}
		} else {
			horizontal = Mathf.Lerp (0, horizontal, Time.deltaTime * 3);
		}

		if (Input.GetKey (inputs ["forwardButton"]) && !Input.GetKey (inputs ["breakButton"])) {
			if (vertical <= 1) {
				vertical += Time.deltaTime * 3;
			}
		} else if (Input.GetKey (inputs["breakButton"]) && !Input.GetKey (inputs["forwardButton"])) {
			if (vertical >= -1) {
				vertical -= Time.deltaTime * 3;
			}
		} else {
			vertical = Mathf.Lerp (0, vertical, Time.deltaTime * 3);
		}

		horizontal = Mathf.Clamp (horizontal, -1, 1);
		vertical = Mathf.Clamp (vertical, -1, 1);
	}

	public float GetAxis(string axis) {
		switch (axis) {
		case "horizontal":
			return horizontal;
			break;
		case "vertical":
			return vertical;
			break;
		default:
			return 0;
			break;
		}
	}

	IEnumerator checkkey(string key){
		yield return new WaitUntil (() => (FetchKey () != KeyCode.None));
		inputs[key] = FetchKey();
	}

	KeyCode FetchKey()
	{
		int e = System.Enum.GetNames (typeof(KeyCode)).Length;
		for (int i = 0; i < e; i++) {
			if (Input.GetKey ((KeyCode)i)) {
				return (KeyCode)i;
			}
		}

		return KeyCode.None;
	}

}
