using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class mqtt :M2MqttUnityClient
//public class mqtt : MonoBehaviour
{
    private List<string> eventMessages = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mqtt Start()");
        base.Start();
        Debug.Log("base.Start() done");
        base.OnConnecting();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */

    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { "test1" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    protected override void Update()
    {
        base.Update(); // call ProcessMqttEvents()

        if (eventMessages.Count > 0)
        {
            foreach (string msg in eventMessages)
            {
                ProcessMessage(msg);
            }
            eventMessages.Clear();
        }
    }

    private void ProcessMessage(string msg)
    {
        Debug.Log("FPX Received: " + msg);

        GameObject go = GameObject.Find("Cylinder");
        Debug.Log("go=" + go);

        Vector3 v = new Vector3(1.0f, 0.0f, 0.0f);
        go.transform.Translate(v,Space.World);
    }

    private void StoreMessage(string eventMsg)
    {
        eventMessages.Add(eventMsg);
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        string msg = System.Text.Encoding.UTF8.GetString(message);
        Debug.Log("Received: " + msg);
        StoreMessage(msg);
    }
}
