using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class CompilerMessenger : MonoBehaviour
{
  // Use this for initialization
  void Start()
  {
    SetupClient();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetupClient()
  {
    var ws = new WebSocket("ws://localhost:5050");
    ws.OnMessage += (sender, e) =>
      Debug.Log("Recieved from Server: " + e.Data);
    ws.Connect();
    ws.Send("Connected from Unity!");
  }
}
