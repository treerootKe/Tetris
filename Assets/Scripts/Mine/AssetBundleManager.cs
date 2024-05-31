using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class AssetBundleManager : MonoBehaviour
{
    public string assetBundleName; // AssetBundle的名称
    public string assetName; // 要加载的Texture的名称

    private AssetBundle assetBundle;

    void Start()
    {
        assetBundleName = "tetris"; // AssetBundle的名称
        assetName = "MainTetris";
#if UNITY_EDITOR
        GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Tetris Assets/Prefabs/MainTetris.prefab", typeof(GameObject));
        Object.Instantiate(prefab);
#else
        LoadAssetBundle();
#endif
    }

    void LoadAssetBundle()
    {
        // 加载AssetBundle
        assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + assetBundleName);
        if (assetBundle == null)
        {
            Debug.LogError("Failed to load asset bundle!");
            return;
        }

        // 从AssetBundle中加载Texture
        LoadTexture();
    }

    void LoadTexture()
    {
        // 从AssetBundle中加载Texture
        Texture2D texture = assetBundle.LoadAsset<Texture2D>(assetName);
        GameObject prefab = assetBundle.LoadAsset<GameObject>(assetName);
        Object.Instantiate(prefab);
        //if (texture != null)
        //{
        //    transform.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        //}
        //else
        //{
        //    Debug.LogError("Failed to load texture from asset bundle!");
        //}
    }

    void OnDestroy()
    {
        // 卸载AssetBundle
        if (assetBundle != null)
        {
            assetBundle.Unload(false);
        }
    }
}