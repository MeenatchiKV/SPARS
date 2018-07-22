using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Net.Sockets;
using System.Text;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour,IVirtualButtonEventHandler {
	private GameObject HallButt,BedButt;
	TcpClient cli = new TcpClient ();
	string str;
	//int HL=0,HF=0,BL=0,BF=0;


	// Use this for initialization
	void Start () {
		HallButt  = GameObject.Find ("Hall").gameObject;
		HallButt .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		HallButt .SetActive (true);
		BedButt  = GameObject.Find ("BedRoom");
		BedButt .GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		BedButt .SetActive (true);


		cli.Connect ("192.168.137.21", 80);

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		Debug.Log ("Button Down!!");
		switch (vb.VirtualButtonName) {
		case "Hall":
			SceneManager.LoadScene ("Scene2A");

			Debug.Log ("Hall!!");

			break;
		case "BedRoom":

			SceneManager.LoadScene ("Scene3A");


			Debug.Log ("BedRoom!!");
			break;

		
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { 
		Debug.Log("Button released!");
	}
}

