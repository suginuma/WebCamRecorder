using UnityEngine;
using UnityEngine.UI;

public class WebCameraTest : MonoBehaviour {

    public RawImage rawImage;

    WebCamTexture webCamTexture;
    WebCamDevice[] webCamDevice; /* 追加１ */
    int selectCamera = 0; /* 追加 ２*/

    void Start () {
        webCamTexture = new WebCamTexture();
        webCamDevice = WebCamTexture.devices; /* 追加３ */
        rawImage.texture = webCamTexture;
        webCamTexture.Play();
	}

    public void ChangeCamera() /* 追加４ */
    {
        int cameras = webCamDevice.Length; //カメラの個数
        if ( cameras < 1) return; // カメラが1台しかなかったら実行せず終了

        selectCamera++;
        if (selectCamera >= cameras) selectCamera = 0;

        webCamTexture.Stop(); // カメラを停止
        webCamTexture = new WebCamTexture(webCamDevice[selectCamera].name); //カメラを変更
        rawImage.texture = webCamTexture; 
        webCamTexture.Play(); // 別カメラを開始
    }
}
