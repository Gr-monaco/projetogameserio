using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fadable : MonoBehaviour
{

  ///<summary>
  ///CanvasGroup do elemento de UI que sofrerá fade in ou fade out
  ///em caso do mouse sair e entrar do objeto.
  ///</summary>
  [SerializeField] private CanvasGroup canvasGroup;

  void Start()
  {
    if (canvasGroup != null)
    {
      canvasGroup.alpha = 0;
    }
  }

  private void OnMouseEnter()
  {
    canvasGroup.alpha = 1;
  }

  private void OnMouseExit()
  {
    canvasGroup.alpha = 0;
  }
}
