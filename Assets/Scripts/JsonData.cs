using System;
using System.Collections.Generic;

public class BuildingInfo
{
    private int[] _pos;
    private string _building;
    
    public BuildingInfo() { }

    public BuildingInfo(int[] pos, string building)
    {
        _pos = pos;
        _building = building;
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
}

public class JsonData
{
    private string _userName;
    private int _userLevel;

    private float _dollars;
    private List<BuildingInfo> _buildingInfos;
    private string[] _workers;
    
    private float _oxygen;
    private float _water;
    private float _electricity;

    private int _rices;
    private int _corns;
    private int _potatoes;

    public JsonData() { }

    public JsonData(string userName, int userLevel, float dollars,  List<BuildingInfo> buildingInfos, string[] workers, float oxygen,
        float water, float electricity, int rices, int corns, int potatoes)
    {
        _userName = userName;
        _userLevel = userLevel;
        _dollars = dollars;
        _buildingInfos = buildingInfos;
        _workers = workers;
        _oxygen = oxygen;
        _water = water;
        _electricity = electricity;
        _rices = rices;
        _corns = corns;
        _potatoes = potatoes;
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

    public float Dollars
    {
        get { return _dollars; }
        set { _dollars = (float)Math.Floor(value * 100) / 100; }
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
    
}