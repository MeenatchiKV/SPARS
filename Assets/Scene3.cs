using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Net.Sockets;
using System.Text;
using UnityEngine.SceneManagement;

public class Scene3 : MonoBehaviour,IVirtualButtonEventHandler {
	private GameObject BLight,BFan,back;
	TcpClient cli = new TcpClient ();
	string str;
	int BL=0,BF=0;
	// Use this for initialization
	void Start () {

		BLight  = GameObject.Find ("BedLight");
		BLight .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		BLight.SetActive (true);
		BFan  = GameObject.Find ("BedFan");
		BFan .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		BFan.SetActive (true);
		back  = GameObject.Find ("back");
		back .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		back.SetActive (true);

		cli.Connect ("192.168.137.21", 80);

	}



	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		Debug.Log("Button Down!!");
		switch (vb.VirtualButtonName) {
		case "BedLight":
			BLight.SetActive (true);
			BFan.SetActive (true);

			if (BL == 0) {
				str = "$5";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("BedLightOn!!");
				BL = 1;
			} else {
				str = "$6";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("BedLightOff!!");
				BL = 0;
			}
			break;


		case "BedFan":
			BLight.SetActive (true);
			BFan.SetActive (true);

			if (BF == 0) {
				str = "$7";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("BedFanOn!!");
				BF = 1;
			} else {
				str = "$8";
				NetworkStream stm = cli.GetStream ();
				ASCIIEncoding asen = new ASCIIEncoding ();
				byte[] bn = asen.GetBytes (str);
				stm.Write (bn, 0, str.Length);
				Debug.Log ("BedFanOff!!");
				BF = 0;
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
