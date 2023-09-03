using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public Button getIpAdressButton;
   public TMP_Text ipText;
   private static UIManager _instance;

   public static UIManager Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = FindObjectOfType<UIManager>();

            if (_instance == null)
            {
               GameObject obj = new GameObject("UIManager");
               _instance = obj.AddComponent<UIManager>();
            }
         }
         return _instance;
      }
   }
   private void Awake()
   {
      // Ensure there's only one instance of UIManager
      if (_instance != null && _instance != this)
      {
         Destroy(this.gameObject);
         return;
      }
      _instance = this;
      DontDestroyOnLoad(this.gameObject);
   }
}
