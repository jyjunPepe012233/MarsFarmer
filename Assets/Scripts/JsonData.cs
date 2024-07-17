using System;
using System.Collections.Generic;

public class BuildingInfo
{
    private int[] _pos;
    private string _building;
    private string _lastGetTime;
    private int _sleepTime;

    public enum Product
    {
        rices,
        corns,
        potatoes
    }

    private Product _items;
    
    public BuildingInfo() {  }

    public BuildingInfo(int[] pos, string building, string lastGetTime)
    {
        _pos = pos;
        _building = building;
        _lastGetTime = lastGetTime;
    }

    public BuildingInfo(int[] pos, string building, string lastGetTime, Product items)
    {
        _pos = pos;
        _building = building;
        _lastGetTime = lastGetTime;
        _items = items;
    }

    public int[] Pos
    {
        get { return _pos; }
        set { _pos = value; }
    }

    public string Building
    {
        get { return _building; }
        set { _building = value; }
    }

    public string LastGetTime
    {
        get { return _lastGetTime; }
        set { _lastGetTime = value; }
    }

    public int SleepTime
    {
        get { return _sleepTime; }
        set { _sleepTime = value; }
    }
    
    public Product Items
    {
        get { return _items; }
        set { _items = value; }
    }
}

public class JsonData
{
    private string _userName;
    private int _userLevel;

    private int _dollars;
    private int _rubys;
    private List<BuildingInfo> _buildingInfos;
    private string[] _workers;
    
    private float _oxygen;
    private float _water;
    private float _electricity;

    private int _rices;
    private int _corns;
    private int _potatoes;

    private string _lastPlayTime;

    public JsonData() { }

    public JsonData(string userName, int userLevel, int dollars, int rubys,  List<BuildingInfo> buildingInfos, string[] workers, float oxygen,
        float water, float electricity, int rices, int corns, int potatoes, string lastPlayTime)
    {
        _userName = userName;
        _userLevel = userLevel;
        _dollars = dollars;
        _rubys = rubys;
        _buildingInfos = buildingInfos;
        _workers = workers;
        _oxygen = oxygen;
        _water = water;
        _electricity = electricity;
        _rices = rices;
        _corns = corns;
        _potatoes = potatoes;
        _lastPlayTime = lastPlayTime;
    }

    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    public int UserLevel
    {
        get { return _userLevel; }
        set { _userLevel = value; }
    }

    public int Dollars
    {
        get { return _dollars; }
        set { _dollars = value; }
    }

    public int Rubys
    {
        get { return _rubys; }
        set { _rubys = value; }
    }

    public List<BuildingInfo> BuildingInfos
    {
        get { return _buildingInfos; }
        set { _buildingInfos = value; }
    }

    public string[] Workers
    {
        get { return _workers; }
        set { _workers = value; }
    }

    public float Oxygen
    {
        get { return _oxygen; }
        set { _oxygen = (float)Math.Floor(value * 100) / 100; }
    }

    public float Water
    {
        get { return _water; }
        set { _water = (float)Math.Floor(value * 100) / 100; }
    }

    public float Electricity
    {
        get { return _electricity; }
        set { _electricity = (float)Math.Floor(value * 100) / 100; }
    }

    public int Rices
    {
        get { return _rices; }
        set { _rices = value; }
    }

    public int Corns
    {
        get { return _corns; }
        set { _corns = value; }
    }

    public int Potatoes
    {
        get { return _potatoes; }
        set { _potatoes = value; }
    }

    public string LastPlayTime
    {
        get { return _lastPlayTime; }
        set { _lastPlayTime = value; }
    }
}