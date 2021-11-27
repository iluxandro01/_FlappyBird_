using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Space(10)] 
    [SerializeField] private Pauser _pauser;
    [SerializeField] private SwitchableImage _switchableImage;

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchState);
    }

    private void SwitchState()
    {
        _pauser.ChangeState();
        _switchableImage.Switch();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchState);
    }
}