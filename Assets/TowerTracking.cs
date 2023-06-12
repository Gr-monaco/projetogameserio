using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que dá o comportamento ao objeto de ficar seguindo outro objeto.
/// Caso não seja definido <see cref="target"/>, o mouse será o target.
/// </summary>
public class TowerTracking : MonoBehaviour
{

  /// <summary>
  /// Alvo da direção do objeto.
  /// </summary>
  public GameObject target;

  /// <summary>
  /// A quantidade em graus no qual o objeto deve ser rotacionado a mais.
  /// </summary>
  public int angleOffSet = 90;

  /// <summary>
  /// Variável interna para armazenar aonde é a posição do alvo.
  /// Necessário pois caso <see cref="target"/> seja nulo, a posição definida será o mouse.
  /// </summary>
  private Vector3 targetPosition;

  void Update()
  {
    //Baseado neste vídeo : https://www.youtube.com/watch?v=Geb_PnF1wOk
    if (target == null)
    {
      targetPosition = Input.mousePosition;
    }
    Vector3 dir = targetPosition - Camera.main.WorldToScreenPoint(transform.position);
    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - angleOffSet;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  }
}
