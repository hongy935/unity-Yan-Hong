using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class BasicSerial2 : MonoBehaviour {

	private SerialPort serialPort = null;
	private String portName = "COM8";
	private int baudRate =  9600;             
	private int readTimeOut = 100; 

	public static int moveState;

	private string serialInput;

	bool programActive = true;

	public static int[] comingChunk;
	Thread thread;

	void Start () {
		try
		{
			serialPort = new SerialPort();
			serialPort.PortName = portName;
			serialPort.BaudRate = baudRate;
			serialPort.ReadTimeout = readTimeOut;   
			serialPort.Open();
		}
		catch (Exception e) {
			Debug.Log (e.Message);
		}
		thread = new Thread(new ThreadStart(ProcessData));
		thread.Start();
	}

	void ProcessData(){
		Debug.Log ("Thread: Start");
		while (programActive) {
			try {
				serialInput = serialPort.ReadLine();
			} catch (TimeoutException) {

			}
		}
		Debug.Log ("Thread: Stop");
	}

	void Update () {
		if (serialInput != null) {
			Debug.Log ("talking");
			string[] strEul = serialInput.Split (',');
			if (strEul.Length > 0) {
				
				comingChunk[0] = int.Parse (strEul [0]);

				comingChunk[1] = int.Parse (strEul [1]);


				comingChunk[2] = int.Parse (strEul [2]);
				comingChunk[3] = int.Parse (strEul [3]);
				//transport 2 values from serial to the script Done_PlayerController

			}
		}
	}

	public void OnDisable(){
		programActive = false;   
		if (serialPort != null && serialPort.IsOpen) 
			serialPort.Close ();
	}
}
