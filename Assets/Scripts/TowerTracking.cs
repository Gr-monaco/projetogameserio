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

  /// <summary>
  /// Variavel que define a velocidade de rotação da torre.
  /// </summary>
  public float rotationSpeed = 5f;

  ///<summary>
  /// O valor do angulo de estabilidade. É o limite em graus no qual a diferença da posição atual
  /// da torre com o alvo a qual se considera "estabilizado".
  ///</summary>
  public float stabilityLimit = 1f;

  void Update()
  {
    if (target == null)
    {
      targetPosition = Input.mousePosition;
    }
    Vector3 dir = targetPosition - Camera.main.WorldToScreenPoint(transform.position);

    //representa a rotação desejada para que o objeto atual olhe na direção do objeto alvo
    Vector3 targetDirection = new Vector3(dir.x, dir.y, 0f);

    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);

    //armazena a diferença angular em graus entre a rotação atual do objeto e a rotação desejada
    float diferencaAnglo = Quaternion.Angle(transform.rotation, targetRotation);

    if (diferencaAnglo > stabilityLimit)
    {
      transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    else
    {
      transform.rotation = targetRotation;
    }
  }
}
