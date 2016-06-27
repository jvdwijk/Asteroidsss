using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScreen : MonoBehaviour {
	[SerializeField]
	private Text Movements;
	[SerializeField]
	private Text MovementsDesc;
	[SerializeField]
	private Text Shooting;
	[SerializeField]
	private Text ShootingDesc;
	[SerializeField]
	private Text Camera;
	[SerializeField]
	private Text CameraDesc;
	[SerializeField]
	private InputHandler input;

	void Update () {
		UpdateText();
	}

	void UpdateText () {
		Movements.text = "[" + input.inputs["forwardButton"] + "]" +
			"\n" +
			"[" + input.inputs["leftButton"] + "]" +
			"[" + input.inputs["breakButton"] + "]" +
			"[" + input.inputs["rightButton"] + "]";

		Shooting.text = "[" + input.inputs["shootButton"] + "] " +
			"[" + input.inputs["reloadButton"] + "]";
		
		Camera.text = "[" + input.inputs["watchBehindButton"] + "]";

		MovementsDesc.text = "Use " + "[" + input.inputs["forwardButton"] + "] " + "[" + input.inputs["leftButton"] + "] " + "[" + input.inputs["rightButton"] + "] " +
			"to move around and " + "[" + input.inputs["breakButton"] + "] " + "to slow down";

		MovementsDesc.text = "Use " + "[" + input.inputs["forwardButton"] + "] " + "[" + input.inputs["leftButton"] + "] " + "[" + input.inputs["rightButton"] + "] " +
			"to move around and " + "[" + input.inputs["breakButton"] + "] " + "to slow down";

		ShootingDesc.text = "Use " + "[" + input.inputs["shootButton"] + "] " + "to shoot and " + "[" + input.inputs["reloadButton"] + "] " + "to reload";

		CameraDesc.text = "Use " + "[" + input.inputs["watchBehindButton"] + "] " + "to look behind";
	}
}
