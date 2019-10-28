using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Player player;
    public Coin coin;
    public int coinsSpawned = 0;
    private Vector2 targetSpawn;

    private float spawnHeightMax;
    private float spawnHeightMin;
    private float spawnLengthMax;
    private float spawnLengthMin;

    // Start is called before the first frame update
    void Start()
    {
        spawnHeightMax = player.maxHeight;
        spawnHeightMin = player.minHeight;
        spawnLengthMax = player.maxLength;
        spawnLengthMin = player.minLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsSpawned < 1)
        {
            int randHeight = Random.Range((int)spawnHeightMin, (int)spawnHeightMax);
            int randLength = Random.Range((int)spawnLengthMin, (int)spawnLengthMax);
            targetSpawn = new Vector2(randLength, randHeight);

            Instantiate(coin, targetSpawn, Quaternion.identity);
            coinsSpawned++;
        }
    }
}
