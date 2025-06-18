using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Answer : MonoBehaviour
{
    public Button send;
    public InputField inputField1;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScAmuz2OCikcCLed-eXj56xE9TXFoCLusrOQDHI5VGgXKD7mA/formResponse";

    IEnumerator Post(string a1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.513572311", a1); // 這裡對應你表單的欄位 ID

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("✅ 成功送出資料！");
        }
        else
        {
            Debug.LogError("❌ 錯誤：" + www.error);
        }
    }

    private void Update()
    {
        // 啟用或停用送出按鈕
        send.interactable = !string.IsNullOrEmpty(inputField1.text);
    }

    public void Send()
    {
        string A1 = inputField1.text;
        Debug.Log("送出內容：" + A1);
        StartCoroutine(Post(A1));
    }
}
