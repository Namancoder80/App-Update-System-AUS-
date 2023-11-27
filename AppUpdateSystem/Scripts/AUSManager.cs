using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
struct Appdata{
    public string downloadSize;
    public string version;
    public string appUrl;
}
public class AUSManager : MonoBehaviour
{
    //[AUS] stands for App Update System
    [SerializeField] private  AUSThemes AUS_Themes;
    [SerializeField] private  RawImage AUS_Background;
    [SerializeField] private  TMP_Text AUS_AppName;
    [SerializeField] private  TMP_Text AUS_DownloadSize=null;
    [SerializeField] private  TMP_Text AUS_Description;
    [SerializeField] private  Texture2D AUS_AppIcon;

    [SerializeField] private RawImage AUS_AppLogo;

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
        AUS_DownloadSize.text=($"Download size: {appdata.downloadSize}");
        if(!string.IsNullOrEmpty(appdata.version) &&!Application.version.Equals(appdata.version)){
            //app update is available
            AUS_BackgroundHolder.SetActive(true);
            SetUi(appdata.downloadSize,AUS_AppIcon,AUS_UpdateNow,AUS_CancleNow,()=>{
                //if user click on update button
                Application.OpenURL(appdata.appUrl);
                AUS_BackgroundHolder.SetActive(false);
            },()=>{
                //if user click on cancle or not now button
                AUS_BackgroundHolder.SetActive(false);
            });
        }
    }
    private void SetUi(string downloadSize,Texture GameIcon,Button UpdateNow,Button CancleNow, UnityAction Update,UnityAction Cancle){
        //setting GameIcon
        AUS_AppLogo.texture=GameIcon;
        AUS_AppName.text=Application.productName;

        UpdateNow.onClick.AddListener(()=>{
            Update();
        });
        CancleNow.onClick.AddListener(()=>{
            Cancle();
        });

        AUS_DownloadSize.text=downloadSize;
    }

    private void changeThemes(){
        AUS_DownloadSize.color= AUS_Themes.AUS_DownloadSize;
        AUS_AppName.color=AUS_Themes.AUS_AppName;
        AUS_Background.color=AUS_Themes.AUS_Background;
        AUS_Description.color=AUS_Themes.AUS_Description;
        AUS_UpdateNow.GetComponent<Image>().color=AUS_Themes.AUS_UpdateButtonColor;
        AUS_UpdateNow.GetComponentInChildren<TMP_Text>().color=AUS_Themes.AUS_UpdateTextColor;
        AUS_CancleNow.GetComponentInChildren<TMP_Text>().color=AUS_Themes.AUS_CancleText;
    }
}
