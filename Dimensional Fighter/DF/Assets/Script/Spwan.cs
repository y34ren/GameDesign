using UnityEngine;
using System.Collections;

public class Spwan : MonoBehaviour {

    [SerializeField]
    private GameObject[] EnemyModle;
    [SerializeField]
    private GameObject[] BulletModle;
    [SerializeField]
    public int level = 0;

    public bool playing = false;

    private bool isSpwan = false;
    private int spwanPoint = 0;
    private int timer = 0;
    private int enemySum = 0;

    private const int sumSpwan = 4;
    private const int spwanInterval = 15;

    //Growth factors
    private const float enemyNumber = 1.5f;
    private const float enemyHealth = 1.1f;
    private const float enemySpeed = 1.1f;
    private const float bulletNumber = 1.25f;
    private const float bulletPower = 1.15f;
    private const float bulletSpeed = 1.2f;
    private const float attackInterval = 1.1f;

    public void initialization() {
        playing = false;
        isSpwan = false;
        level = 0;
        spwanPoint = 0;
        timer = 0;
        enemySum = 0;
    }

    // Use this for initialization
    void Start() {
        initialization();
    }

    // Update is called once per frame
    void Update() {
        if (playing) {
            if (spwanPoint == 0) isSpwan = searchEnemy();
            if (!isSpwan) {
                if (timer > 100) {
                    setSpwan();
                    isSpwan = true;
                }
                else timer++;
            }
            else {
                switch (spwanPoint) {
                    case 1:
                        spwanPoint_1();
                        break;
                    case 2:
                        spwanPoint_2();
                        break;
                    case 3:
                        spwanPoint_3();
                        break;
                    case 4:
                        spwanPoint_4();
                        break;
                    case 5:
                        spwanPoint_5();
                        break;
                }
            }
        }
        else {
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }
    }

    //check if any enemy on screem
    bool searchEnemy() {
        return transform.childCount > 0;
    }

    //random a spwan to run
    void setSpwan() {
        level++;
        enemySum = 0;
        timer = 0;
        spwanPoint = Random.Range(1, sumSpwan + 1);
    }

    void spwanPoint_1() {
        if (timer == spwanInterval * enemySum) {
            enemySum++;
            //================================ spwan enemy ================================\\
            //set position and rotation and layer
            Vector3 pos = new Vector3(Random.Range(-14f, 14f), Random.Range(-9f, 9f), 5f);
            GameObject Enemy1 = Instantiate(EnemyModle[9], pos, Quaternion.Euler(Vector3.zero)) as GameObject;
            Enemy1.transform.parent = transform;
            //set entety
            Entety ent = Enemy1.GetComponent<Entety>();
            ent.Health = 9f * Mathf.Pow(enemyHealth, level);
            ent.Modle = false;
            //set enemy movement
            EnemyMovement em = Enemy1.GetComponent<EnemyMovement>();
            em.MoveType = 1;
            em.Speed = 5f * Mathf.Pow(enemySpeed, level);
            //set bullet
            BulletBehavior bb = BulletModle[0].GetComponent<BulletBehavior>();
            bb.Speed = 2.5f * Mathf.Pow(bulletSpeed, level);
            bb.Power = 0.5f * Mathf.Pow(bulletPower, level);
            //set enemy1BH
            Enemy10BH e10 = Enemy1.GetComponentInChildren<Enemy10BH>();
            e10.Bullet = BulletModle[0];
            e10.AttackInterval = (int)(5f * Mathf.Pow(attackInterval, level));
            //==============================================================================\\
            //spwan end
            if (enemySum >= (int)(5f * Mathf.Pow(enemyNumber, level))) {
                spwanPoint = 0;
                timer = 0;
            }
        }
        timer++;
    }

    void spwanPoint_2() {
        if (timer == spwanInterval * enemySum) {
            enemySum++;
            //================================ spwan enemy ================================\\
            //set position and rotation and layer
            Vector3 pos = new Vector3(Random.Range(-14f, 14f), Random.Range(-9f, 9f), 5f);
            GameObject Enemy1 = Instantiate(EnemyModle[0], pos, Quaternion.Euler(Vector3.zero)) as GameObject;
            Enemy1.transform.parent = transform;
            //set entety
            Entety ent = Enemy1.GetComponent<Entety>();
            ent.Health = 13f * Mathf.Pow(enemyHealth, level);
            ent.Modle = false;
            //set enemy movement
            EnemyMovement em = Enemy1.GetComponent<EnemyMovement>();
            em.MoveType = 5;
            em.Speed = 2.5f * Mathf.Pow(enemySpeed, level);
            //set bullet
            //set bullet
            BulletBehavior bb = BulletModle[2].GetComponent<BulletBehavior>();
            bb.Speed = 7.5f * Mathf.Pow(bulletSpeed, level);
            bb.Power = 1f * Mathf.Pow(bulletPower, level);
            //set enemy1BH
            Enemy1BH e1 = Enemy1.GetComponentInChildren<Enemy1BH>();
            e1.Bullet = BulletModle[2];
            e1.NumberOfBullet = (int)(15f * Mathf.Pow(bulletNumber, level));
            e1.AttackInterval = (int)(100f * Mathf.Pow(attackInterval, level));
            //==============================================================================\\
            //spwan end
            if (enemySum >= (int)(7f * Mathf.Pow(enemyNumber, level))) {
                spwanPoint = 0;
                timer = 0;
            }
        }
        timer++;
    }

