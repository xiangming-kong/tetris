using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Learnt from www.noobtuts.com

public class Group : MonoBehaviour {

    float lastFall = 0;
    
	void Start()
    {
        if(!isValidGridPos())
        {
			Destroy(gameObject);
            Gameplay.gameoverPanel.SetActive(true);
        }
	}
	
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
			transform.position += new Vector3(-1, 0, 0);
			
			if(isValidGridPos())
				updateGrid();
			else
				transform.position += new Vector3(1, 0, 0);
		}
		
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
			transform.position += new Vector3(1, 0, 0);

            if(isValidGridPos())
				updateGrid();
			else
				transform.position += new Vector3(-1, 0, 0);
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
			transform.Rotate(0, 0, -90);

            if(isValidGridPos())
				updateGrid();
			else
				transform.Rotate(0, 0, 90);
		}

		if(Input.GetKey(KeyCode.DownArrow) || Time.time - lastFall >= 1)
        {
			transform.position += new Vector3(0, -1, 0);

            if(isValidGridPos())
            {
				updateGrid();
			}
            else
            {
				transform.position += new Vector3(0, 1, 0);	
				Grid.deleteFullRows();				
				FindObjectOfType<Spawner>().spawnNext();				
				enabled = false;
			}
			lastFall = Time.time;
		}
	}

	bool isValidGridPos()
    {        
		foreach(Transform t in transform)
        {
			Vector2 v = Grid.roundVec2(t.position);
			if (!Grid.insideBorder(v))
				return false;		
			if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid()
    {
		for(int y = 0; y < Grid.h; ++y)
			for(int x = 0; x < Grid.w; ++x)
				if(Grid.grid[x, y] != null)
					if(Grid.grid[x, y].parent == transform)
						Grid.grid[x, y] = null;

		foreach(Transform t in transform)
        {
			Vector2 v = Grid.roundVec2(t.position);
			Grid.grid[(int)v.x, (int)v.y] = t;
		}        
	}

}