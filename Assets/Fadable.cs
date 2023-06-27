using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fadable : MonoBehaviour
{

  [SerializeField] private CanvasGroup canvasGroup;

  // Start is called before the first frame update
  void Start()
  {
    if (canvasGroup != null)
    {
      canvasGroup.alpha = 0;
    }
  }

  // Update is called once per frame
  void Update()
  {

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
