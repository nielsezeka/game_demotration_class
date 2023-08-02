using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Map
{
	public int Level;
	public int TargetScore;
	public float LimitTime;
	public int[] Fruits = new int[5];
	public int Freeze;
	public int Power1;
	public int Power2;
	public int Power3;
	public int Stars;
	public bool Locked;
	public int HightScore;
}

public class FileUtils{
	public List<Map> Maps = new List<Map>();
	public string path = "";
    /// <summary>
    /// formart and save serialize to file by path
    /// </summary>
	public void Save(){
		var b = new BinaryFormatter ();
		var f = File.Create (path);
		b.Serialize (f, Maps);
		f.Close();
	}
    /// <summary>
    /// load and Deserialize from file by path
    /// </summary>
    /// <returns></returns>
	public List<Map> load(){
		List<Map> temp = new List<Map> ();
		var b = new BinaryFormatter ();
		var f = File.Open (path, FileMode.Open);
		temp = (List<Map>)b.Deserialize(f);
		f.Close ();
		return temp;
	}
    /// <summary>
    /// update data player
    /// </summary>
    /// <param name="map"></param>
	public void Update (Map map){
		for (int i = 0; i<Maps.Count;i++) 
			if (Maps[i].Level == map.Level){
				Maps[i] = map;
				break;
				}
		Save ();
	}
}



