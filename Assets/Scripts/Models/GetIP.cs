using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetIP : MonoBehaviour
{
    private string endPoint = "https://api.ipify.org?format=json";
    private void Start()
    {
        UIManager.Instance.getIpAdressButton.onClick.AddListener(GetIPFromAPI);
        UIManager.Instance.ipText.text = "Click here to see your IP Address ";
    }
    public void GetIPFromAPI()
    {
        StartCoroutine(FetchIP());
    }
    private IEnumerator FetchIP()
    {
        yield return StartCoroutine(WebRequestManager.Instance.GetRequest(endPoint, (result) =>
        {
                IPModel response = JsonConvert.DeserializeObject<IPModel>(result);
                if (response != null && response.ip != null)
                {
                    UIManager.Instance.ipText.text = "IP Address: " + response.ip;
                }
        }));
    }
}