using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{
    [SerializeField] BoxCollider bc;
    [SerializeField] GameObject[] Block;
    [SerializeField] GameObject Coin;

    int counter = 0;
    int blocksize = 0;
    int tempmaxsize;
    int tempblockindex;
    bool m_forward = false;
    float size;
    Vector2 spawnpos;


    [SerializeField] Material[] tepe;
    [SerializeField] Material[] wall;

    

    void Start()
    {
        ChangeBlockType();
        spawnpos = Vector2.zero;
        size = bc.GetComponent<Renderer>().bounds.size.x;
        Debug.Log(size);
        InvokeRepeating("SpawnBlock2", 0, 0.5f);
        
    }


    void ChangeBlockType() 
    {
        int type = Random.Range(0, 4);
        int n = transform.childCount;
        Debug.Log("type 1");

       // GetComponentInChildren<MeshRenderer>().material = tepe[type];   
       // GetComponentInChildren<MeshRenderer>().materials[1] = tepe[type];

         for (int i = 0; i < n; i++)
         {
            // transform.GetChild(i).transform.gameObject.GetComponent<MeshRenderer>().material = wall[type];
             transform.GetChild(i).transform.gameObject.GetComponent<MeshRenderer>().material = tepe[type];
             Debug.Log("type 2 " + type);

         }
    }


    void SpawnBlock2() 
    {

        if (blocksize == 0) 
        {
            tempblockindex = 0;
            blocksize = Random.Range(2, 5);
            tempmaxsize = blocksize;
            if (!m_forward)
                m_forward = true;
            else
                m_forward = false;
        }
        blocksize--;
        tempblockindex++;
        Debug.Log("tempsize " + tempmaxsize + " blocksize " + blocksize + " tempblockindex" + tempblockindex);
        if (m_forward) 
        {
            spawnpos.y += size;
            if (tempblockindex != 1 && tempblockindex!=tempmaxsize) 
            {
                int blockno = Random.Range(0, Block.Length);
                if (blockno == 0)
                {
                    Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 0))).transform.parent = this.transform;
                }
                else if (blockno != 0)
                {
                    Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 0))).transform.parent = this.transform;
                }

            }
            else 
            {
                int blockno = 0;
                Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 0))).transform.parent = this.transform;
                if (Random.Range(0, 100) > 70)
                {
                    Instantiate(Coin, new Vector3(spawnpos.x + Random.Range(-5.00f, 5.00f), Block[0].transform.position.y + 4, spawnpos.y+ Random.Range(-5.00f, 5.00f)), Quaternion.identity);
                }
            }
        }
        else 
        {
            spawnpos.x += size;
            if (tempblockindex != 1 && tempblockindex != tempmaxsize)
            {
                int blockno = Random.Range(0, Block.Length);
                if (blockno == 0)
                {
                    Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 0))).transform.parent = this.transform;
                }
                else if (blockno != 0)
                {
                    Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 90))).transform.parent = this.transform;
                }
                
            }
            else
            {
                int blockno = 0;
                Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 0))).transform.parent = this.transform;
                if (Random.Range(0, 100) > 70)
                {
                    Instantiate(Coin, new Vector3(spawnpos.x+Random.Range(-5.00f, 5.00f), Block[0].transform.position.y + 4, spawnpos.y + Random.Range(-5.00f, 5.00f)), Quaternion.Euler(0,0,0));
                }
            }
        }

    }


    
    void spawnblock() 
    {
        int n = Random.Range(0, 100);
        if (n > 50) 
        {
            if (!m_forward) 
            {
                counter = 0;
                m_forward = true;

            }
            counter++;
            if (counter == 4) 
            {
                counter = 0;
                spawnpos.y += size;
            }
            else 
            {
            spawnpos.x += size;

            }
        }
        else 
        {
            if (m_forward)
            {
                counter = 0;
                m_forward = false;

            }

            counter++;
            if (counter == 4)
            {
                counter = 0;
                spawnpos.x += size;
            }
            else
            {
                spawnpos.y += size;

            }
        }
        int blockno = Random.Range(0, 2);
        if (blockno == 0) 
        {
        Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, 0))).transform.parent=this.transform;
        }
        if (blockno == 1) 
        {
            if(!m_forward)
        Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y),Quaternion.Euler(new Vector3(-90, 0,0 ))).transform.parent=this.transform;
            else
                Instantiate(Block[blockno], new Vector3(spawnpos.x, Block[0].transform.position.y, spawnpos.y), Quaternion.Euler(new Vector3(-90, 0, -90))).transform.parent = this.transform;

        }


    }


    void Update()
    {
        
    }
}
