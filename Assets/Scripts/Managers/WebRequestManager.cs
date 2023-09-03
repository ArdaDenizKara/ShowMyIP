using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestManager : MonoBehaviour
{
    private static WebRequestManager instance;
    public static WebRequestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<WebRequestManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("WebRequestManager");
                    instance = go.AddComponent<WebRequestManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public IEnumerator GetRequest(string endpoint,Action<string>callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(endpoint))
        {
            yield return request.SendWebRequest();

            //  request Error Check.
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError($"HTTP Error: {request.responseCode} - {request.error}");
            }
            else
            {
                string response = request.downloadHandler.text;
                callback(response);
                Debug.Log(response);
            }

        
        
        }
    }
}