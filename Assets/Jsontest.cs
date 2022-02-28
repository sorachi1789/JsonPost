using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;


public class Jsontest : MonoBehaviour
{
    public GameObject CountButton;
    Count count;

    [System.Serializable]
    public class AccountRegistrationJson
    {
        public string tap;
    }

    public AccountRegistrationJson AccountRegistrationData = new AccountRegistrationJson();

    void Start()
    {
        count = CountButton.GetComponent<Count>();
    }

    public void OnClick()
    {
        AccountRegistrationData.tap = count.count.ToString();
        string jsonstr = JsonUtility.ToJson(AccountRegistrationData);
        Debug.Log(jsonstr);

        StartCoroutine(PostJson("https://jtkcokh9xe.execute-api.ap-northeast-1.amazonaws.com/default/python-put-test", jsonstr));

        count.count = 0;
    }

    IEnumerator PostJson(string url, string jsonstr)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonstr);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        Debug.Log("Status Code: " + request.responseCode);
    }

}