using SQLite4Unity3d;
using UnityEngine;
using System.Linq;

#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/SQlite/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateDB(){
		
		_connection.DropTable<User>();
		_connection.CreateTable<User> ();
	}

	public void CreatePrizeDB()
	{
		_connection.DropTable<Prize>();
		_connection.CreateTable<Prize> ();
	}

	public void CreatePlayerDB()
	{
		_connection.DropTable<Player>();
		_connection.CreateTable<Player> ();

		_connection.InsertAll(new[]{
			new Player
			{
				level = 1,
				n_exp = 20,
				hp = 20,
				mp = 5,
				strength = 10,
				guard = 4,
			},
			new Player
			{
				level = 2,
				n_exp = 35,
				hp = 35,
				mp = 10,
				strength = 14,
				guard = 9,
			},
			new Player
			{
				level = 3,
				n_exp = 50,
				hp = 50,
				mp = 15,
				strength = 20,
				guard = 14,
			},
		});
	}

	public void CreateEnemiesDB()
	{
		_connection.DropTable<Enemies>();
		_connection.CreateTable<Enemies>();

		_connection.InsertAll(new[] {
			new Enemies
			{
				id = 1,
				name = "スライム",
				hp = 20,
				strength = 10,
				guard = 2,
				expg = 4,
			},
			new Enemies
			{
				id = 2,
				name = "とげこうらスライム",
				hp = 17,
				strength = 12,
				guard = 10,
				expg = 7,
			},
			new Enemies
			{
				id = 3,
				name = "怪物サボテン",
				hp = 30,
				strength = 20,
				guard = 4,
				expg = 10,
			},
			new Enemies
			{
				id = 4,
				name = "マッシュ",
				hp = 24,
				strength = 3,
				guard = 6,
				expg = 10,
			}

		});
	}

	public User CreatUser(string inputValue)
	{
		var user = new User
		{
			Name = inputValue,
		};
		_connection.Insert(user);
		return user;
	}

	//プレイヤーデータの全ての要素を指す
	public List<Player> GetAllPlayerData()
	{
		return _connection.Table<Player>().ToList();
	}
	//プレイヤーデータの一部の要素を指す
	public Player GetPlayer(int lv)
	{
		return _connection.Table<Player>().Where(pd => pd.level == lv).ElementAt(0);
	}


	public Enemies GetEnemiesData(int en)
	{
		return _connection.Table<Enemies>().Where(ed => ed.id == en).ElementAt(0);
	}

}
