using System;
using System.Numerics;

class Warehouse: Storage {
    public Warehouse(Rack[] racks) {
        this.racks = racks;
    }
    private Storage[] racks;
    private Client[] clients;

    public double GetAllAvailableSpace() {
        double result = 0.0;

        foreach (Storage rack in racks) {
            result += rack.GetAllAvailableSpace();
        }

        return result;
    }
}

class Rack: Storage {
    public Rack(Shelf[] shelves) {
        this.shelves = shelves;
    }

    private Storage[] shelves;

    public double GetAllAvailableSpace() {
        double result = 0.0;

        foreach (Storage shelf in shelves) {
            result += shelf.GetAllAvailableSpace();
        }

        return result;
    }
}

class Shelf: Storage {
    public Shelf(Cell[] cells) {
        this.cells = cells;
    }

    private Storage[] cells;

    public double GetAllAvailableSpace() {
        double result = 0.0;

        foreach (Storage cell in cells) {
            result += cell.GetAllAvailableSpace();
        }

        return result;
    }
}

class Cell: Storage {
    public Cell(Vector3 available_space) {
        this.available_space = available_space;
    }

    private int[] stored_items;
    private int ownerID;
    private Vector3 dimensions;
    private int max_weight;
    private Vector3 available_space;

    public double GetAllAvailableSpace() {
        return available_space.X * available_space.Y * available_space.Z;
    }
}

interface Storage {
    public double GetAllAvailableSpace() {
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
        Warehouse w = new Warehouse(new Rack[] {
            new Rack(new Shelf[] {
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                }),
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                }),
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                })
            }),
            new Rack(new Shelf[] {
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                }),
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                }),
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                })
            }),
            new Rack(new Shelf[] {
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                }),
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                }),
                new Shelf(new Cell[] {
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1)),
                    new Cell(available_space: new Vector3(1, 1, 1))
                })
            })
        });

        Console.Write(w.GetAllAvailableSpace());
    }
}