using System;
using System.Numerics;

class Warehouse {
    private Storage[] racks;
    private Client[] clients;
}

class Rack: Storage {
    private Storage[] shelves;

    public double GetAvailableSpace() {
        double result = 0.0;

        foreach (Storage shelf in shelves) {
            result += shelf.GetAvailableSpace();
        }

        return result;
    }
}

class Shelf: Storage {
    private Storage[] cells;

    public double GetAvailableSpace() {
        double result = 0.0;

        foreach (Storage cell in cells) {
            result += cell.GetAvailableSpace();
        }

        return result;
    }
}

class Cell: Storage {
    private int[] stored_items;
    private int ownerID;
    private Vector3 dimensions;
    private int max_weight;
    private Vector3 available_space;

    public double GetAvailableSpace() {
        return available_space.X * available_space.Y * available_space.Z;
    }
}

interface Storage {
    public double GetAvailableSpace() {
        return 0.0;
    }
    public void PlaceItem(Item i) {}
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