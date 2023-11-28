using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform BG1, BG2;
    public float _scrollSpeed;

    private float _bgWidth;
    void Start()
    {
        _bgWidth = BG1.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }
    void Update()
    {
        BG1.position = new Vector3(BG1.position.x - (_scrollSpeed * Time.deltaTime), BG1!.position.y, BG2.position.z);
        BG2.position -= new Vector3(_scrollSpeed * Time.deltaTime, 0f, 0f);

        if(BG1.position.x <- _bgWidth - 1)
        {
            BG1.position += new Vector3(_bgWidth * 2f, 0f, 0f);
        }
       
        if (BG2.position.x < -_bgWidth - 1)
        {
            BG2.position += new Vector3(_bgWidth * 2f, 0f, 0f);
        }
    }
}
