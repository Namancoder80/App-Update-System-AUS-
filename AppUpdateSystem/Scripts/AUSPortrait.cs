using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.Events;

public class AUSPortrait : MonoBehaviour
{
     //[AUS] stands for App Update System
    [SerializeField] private  AUSThemes AUS_Themes;
    [SerializeField] private  RawImage AUS_Background;
    [SerializeField] private  TMP_Text AUS_AppName;
    [SerializeField] private  TMP_Text AUS_Description;
    [SerializeField] private Button AUS_UpdateNow;
    [SerializeField] private Button AUS_CancleNow;

    [SerializeField] private GameObject AUS_BackgroundHolder;

    [TextArea(5,20)]
    [SerializeField] string Serverurl;

     private void Start() {
        changeThemes();
        StartCoroutine(CheckAppUpdate(Serverurl));
    }

    IEnumerator CheckAppUpdate(string url){
       
        UnityWebRequest unityWebRequest= UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();
        Appdata appdata= JsonUtility.FromJson<Appdata>(unityWebRequest.downloadHandler.text);
        if(!string.IsNullOrEmpty(appdata.version) &&!Application.version.Equals(appdata.version)){
            //app update is available
            AUS_BackgroundHolder.SetActive(true);
            SetUi(AUS_UpdateNow,AUS_CancleNow,()=>{
                //if user click on update button
                Application.OpenURL(appdata.appUrl);
                AUS_BackgroundHolder.SetActive(false);
            },()=>{
                //if user click on cancle or not now button
                AUS_BackgroundHolder.SetActive(false);
            });
        }
    }
    private void SetUi(Button UpdateNow,Button CancleNow, UnityAction Update,UnityAction Cancle){
        //setting GameIcon
        
        AUS_AppName.text=($"Updated {Application.productName}?");

        AUS_Description.text=($"{Application.productName} recommends that you update to the latest version you can keep playing the game while downloading the update");

        UpdateNow.onClick.AddListener(()=>{
            Update();
        });
        CancleNow.onClick.AddListener(()=>{
            Cancle();
        });

        
    }
    private void changeThemes(){
        AUS_AppName.color=AUS_Themes.AUS_AppName;
        AUS_Background.color=AUS_Themes.AUS_Background;
        AUS_Description.color=AUS_Themes.AUS_Description;
        AUS_UpdateNow.GetComponent<Image>().color=AUS_Themes.AUS_UpdateButtonColor;
        AUS_UpdateNow.GetComponentInChildren<TMP_Text>().color=AUS_Themes.AUS_UpdateTextColor;
        AUS_CancleNow.GetComponentInChildren<TMP_Text>().color=AUS_Themes.AUS_CancleText;
    }

}
