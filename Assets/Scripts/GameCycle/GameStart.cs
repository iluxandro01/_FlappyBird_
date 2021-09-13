using UnityEngine;

public class GameStart : MonoBehaviour
{
   [SerializeField] private ClickZone _clickZone;
   [SerializeField] private Bird _bird;
   [SerializeField] private Fader _fader;
   [SerializeField] private PipeGroupSpawner _pipeGroupSpawner;

   private void Start()
   {
      _clickZone.ONClicked += StartGame;
   }

   private void StartGame()
   {
      _clickZone.ONClicked -= StartGame;
      
      _bird.OnStartGame();
      _fader.FadeIn();
      _pipeGroupSpawner.StartSpawner();
   }
   
}
