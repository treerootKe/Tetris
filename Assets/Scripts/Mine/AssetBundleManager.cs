using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class AssetBundleManager : MonoBehaviour
{
    public string assetBundleName; // AssetBundle������
    public string assetName; // Ҫ���ص�Texture������

    private AssetBundle assetBundle;

    void Start()
    {
        assetBundleName = "tetris"; // AssetBundle������
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
        // ����AssetBundle
        assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + assetBundleName);
        if (assetBundle == null)
        {
            Debug.LogError("Failed to load asset bundle!");
            return;
        }

        // ��AssetBundle�м���Texture
        LoadTexture();
    }

    void LoadTexture()
    {
        // ��AssetBundle�м���Texture
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
        // ж��AssetBundle
        if (assetBundle != null)
        {
            assetBundle.Unload(false);
        }
    }
}