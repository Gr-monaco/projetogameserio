using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Classe que dá o comportamento ao objeto de ficar seguindo outro objeto.
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
  /// Variável que define a velocidade de rotação da torre.
  /// </summary>
  public float rotationSpeed = 5f;

  ///<summary>
  /// O valor do angulo de estabilidade. É o limite em graus no qual a diferença da posição atual
  /// da torre com o alvo a qual se considera "estabilizado".
  ///</summary>
  public float stabilityLimit = 1f;

  ///<summary>
  /// Lista de Objetos que estão dentro do raio de alcance da torre.
  ///</summary>
  public List<GameObject> insideRangeObjects;

  void Update()
  {
    if (target == null)
    {
      return;
    }

    Debug.Log(target.name);
    targetPosition = target.transform.position;
    Vector3 dir = targetPosition - transform.position;

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

  ///<summary>
  ///Determina qual é o objeto mais a esquerda da tela para definir como alvo
  ///Ainda tem que ser melhorada para permitir mais comportamentos e posição diferenet.
  ///</summary>
  private GameObject findMostLeftTarget()
  {
    if (insideRangeObjects.Count == 0)
    {
      target = null;
      return null;
    }
    GameObject mostLeftTarget = insideRangeObjects.Aggregate((minObj, obj) =>
      obj.transform.position.x < minObj.transform.position.x ? obj : minObj
    );

    target = mostLeftTarget;
    return mostLeftTarget;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    insideRangeObjects.Add(other.gameObject);
    findMostLeftTarget();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    insideRangeObjects.Remove(other.gameObject);
    findMostLeftTarget();
  }
}
