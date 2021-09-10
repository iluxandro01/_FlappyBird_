using System;
using UnityEngine;
using UnityEngine.Events;

public class GameCycle : MonoBehaviour
{
   [SerializeField] private ClickZone _clickZone;
   [SerializeField] UnityEvent _onStartGame;

   public event Action ONStartGame;

   private void Start()
   {
      _clickZone.ONClicked += StartGame;
   }

   private void StartGame()
   {
      _clickZone.ONClicked -= StartGame;
      ONStartGame?.Invoke();
      _onStartGame?.Invoke();
   }

   private void OnDestroy()
   {
      _clickZone.ONClicked -= StartGame;
   }
}
