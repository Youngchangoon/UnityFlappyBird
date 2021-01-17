using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GroundScroll : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
