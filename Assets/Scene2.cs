using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Net.Sockets;
using System.Text;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour,IVirtualButtonEventHandler {
	private GameObject HLight,HFan,back;
	TcpClient cli = new TcpClient ();
	string str;
	int HL=0,HF=0;
	// Use this for initialization
	void Start () {
		
		HLight  = GameObject.Find ("HallLight");
		HLight .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		HLight.SetActive (true);
		HFan  = GameObject.Find ("HallFan");
		HFan .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		HFan.SetActive (true);
		back  = GameObject.Find ("back");
		back .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		back.SetActive (true);

		cli.Connect ("192.168.137.21", 80);
	}
	


	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		Debug.Log("Button Down!!");
		switch (vb.VirtualButtonName) {
		case "HallLight":
			HLight.SetActive (true);
			HFan.SetActive (true);

			if (HL == 0) {
				str = "$1";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("HallLightOn!!");
				HL = 1;
			} else {
				str = "$2";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("HallLightOff!!");
				HL = 0;
			}
			break;


		case "HallFan":
			HLight.SetActive (true);
			HFan.SetActive (true);

			if (HF == 0) {
				str = "$3";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("HallFanOn!!");
				HF = 1;
			} else {
				str = "$4";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("HallFanOff!!");
				HF = 0;
			}
			break;

		case "back":
			SceneManager.LoadScene ("SCENE");

			Debug.Log ("Hall!!");

			break;


		
		}
}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { 
		Debug.Log("Button released!");
	}
}
