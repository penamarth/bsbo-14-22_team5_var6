using System;
using System.Numerics;

class Warehouse {
    private Client[] clients;
    private Shipment[] shipments;
    private List<Storage> storage;

    public Warehouse(Client[] clients, Shipment[] shipments, List<Storage> storage) {
        this.clients = clients;
        this.shipments = shipments;
        this.storage = storage;
    }

    public Warehouse() {
        this.storage = new List<Storage>();
    }

    public void AddClient(Client client) { }
    public void RemoveClient(Client client) { }
    public void GetClient(Client client) { }
    public void AddShipment(Shipment shipment) { }
    public void RemoveShipment(Shipment shipment) { }
    public void GetShipment(Shipment shipment) { }
    public void AddStorage(Storage s) {
        this.storage.Add(s);
    }
    public void RemoveStorage(Storage s) {
        this.storage.Remove(s);
    }
    public void GetStorage(Storage storage) { }
    public void AddItem(Item i) { storage[0].AddItem(i); }
}

class Item {
    private Vector3 dimensions;
    private Vector3 weight;
    private decimal price;
}

class Rack: CompositeStorage {
    public Rack(List<Storage> shelves) {
        this.children = shelves;
    }
}

class Shelf: CompositeStorage {
    public Shelf(List<Storage> st) {
        this.children = st;
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

    public void RemoveItem(Item item) {
        Console.Write("Cell removed item\n");
    }
}

interface Storage {
    virtual void AddItem(Item item) {
        Console.Write(this.GetType().Name + " placed item\n");
    }
    virtual void RemoveItem(Item item) { }
    virtual void GetItem(Item item) { }
    virtual int GetStorageOwnerID() { return 0; }
    virtual int GetItemOwnerID(Item item) { return 1; }
}

class CompositeStorage: Storage {
    public List<Storage> children;

    public void AddStorage(Storage s) {
        this.children.Add(s);
    }

    public void RemoveStorage(Storage s) {
        this.children.Remove(s);
    }

    public void AddItem(Item i) {
        Console.Write(this.GetType().Name + " placed item\n");
        this.children[0].AddItem(i);
    }

    public void RemoveItem(Item i) { }

    public void GetItem(Item i) { }

    public int GetStorageOwnerID() { return 0; }

    public int GetItemOwnerID() { return 1; }
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
        Warehouse w = new Warehouse();

        Storage r = new Rack(
                new List<Storage>{
                    new Shelf(
                        new List<Storage>{
                            new Cell()
                        }
                    )
                }
            );

        Storage s = new Shelf(
            new List<Storage>{
                new Cell()
            }
        );

        w.AddStorage(r);

        w.AddItem(new Item());
    }
}