using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject Bullet;
    public float reload = 3f;
    private float _timeToReload = 1f;
    private int _damage = 1;
    public EnemyAnimationsChanger EAC;
    private AudioSource weaponAudio;

private void Start() {
    weaponAudio = GetComponent<AudioSource>();
}

    public void Shoot(){
        if(_timeToReload <= 0){
            GameObject newBullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletScript>().setParams(transform.TransformDirection(Vector2.up), 5f, 1);
            _timeToReload = reload;
            weaponAudio.Play();
            EAC.Shoot();
        }
        else{
            _timeToReload -= Time.deltaTime;
        }
    }
}
