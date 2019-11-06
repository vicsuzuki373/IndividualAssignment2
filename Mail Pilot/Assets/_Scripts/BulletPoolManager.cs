using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    //TODO: create a structure to contain a collection of bullets
    private List<GameObject> bullets = new List<GameObject>();
    private static BulletPoolManager m_Instance;
    public int bulletCount = 15;

    private BulletPoolManager()
    {

    }

    public static BulletPoolManager GetInstance()
    {
        if (m_Instance == null)
        {
            m_Instance = new BulletPoolManager();
        }

        return m_Instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < 15; i++)
        {
            bullets.Add(Instantiate(bullet, new Vector3(-100,-100,0), Quaternion.identity));
            bullets[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject temp = bullets[0];
        bullets[0].SetActive(true);
        bullets.RemoveAt(0);
        bullets.Add(temp);

        return temp;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
