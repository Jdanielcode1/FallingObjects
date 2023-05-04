using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using System;
using TMPro;

public class login : MonoBehaviour
{
    TMP_InputField loginFistName;
    TMP_InputField loginLastName;
    TMP_InputField loginPassword;

    [Serializable]
    public class PlayerUser
    {
        public int id;
        public string password_hash;
        public string firstname;
        public string lastname;
        public string manager;
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            Debug.Log(wrapper.Items);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

    string wrapJson(string json) 
    {
        json = "{ \"Items\":"+ json + " }";
        return json;
    }

    // Start is called before the first frame update
    void Start()
    {
        loginFistName = GameObject.Find("loginFirstName").GetComponent<TMP_InputField>();
        Debug.Log("HERE");
        Debug.Log(loginFistName);
        
        loginLastName = GameObject.Find("loginLastName").GetComponent<TMP_InputField>();
        loginPassword = GameObject.Find("loginPassword").GetComponent<TMP_InputField>();
        
        GameObject.Find("loginButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    void GetData() => StartCoroutine(GetData_coroutine());

    IEnumerator GetData_coroutine()
    {
        string uri = "https://info-api.herokuapp.com/player_user/";
        using (UnityWebRequest request =  UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                var text = request.downloadHandler.text;
                var json = wrapJson(text);
                //Debug.Log(json);
                PlayerUser[] players = JsonHelper.FromJson<PlayerUser>(json);
                Debug.Log(loginFistName.text);
                foreach (PlayerUser p in players ) 
                {
                    
                    
                    /*
                    Debug.Log(loginFistName.text);
                    if (p.lastname == loginLastName.text && p.firstname == loginFistName.text && p.password_hash == loginPassword.text)
                    {
                        Debug.Log("si se pudo");
                    }
                    else
                    {
                        Debug.Log("nose ");
                    }
                    */
                   
                }

            }
        }
    }

}