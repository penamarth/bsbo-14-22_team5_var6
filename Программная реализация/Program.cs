using System;

class Warehouse {
    private Storage[] racks;
    private Client[] clients;
}

class Rack: Storage {
    private Storage[] shelves;
}

class Shelf: Storage {
    private Storage[] cells;
}

class Cell: Storage {
    private int[] stored_items;
    private int ownerID;
    private Vector3 dimensions;
    private int max_weight;
    private Numeric.Vector3[] available_space;

    
}

interface Storage {
    public int GetAvailableSpace() {}
    public int PlaceItem(Item i) {}
}

class Client {
    private string name;
    private string surname;
    private string patronymic;
    
}

class Shipment {
    private Item[] items;
    private int ClientID;
    private int status;
    private decimal price;
}

class Item {
    private double weight;
    private Vector3 dimensions;
    private decimal price;
}

class WarehouseNextGen {
    static void Main() {
        Console.Write("I HATE EVERYTHING");
    }
}