using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportamento de seguir o mouse pela tela.
/// </summary>
public class MouserBehavior : MonoBehaviour
{

  /// <summary>
  /// Alvo da direção do objeto.
  /// </summary>
  public GameObject target;

  /// <summary>
  /// Variável interna para armazenar aonde é a posição do alvo.
  /// Necessário pois caso <see cref="target"/> seja nulo, a posição definida será o mouse.
  /// </summary>
  private Vector3 targetPosition;

  /// <summary>
  /// Suavidade com a qual o objeto vai seguir o alvo. 0 é sem suavização e 1 é suavização completa.
  /// </summary>
  public float smoothness = 0.5f;

  void Update()
  {

    if (target == null)
    {
      targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    else
    {
      targetPosition = target.transform.position;
    }
    targetPosition.z = 0;
  }

  private void FixedUpdate()
  {
    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
  }

}
