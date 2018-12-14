using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ServerDamas.Server.Interface;
using Unity;
using UnityEngine;

public static class damasClient{

    
    public static I_damas conectarCliente() {
        TcpChannel canal = new TcpChannel();
        ChannelServices.RegisterChannel(canal, false);
        I_damas obj = (I_damas)Activator.GetObject(
            typeof(I_damas), "tcp://localhost:5555/serverDamas");
        

    if (obj.Equals(null)) {
            Debug.Log("Error");
            return null;
        } else {
            return obj;
        }
    }
}
