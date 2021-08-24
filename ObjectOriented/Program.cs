using System;
using System.Collections.Generic;

namespace ObjectOriented
{
    public class Product
    {
        public string name;
        private decimal price;
        public int stock;

        public void SetPrice(decimal price)
        {
            this.price = price;
        }
        public decimal GetPrice()
        {
            return price;
        }

    }
    public class SecondHandProduct : Product
    {
        public string condition;
        public void ShowCondition()
        {
            Console.WriteLine($"Kondisi barang: {condition}");
        }
    }
    class Program
    {
        public static List<SecondHandProduct> items = new List<SecondHandProduct>();

        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi kesalahan!");
                Console.WriteLine(e.Message + "\n");

                BackToMenu();
            }
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("||============ SISTEM GUDANG TOKO XYZ ============||");
            Console.WriteLine("||================================================||");
            Console.WriteLine("||            1. Lihat data barang                ||");
            Console.WriteLine("||            2. Insert data barang               ||");
            Console.WriteLine("||            3. Hapus data barang                ||");
            Console.WriteLine("||            4. Lihat total harga barang         ||");
            Console.WriteLine("====================================================\n");
            Console.Write("Pilihan anda: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ShowItems();
                    break;
                case 2:
                    AddItem();
                    break;
                case 3:
                    DeleteItem();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=== TOTAL HARGA BARANG ===\n");

                    ShowList();
                    Console.Write("\nMasukkan no barang: ");
                    int no = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"\nHarga {items[no - 1].stock} {items[no - 1].name} adalah : Rp. {TotalValue(items[no - 1].GetPrice(), items[no - 1].stock)} ");
                    BackToMenu();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public static void ShowItems()
        {
            Console.Clear();
            Console.WriteLine("=== DAFTAR BARANG DI GUDANG ===\n");

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if(items[i].condition == null)
                    {
                        Console.WriteLine($"{i + 1}. {items[i].name} ({items[i].stock}) - Rp. {items[i].GetPrice()}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {items[i].name} ({items[i].stock}) - Rp. {items[i].GetPrice()} | Kondisi : {items[i].condition}");
                    }
                }

                BackToMenu();
            }
            else
            {
                Console.WriteLine("\nBelum ada data barang!");
                BackToMenu();
            }
        }
        public static void ShowList()
        {
            Console.Clear();
            Console.WriteLine("=== DAFTAR BARANG DI GUDANG TOKO XYZ ===\n");

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].condition == null)
                    {
                        Console.WriteLine($"{i + 1}. {items[i].name} ({items[i].stock}) - Rp. {items[i].GetPrice()}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {items[i].name} ({items[i].stock}) - Rp. {items[i].GetPrice()} ; Kondisi : {items[i].condition}");
                    }
                }
            }
        }

        public static void AddItem()
        {
            Console.Clear();
            Console.WriteLine("=== TAMBAH DATA BARANG ===\n");

            Console.Write("Masukkan jumlah barang: ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.Write($"\nJenis Barang ke-{i + 1} (1. Baru 2. Bekas) :");
                int inputType = Convert.ToInt32(Console.ReadLine());

                //input nama
                Console.Write($"Nama barang ke-{i + 1}: ");
                string inputName = Console.ReadLine();

                //input harga
                Console.Write($"Harga satuan barang ke-{i + 1}: ");
                decimal inputPrice = Convert.ToDecimal(Console.ReadLine());

                //input stock
                Console.Write($"Stock barang ke-{i + 1}: ");
                int inputStock = Convert.ToInt32(Console.ReadLine());

                //create object
                SecondHandProduct product = new SecondHandProduct();
                product.name = inputName;
                product.SetPrice(inputPrice);
                product.stock = inputStock;

                if (inputType == 2)
                {
                    //input kondisi (untuk barang bekas)
                    Console.Write($"Kondisi barang ke-{i + 1}: ");
                    string inputCondition = Console.ReadLine();

                    Console.WriteLine();
                    product.condition = inputCondition;
                }
                else
                {
                    //kondisi barang baru auto null
                    product.condition = null;
                }
                items.Add(product);

                //items.Add(Console.ReadLine());

            }
            BackToMenu();
        }

        public static void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("=== HAPUS DATA BARANG ===\n");

            if (items.Count > 0)
            {
                Console.WriteLine("Penghapusan Barang\n");
                Console.WriteLine("1. Hapus salah satu");
                Console.WriteLine("2. Hapus semua data\n");
                Console.Write("Pilihan anda: ");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        ShowList();
                        Console.Write("\nHapus barang no. berapa? ");
                        int rmIndex = Convert.ToInt32(Console.ReadLine());

                        items.RemoveAt(rmIndex - 1);

                        Console.Clear();
                        Console.Write($"Barang no. {rmIndex} sudah terhapus! \n");

                        BackToMenu();
                        break;

                    case 2:
                        items.Clear();
                        Console.WriteLine("Semua data terhapus!");
                        BackToMenu();
                        break;

                    default:
                        DeleteItem();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nBelum ada data barang!");
                BackToMenu();
            }
        }
        public static void BackToMenu()
        {
            Console.Write("\n======= Tekan sembarang tombol untuk kembali =======");
            Console.ReadKey(true);
            Menu();
        }

        public static decimal TotalValue(decimal price, int stock)
        {
            return stock * price;
        }
    }
}
