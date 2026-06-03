using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    
    Vector2 offset;

    Material backgroundMaterial;

    private void Start()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset += moveSpeed * Time.deltaTime;

        backgroundMaterial.mainTextureOffset = offset;
    }
}
