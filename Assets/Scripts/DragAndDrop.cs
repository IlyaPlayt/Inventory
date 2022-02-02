using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Image image;
    [SerializeField] private Transform canvas;

    public void PotentialDrag()
    {
        image.color=Color.blue;
    }
    public void BeginDrag()
    {
        transform.localScale = Vector3.one * 1.3f;
    }

    public void Drag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    public void EndDrag()
    {
        transform.localScale = Vector3.one;
    }

    public void Drop()
    {
        image.color = Color.white;
    }
    
    
}
