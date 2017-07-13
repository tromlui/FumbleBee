using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public Text directionText;
	public GameObject winText;

	private int count = 0;

	public Light sun;

	private Quaternion currentAngle;
	public Quaternion rotateAngle;

	public float smoothTime;

	public float rotateSpeed;

	CharacterController cc;

	void Start () {
		currentAngle = sun.transform.rotation;
		cc = GetComponent<CharacterController> ();
		directionText.text = "";
	}

	void Update () {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");


		cc.Move (new Vector3 (horizontal, 0f, vertical) * speed);
	}

	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "hive") {
			if (count == 0) {
				directionText.text = "The buttercupzzzz are to the north.";
			}
			if (count == 1) {
				directionText.text = "The daizzziezzz are zzzomewehere to the wezzzt.";
			}
			if (count == 2) {
				directionText.text = "The rozzzezzz grow to the eazzzt.";
			}
			if (count == 3) {
				directionText.text = "";
				speed = 0;
				winText.SetActive (true);
			}
		}

		if (Other.tag == "buttercup") {
			if (count == 0) {
				count++;
				sun.transform.Rotate (45, 0, 0);
				//RotateSun ();
				//currentAngle = new Vector3 (Mathf.LerpAngle (currentAngle.x, rotateAngle.x, Time.deltaTime), 0, 0);
				//Debug.Log ("Sun is rotating");
				//transform.eulerAngles = currentAngle;
				/*
				sun.transform.rotation = Quaternion.Lerp (currentAngle, rotateAngle, Time.deltaTime * rotateSpeed);
				Debug.Log ("Sun is rotating");
				currentAngle = sun.transform.rotation;
				*/

				directionText.text = "Daizzziezzz next...they're zzzouth...and wezzzt.";
			}
			if (count == 1) {
				directionText.text = "Daizzziezzz next...they're zzzouth...and wezzzt.";
			}
			if (count == 2) {
				directionText.text = "The rozzzezzz are zzzouth and eazzzt from here.";
			}
			if (count == 3) {
				directionText.text = "Getting zzzleepy...I should go back to the hive...";
			}
		}

		if (Other.tag == "daisy") {
			if (count == 0) {
				directionText.text = "The buttercupzzz are north and eazzzt from here.";
			}
			if (count == 1) {
				count++;
				sun.transform.Rotate (45, 0, 0);
				//RotateSun ();
				directionText.text = "I should go to the rozzzezzz. Eazzzt, pazzzt the hive.";
			}
			if (count == 2) {
				directionText.text = "I should go to the rozzzezzz. Eazzzt, pazzzt the hive.";
			}
			if (count == 3) {
				directionText.text = "Getting zzzleepy...I should go back to the hive...";
			}
		}

		if (Other.tag == "rose") {
			if (count == 0) {
				directionText.text = "The buttercupzzz are north and wezzzt from here.";
			}
			if (count == 1) {
				directionText.text = "Daizzziezzz grow to the zzzunzzzet, pazzzt the hive.";
			}
			if (count == 2) {
				count++;
				sun.transform.Rotate (45, 0, 0);
				//RotateSun ();
				directionText.text = "Getting zzzleepy...I should go back to the hive...";
			}
			if (count == 3) {
				directionText.text = "Getting zzzleepy...I should go back to the hive...";
			}
		}
	}

	/*
	IEnumerator RotateSun () {
		yield return new WaitForSeconds (0.25f);

		float t = 0;

		while (sun.transform.rotation != rotateAngle) {
			t += smoothTime / 100;
			sun.transform.rotation = Quaternion.Lerp (currentAngle, rotateAngle, t * rotateSpeed);
			Debug.Log ("Sun is rotating");
			yield return null;
		}

		currentAngle = sun.transform.rotation;
	}
	*/
}