    void spwanPoint_3() {
        if (timer == spwanInterval * enemySum) {
            enemySum++;
            //================================ spwan enemy ================================\\
            //set position and rotation and layer
            Vector3 pos = new Vector3(Random.Range(-14f, 14f), Random.Range(-9f, 9f), 5f);
            GameObject Enemy1 = Instantiate(EnemyModle[1], pos, Quaternion.Euler(Vector3.zero)) as GameObject;
            Enemy1.transform.parent = transform;
            //set entety
            Entety ent = Enemy1.GetComponent<Entety>();
            ent.Health = 15f * Mathf.Pow(enemyHealth, level);
            ent.Modle = false;
            //set enemy movement
            EnemyMovement em = Enemy1.GetComponent<EnemyMovement>();
            em.MoveType = 4;
            em.Speed = 2.5f * Mathf.Pow(enemySpeed, level);
            //set bullet
            BulletBehavior bb = BulletModle[0].GetComponent<BulletBehavior>();
            bb.Speed = 5f * Mathf.Pow(bulletSpeed, level);
            bb.Power = 1f * Mathf.Pow(bulletPower, level);
            //set enemy1BH
            Enemy2BH e2 = Enemy1.GetComponentInChildren<Enemy2BH>();
            e2.Bullet = BulletModle[0];
            e2.AttackInterval = (int)(10f * Mathf.Pow(attackInterval, level));
            //==============================================================================\\
            //spwan end
            if (enemySum >= (int)(4f * Mathf.Pow(enemyNumber, level))) {
                spwanPoint = 0;
                timer = 0;
            }
        }
        timer++;
    }

    void spwanPoint_5() {
        if (timer == spwanInterval * enemySum) {
            enemySum++;
            //================================ spwan enemy ================================\\
            //set position and rotation and layer
            Vector3 pos = new Vector3(Random.Range(-14f, 14f), Random.Range(-9f, 9f), 5f);
            GameObject Enemy1 = Instantiate(EnemyModle[5], pos, Quaternion.Euler(Vector3.zero)) as GameObject;
            Enemy1.transform.parent = transform;
            //set entety
            Entety ent = Enemy1.GetComponent<Entety>();
            ent.Health = 9f * Mathf.Pow(enemyHealth, level);
            ent.Modle = false;
            //set enemy movement
            EnemyMovement em = Enemy1.GetComponent<EnemyMovement>();
            em.MoveType = 1;
            em.Speed = 1f * Mathf.Pow(enemySpeed, level);
            //set bullet
            //set bullet
            BulletBehavior bb = BulletModle[1].GetComponent<BulletBehavior>();
            bb.Speed = 5f * Mathf.Pow(bulletSpeed, level);
            bb.Power = 3f * Mathf.Pow(bulletPower, level);
            //set enemy1BH
            Enemy6BH e1 = Enemy1.GetComponentInChildren<Enemy6BH>();
            e1.Bullet = BulletModle[1];
            e1.AttackInterval = (int)(50f * Mathf.Pow(attackInterval, level));
            //==============================================================================\\
            //spwan end
            if (enemySum >= (int)(5f * Mathf.Pow(enemyNumber, level))) {
                spwanPoint = 0;
                timer = 0;
            }
        }
        timer++;
    }

    void spwanPoint_4() {
        if (timer == spwanInterval * enemySum) {
            enemySum++;
            //================================ spwan enemy ================================\\
            //set position and rotation and layer
            Vector3 pos = new Vector3(Random.Range(-14f, 14f), Random.Range(-9f, 9f), 5f);
            GameObject Enemy1 = Instantiate(EnemyModle[6], pos, Quaternion.Euler(Vector3.zero)) as GameObject;
            Enemy1.transform.parent = transform;
            //set entety
            Entety ent = Enemy1.GetComponent<Entety>();
            ent.Health = 5f * Mathf.Pow(enemyHealth, level);
            ent.Modle = false;
            //set enemy movement
            EnemyMovement em = Enemy1.GetComponent<EnemyMovement>();
            em.MoveType = 0;
            em.Speed = 0f;
            //set bullet
            //set bullet
            BulletBehavior bb = BulletModle[0].GetComponent<BulletBehavior>();
            bb.Speed = 7.5f * Mathf.Pow(bulletSpeed, level);
            bb.Power = 1.5f * Mathf.Pow(bulletPower, level);
            //set enemy1BH
            Enemy7BH e1 = Enemy1.GetComponentInChildren<Enemy7BH>();
            e1.Bullet = BulletModle[0];
            e1.NumberOfBullet = (int)(10f * Mathf.Pow(attackInterval, level));
            //==============================================================================\\
            //spwan end
            if (enemySum >= (int)(5f * Mathf.Pow(enemyNumber, level))) {
                spwanPoint = 0;
                timer = 0;
            }
        }
        timer++;
    }
}
