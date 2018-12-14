using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ServerDamas.Server.Interface;
using Assets.Scenes.Clases;

public class Ranking : MonoBehaviour {

    public Image Fondo;
    public Text nick;
    public Text puntaje;
    public Text ganadas;

    TcpClientChannel canal;
    

	// Use this for initialization
	void Start () {
        MostrarRanking();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MostrarRanking()
    {
        if (ChannelServices.RegisteredChannels.Length == 0)
        {
            Debug.Log("canal null");
            canal = new TcpClientChannel();
            ChannelServices.RegisterChannel(canal, false);
        }
        I_damas obj = (I_damas)Activator.GetObject(
            typeof(I_damas), "tcp://localhost:5555/serverDamas");

        if (obj.Equals(null))
        {
           Debug.Log("Error");
        }
        else
        {
            List<String> usuarios = obj.Ranking();
            for (int i = 0; i < usuarios.Count; i = i+3) {

                nick.text = nick.text + "\n" + usuarios[i];
                puntaje.text = puntaje.text + "\n" + usuarios[i + 1];
                ganadas.text = ganadas.text + "\n" + usuarios[i + 2];

            }
        }
    }
}
