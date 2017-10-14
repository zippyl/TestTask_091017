using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    #region
    [SerializeField] private float _speed = 5f;
    private Vector3 _targetPos = Vector3.zero;
    [SerializeField] private float _maxAliveTime = 5;
    private float _aliveTime = 0;
    #endregion

    void Update()
    {
        if (_targetPos != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }


        _aliveTime += Time.deltaTime;
        if (_aliveTime > _maxAliveTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            FindObjectOfType<PlayerController>().UpdateKC();
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
