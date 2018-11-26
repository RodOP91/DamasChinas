using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class DamasCliente : MonoBehaviour {

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public void conectarCliente() {
        Socket cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3535);
        cliente.Connect(connect);
    }
}
