using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundMover : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   private RawImage _image;
   private float _imagePositionX;

   private void Start()
   {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
   }

   private void Update()
   {
        _imagePositionX += _moveSpeed * Time.deltaTime;
        _image.uvRect = new Rect(_imagePositionX, 0, 1, 1);
   }
}
