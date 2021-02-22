using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class PrimaryButtonEvent : UnityEvent<bool> { }
public class mqtt :M2MqttUnityClient
//public class mqtt : MonoBehaviour
{
    private List<string> eventMessages = new List<string>();
    private List<InputDevice> devicesWithPrimaryButton;
    public PrimaryButtonEvent primaryButtonPress;
    public InputDeviceCharacteristics controllerCharacteristics;
    public InputDevice RightHand;
    private bool lastButtonState = false;


    public GameObject Panel;
    public GameObject Text;
    public bool LightState = false;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        
        RightHand = devices[0];
        
        RightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue);
        
        

        Text_Pro_script Text_1;
        Text_Pro_script Text_2;
                
        Text_1 = GameObject.Find("Text_1").GetComponent<Text_Pro_script>();
        Text_2 = GameObject.Find("Text_2").GetComponent<Text_Pro_script>();

        //Text.textMesh = "";
        Text_1.TextUpdate("In MQTT's Start");
        Text_2.TextUpdate("In MQTT's Start");

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
        client.Subscribe(new string[] { "ReadDomusVR" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
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

    

    public void PublishMessage()
    {
        Text_Pro_script Text_1;

        Text_1 = GameObject.Find("Text_1").GetComponent<Text_Pro_script>();
        

        //Text.textMesh = "";
        Text_1.TextUpdate("In Publish Message");

        if (LightState)
        {
            PublishLightOff();
        }
        else
        {
            PublishLightOn();
        }
        LightState = !LightState;



        string topic = "WriteDomusVR";
        string txtPublish = "Light On !";
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(txtPublish), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    public void PublishLightOn()
    {
        string topic = "WriteDomusVR";
        string txtPublish = "1";
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(txtPublish), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }
    public void PublishLightOff()
    {
        string topic = "WriteDomusVR";
        string txtPublish = "0";
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(txtPublish), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    private void ProcessMessage(string msg)
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        RightHand = devices[0];

        RightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool PrimaryButtonValue);
        RightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool SecondaryButtonValue);


        Text_Pro_script Text_1;
        Text_Pro_script Text_2;

        Text_1 = GameObject.Find("Text_1").GetComponent<Text_Pro_script>();
        Text_2 = GameObject.Find("Text_2").GetComponent<Text_Pro_script>();
        Debug.Log("FPX Received: " + msg);

        GameObject go = GameObject.Find("MQTT_Cube");
        Debug.Log("go=" + go);

        Vector3 v = new Vector3(1.0f, 0.0f, 0.0f);
        go.transform.Translate(v,Space.World);


        Panel.SetActive(!Panel.activeSelf);
        Text.SetActive(!Text.activeSelf);

        Text_1.TextUpdate("Message reçu");

        //string Texte_affichage = "Température = " + msg +"°C";

        //Text_1.TextUpdate(Texte_affichage);
        Text_2.TextUpdate(msg);

        Text_1.TextUpdate(PrimaryButtonValue.ToString());
        Text_2.TextUpdate(SecondaryButtonValue.ToString());


        // Ajout pour publish un message a chaque fois qu'on en recoit un 

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

