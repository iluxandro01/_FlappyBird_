using UnityEngine;

public class PipeGroupFactory : MonoBehaviour
{
    [SerializeField] private PipeGroup _pipeGroup;

    public PipeGroup Create()
    {
        return Instantiate(_pipeGroup);
    }
}