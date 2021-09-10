using UnityEngine;

public class PipeGroupFactory : MonoBehaviour
{
    [SerializeField] private PipeGroup _pipeGroup;
    [SerializeField] private Transform _container;
    
    public PipeGroup Create()
    {
        return Instantiate(_pipeGroup, _container);
    }
}