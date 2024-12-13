using System;
using System.Numerics;

class Warehouse {
    private Client[] clients;
    private Shipment[] shipments;
    private Storage[] storage;

    public Warehouse(Client[] clients, Shipment[] shipments, Storage[] storage) {
        this.clients = clients;
        this.shipments = shipments;
        this.storage = storage;
    }

    public void AddClient(Client client) { }
    public void RemoveClient(Client client) { }
    public void GetClient(Client client) { }
    public void AddShipment(Shipment shipment) { }
    public void RemoveShipment(Shipment shipment) { }
    public void GetShipment(Shipment shipment) { }
    public void AddStorage(Storage storage) { }
    public void RemoveStorage(Storage storage) { }
    public void GetStorage(Storage storage) { }
}

class Item {
    private Vector3 dimensions;
    private Vector3 weight;
    private decimal price;
}

class Rack: Storage {
    private Shelf[] shelves;

    public Rack(Shelf[] shelves) {
        this.shelves = shelves;
    }
}

class Shelf: Storage {
    private Cell[] cells;

    public Shelf(Cell[] cells) {
        this.cells = cells;
    }
}

class Cell: Storage {
    private Vector3 dimensions;
    private Vector3 weight;
    private Item item;
    
    public Cell(Vector3 dimensions, Vector3 weight) {
        this.dimensions = dimensions;
        this.weight = weight;
    }

    public Cell(Vector3 dimensions) {
        this.dimensions = dimensions;
    }

    public Cell() {
        
    }

    public Vector3 GetDimensions() {
        return dimensions;
    }

    public Vector3 GetWeight() {
        return weight;
    }

    public void AddItem(Item item) { }
    public void RemoveItem(Item item) { }
    public void GetItem(Item item) { }
}

interface Storage<T> {
    virtual void AddItem(T item) { }
    virtual void RemoveItem(T item) { }
    virtual void GetItem(T item) { }
    virtual int GetStorageOwnerID() { }
    virtual int GetItemOwnerID(T item) { }
}

class Client {
    private int id;
    private string name;
    private string surname;
    private string email;
    private string phone;
    private decimal balance;
}

class Shipment {
    private int id;
    private int client_id;
    private Item[] items;
    private decimal price;
    private ShipmentStatus status;
}

enum ShipmentStatus {
    IN_TRANSIT,
    DELIVERED,
    CANCELED
}

class WarehouseNextGen {
    static void Main() {
        Console.Write("fuck");
    }
}