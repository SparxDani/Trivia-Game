using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerBG : MonoBehaviour
{
    [SerializeField] private RawImage image_BG;
    [SerializeField] private float _x, _y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image_BG.uvRect = new Rect(image_BG.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, image_BG.uvRect.size);
    }
}
