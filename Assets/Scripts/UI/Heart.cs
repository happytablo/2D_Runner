using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
