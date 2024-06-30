using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private List<Transform> _spawnPoints;
    public static CubeSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    class Pool
    {
        private List<GameObject> inactive = new List<GameObject>();
        private GameObject prefab;
        public Pool(GameObject prefab) { this.prefab = prefab; }

        public GameObject Spawn(Vector3 pos, Quaternion rot)
        {
            GameObject obj;
            if (inactive.Count == 0)
            {
                obj = Instantiate(prefab, pos, rot);
                obj.name = prefab.name;
                obj.transform.SetParent(instance.transform);
            }
            else
            {
                obj = inactive[inactive.Count - 1];
                inactive.RemoveAt(inactive.Count - 1);
            }
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
            return obj;
        }

        public void Despawn(GameObject obj)
        {
            obj.SetActive(false);
            inactive.Add(obj);
        }
    }

    private Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    public void Preload(GameObject prefab, int num)
    {
        Init(prefab);
        GameObject[] objs = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            objs[i] = Spawn(prefab, Vector3.zero, Quaternion.identity);
        }
        for (int i = 0; i < num; i++)
        {
            Despawn(objs[0]);
        }
    }
    private void Init(GameObject prefab)
    {
        if (prefab != null && pools.ContainsKey(prefab.name) == false)
        {
            pools[prefab.name] = new Pool(prefab);
        }
    }

    public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        Init(prefab);
        return pools[prefab.name].Spawn(pos, rot);
    }

    public void Despawn(GameObject obj)
    {
        if (pools.ContainsKey(obj.name))
        {
            pools[obj.name].Despawn(obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}