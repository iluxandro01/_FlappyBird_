using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SwitchImage : MonoBehaviour
{
    [SerializeField] private Sprite _initialSprite;
    [SerializeField] private Sprite _toSwitchSprite;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Switch()
    {
        if (_image.sprite == _initialSprite)
        {
            _image.sprite = _toSwitchSprite;
        }
        else
        {
            _image.sprite = _initialSprite;
        }
    }
}