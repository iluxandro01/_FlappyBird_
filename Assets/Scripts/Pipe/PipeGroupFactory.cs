using UnityEngine;

public class PipeGroupFactory : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private PipeGroup _pipeGroup;
    [SerializeField] private Transform _container;
    
    public PipeGroup Create()
    {
        var pipeGroup = Instantiate(_pipeGroup, _container);
        pipeGroup.Init(_scoreHandler);
        
        return pipeGroup;
    }

    public void SetPipeGroup(PipeGroup pipeGroup)
    {
        _pipeGroup = pipeGroup;
    }
}