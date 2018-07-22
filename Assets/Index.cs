using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Net.Sockets;
using System.Text;
public class Index : MonoBehaviour,IVirtualButtonEventHandler {
	private GameObject HallButt,BedButt,HLight,HFan,BLight,BFan;
	TcpClient cli = new TcpClient ();
	string str;
	int HL=0,HF=0,BL=0,BF=0;


	// Use this for initialization
	void Start () {
		HallButt  = GameObject.Find ("Hall").gameObject;
		HallButt .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		HallButt .SetActive (true);
		BedButt  = GameObject.Find ("BedRoom");
		BedButt .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		BedButt .SetActive (true);
		HLight  = GameObject.Find ("HallLight");
		HLight .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		HLight.SetActive (false);
		HFan  = GameObject.Find ("HallFan");
		HFan .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		HFan.SetActive (false);
		BLight  = GameObject.Find ("BedLight");
		BLight .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		BLight.SetActive (false);
		BFan  = GameObject.Find ("BedFan");
		BFan .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		BFan.SetActive (false);

		cli.Connect ("172.16.16.187", 80);

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		Debug.Log("Button Down!!");
		switch (vb.VirtualButtonName) {
		case "Hall":
			HallButt.SetActive (false);
			BedButt.SetActive (false);
			HLight.SetActive (true);
			HFan.SetActive (true);
			//Destroy (HallButt);
			//Destroy (BedButt);

			BLight.SetActive (false);
			BFan.SetActive (false);
			Debug.Log ("Hall!!");

			break;
		case "BedRoom":

			HallButt.SetActive (false);
			BedButt.SetActive (false);
			BLight.SetActive (true);
			BFan.SetActive (true);
			//Destroy (HallButt);
			//Destroy (BedButt);
			HLight.SetActive (false);
			HFan.SetActive (false);


			Debug.Log ("BedRoom!!");
			break;

		case "HallLight":
			HLight.SetActive (true);
			HFan.SetActive (true);
			BLight.SetActive (false);
			BFan.SetActive (false);
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
			BLight.SetActive (false);
			BFan.SetActive (false);
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


		case "BedLight":
			BLight.SetActive (true);
			BFan.SetActive (true);
			HLight.SetActive (false);
			HFan.SetActive (false);
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
			HLight.SetActive (false);
			HFan.SetActive (false);
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

		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { 
		Debug.Log("Button released!");
	}
}
