using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    
    public float scrollSpeed = 0.8f;
    private float offSet;
    private Material mat;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offSet,0));
    }
}
