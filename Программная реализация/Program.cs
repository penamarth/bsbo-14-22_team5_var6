using System;
using System.Numerics;

class Warehouse {
    private List<Client> clients;
    private List<Shipment> shipments;
    private Storage storage;

    public Warehouse(List<Client> clients, List<Shipment> shipments, Storage storage) {
        this.clients = clients;
        this.shipments = shipments;
        this.storage = storage;
    }

    public Warehouse() {
        storage = new Cell();
        clients = new List<Client>();
        shipments = new List<Shipment>();
    }

    public void AddClient(Client client) {
        clients.Add(client);
    }
    public void RemoveClient(int index) { }
    public Client GetClient(int index) {
        return clients[index];
    }
    public void AddShipment(Shipment shipment) {
        shipments.Add(shipment);
    }
    public void RemoveShipment(Shipment shipment) { }
    public Shipment GetShipment(int index) {
        return shipments[index];
    }
    public void GetStorage(Storage storage) { }
    public void AddItem(Item i) { storage.AddItem(i); }
    public int GetItemCount() { return storage.GetItemCount(); }
    public void SetStorage(Storage s) {
        storage = s;
    }
    public StorageStats GetStorageStats() {
        StorageStats ss = new StorageStats();
        ss.count = storage.GetItemCount();
        return ss;
    }

    public void ChangeBalance(int client_index, decimal amount) {
        clients[client_index].balance += amount;
    }
}

struct StorageStats {
    public int total_weight;
    public int count;
    public int total_price;
}

class Item {
    private Vector3 dimensions;
    private int weight;
    private decimal price;

    public Item() {}

    public Item(
        int w, decimal p
    ) {
        weight = w;
        price = p;
    }
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
    
    private bool empty;

    public Cell(Vector3 dimensions, Vector3 weight) {
        this.dimensions = dimensions;
        this.weight = weight;
        empty = true;
    }

    public Cell(Vector3 dimensions) {
        this.dimensions = dimensions;
        empty = true;
    }

    public Cell() {
        empty = true;
    }

    public Vector3 GetDimensions() {
        return dimensions;
    }

    public void AddItem(Item i) {
        Console.Write(this.GetType().Name + " placing item\n");
        empty = false;
    }

    public Vector3 GetWeight() {
        return weight;
    }

    public void RemoveItem(Item item) {
        Console.Write("Cell removed item\n");
    }

    public int GetItemCount() {
        if (empty) {
            return 0;
        } else {
            return 1;
        }
    }
}

interface Storage {
    virtual void AddItem(Item item) {
        Console.Write(this.GetType().Name + " placing item\n");
    }
    virtual void RemoveItem() {
        Console.Write(this.GetType().Name + " removing item\n");
    }
    virtual void GetItem(Item item) { }
    virtual int GetStorageOwnerID() { return 0; }
    virtual int GetItemOwnerID(Item item) { return 1; }

    virtual int GetItemCount() {
        return 0;
    }
}

class CompositeStorage: Storage {
    public List<Storage> children;

    public CompositeStorage(List<Storage> c) {
        children = c;
    }

    public CompositeStorage () {}

    public void AddStorage(Storage s) {
        this.children.Add(s);
    }

    public void RemoveStorage(Storage s) {
        this.children.Remove(s);
    }

    public void AddItem(Item i) {
        Console.Write(this.GetType().Name + " placed item\n");
        for (int ii = 0; ii < children.Count(); ii++) {
            if (children[ii].GetItemCount() == 0) {
                children[ii].AddItem(i);
                break;
            }
        }
    }

    public void RemoveItem(Item i) { }

    public void GetItem(Item i) { }

    public int GetStorageOwnerID() { return 0; }

    public int GetItemOwnerID() { return 1; }

    public int GetItemCount() {
        int result = 0;
        foreach (Storage s in children) {
            result += s.GetItemCount();
        }
        return result;
    }
}

class Client {
    public int id;
    public string name;
    public string surname;
    public string email;
    public string phone;
    public decimal balance;

    public Client(
        string nam,
        string surnam,
        string phon
    ) {
        name = nam;
        surname = surnam;
        phone = phon;
    }
}

class Shipment {
    public int id;
    public int client_id;
    public Item[] items;
    public decimal price;
    public ShipmentStatus status;
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
                            new Cell(),
                            new Cell(),
                            new Cell(),
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

        w.SetStorage(r);
        Console.Write(w.GetItemCount() + "\n");
        w.AddItem(new Item());
        //w.AddItem(new Item());
        Console.Write(w.GetItemCount() + "\n");
        Console.Write(w.GetStorageStats().count + "\n");

        w.AddClient(new Client(
            "Name",
            "Surname",
            "+38909278589279573285"
        ));

        Console.Write(w.GetClient(0).phone + "\n");
        Console.Write(w.GetClient(0).balance + "\n");
        w.ChangeBalance(0, 3123);
        Console.Write(w.GetClient(0).balance + "\n");
        w.ChangeBalance(0, -123);
        Console.Write(w.GetClient(0).balance + "\n");
    }
}