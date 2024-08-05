/*
 * Simulates a network request to a server.
 */
using System;
using System.Collections;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class NetworkResponse
    {
        public bool isSuccess;
        public long responseCode;
        public string data;

        public NetworkResponse(long responseCode)
        {
            this.responseCode = responseCode;
        }
    }
    
    public class NetworkManager : MonoBehaviour
    {
        private static NetworkManager instance;
        public static NetworkManager Instance { get => instance; }

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        
        public Coroutine StartWebRequest<T>(string url, Action<NetworkResponse> response)
        {
            return StartCoroutine(WebRequest<T>(url, response));
        }

        private IEnumerator WebRequest<T>(string url, Action<NetworkResponse> response)
        {
            yield return new WaitForSeconds(0.01f);
            var networkResponse = new NetworkResponse(200);
            networkResponse.isSuccess = true;
            networkResponse.data = "Some data";
            response?.Invoke(networkResponse);
        }
    }
}