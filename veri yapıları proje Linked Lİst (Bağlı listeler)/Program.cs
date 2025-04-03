using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
namespace veri_yapıları_proje_Linked_Lİst__Bağlı_listeler_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste cydaListe = new Liste(); //Bağlı liste sınıfından bir nesne oluşturur
            int sayi, indis;
            int secim = menu();

            while (secim != 0) //seçim 0 olana kadar devam et
            {
                switch (secim)
                {
                    case 1: 
                        Console.Write("sayı: ");
                        sayi = Convert.ToInt32(Console.ReadLine()); //kullanıcıya sayı girilmesi istenir
                        cydaListe.basaEkle(sayi); //başa sayı ekler
                        cydaListe.yazdir();
                        break;

                    case 2:
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaListe.sonaEkle(sayi); //sona sayı ekler
                        cydaListe.yazdir();
                        break;

                    case 3:
                        Console.Write("indis: "); //dizideki sırası
                        indis = int.Parse(Console.ReadLine());
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine()); 
                        cydaListe.arayaEkle(indis, sayi); //araya sayı ekler
                        cydaListe.yazdir();
                        break;
                        case 4:cydaListe.bastanSil(); cydaListe.yazdir(); //baştan sayı siler
                        break;
                        case 5: cydaListe.sondanSil(); cydaListe.yazdir(); //sondan sayı siler
                        break;
                        case 6:
                        Console.Write("indis:"); indis=int.Parse(Console.ReadLine());
                        cydaListe.aradanSil(indis); cydaListe.yazdir(); //aradan sayı siler
                       break;
                        case 7: cydaListe.terstenYazdir(); //sayıları tersten yazdırır
                        break ;
                        case 0:
                            break;
                       //break: case yani seçimi yaptıktan sonra çıkışı caseden çıkışı sağlar

                    default: //yukarıda belirtilen sayılardan başka bir sayı girildiği zaman devreye girer
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }
                secim = menu();
                Console.Clear(); //ekranı temizler
                

            }
            Console.WriteLine("program kapatıldı");
            Console.ReadKey();
        }
        private static int menu() //menü fonksiyonu
        {
            int secim; //kullanıcının seçim yaptığı değişkenler
            Console.WriteLine("1-basa ekle");
            Console.WriteLine("2-sona ekle");
            Console.WriteLine("3-araya ekle");
            Console.WriteLine("4-bastan sil");
            Console.WriteLine("5-sondan sil");
            Console.WriteLine("6-aradan sil");
            Console.WriteLine("7-tersten yazdır");
            Console.WriteLine("0-programı kapat");
            Console.WriteLine("seçiminiz:");
            secim=int.Parse(Console.ReadLine());
            return secim; //kullanıcı seçimi döndürülür
        }
    }
    class Node //Bağlı listenin düğüm (Node)yapısını tanımlar
    {
        public int data; //düğümdeki veri
        public Node next; //sonraki düğüme işaret eden referans
        public Node prev; //önceki düğüme işaret eden referans

        public Node (int data)
        {
            this.data = data; //düğüme veri atanır
            this.next = null; //başlangıçta sonraki düğüm boş
            this.prev = null; //başlangıçta önceki düğüm boş
        }
    }
    class Liste //bağlı listeyi temsil eden sınıf
    {
        Node head; //listenin başındaki düğümü tutar
        Node tail; //listenin sonundaki düğümü tutar

        public Liste()
        {
            //liste yapısının başlangıçta boş olduğunu belirtmek için head ve tail
            this.head = null;
            this.tail = null;
        }
        public void basaEkle (int data)
        {
            //yeni bir düğüm (Node) oluşturulur ve eklenmek istenen veri eklenir
            Node eleman=new Node (data);

            if(head==null) //eğer liste boşsa
            {
                //baş ve son aynı düğüm olacak şekilde atanır
                head = tail = eleman;
                //düğümün kendine döngüsel olarak bağlanması sağlanır
                tail.next = head;
                tail.prev=head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("liste yapısı oluşturuldu,ilk eleman eklendi");
            }
            else //eğer liste doluysa
            {
                //yeni düğüm,mevcut baş düğümü işaret edecek şekilde bağlanır
                eleman.next = head;
                //mevcut baş düğümün önceki düğümü,yeni düğümü işaret eder
                head.prev = eleman;
                //yeni düğüm listenin baş düğümü olur
                head = eleman;
                //listenin son düğümünün,başa bağlanması sağlanır
                head.prev = tail;
                tail.next = head;
                Console.WriteLine("başa eleman eklendi");
            }

        }
        public void sonaEkle(int data)
        {
            Node eleman=new Node (data);

            if (head==null)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev=head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("liste yapısı oluşturuldu,ilk eleman eklendi");
            }
            //yukarıdaki kısımla aynı terimler
            else
            {
                tail.next = eleman;
                eleman.prev = tail;
                tail = eleman;
                tail.next = head;
                head.prev = tail;
                Console.WriteLine("sona eleman eklendi");
            }
        }
        public void arayaEkle(int indis,int data)
        {
            Node eleman=new Node (data);

            if (head==null&& indis==0)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("liste yapısı oluşturuldu,ilk eleman eklendi");
            }
            else if(head!=null &&indis==0)
            {
                basaEkle(data); //başa ekleme fonksiyonu çağırılır
            }
            else
            {
                int i = 0; //indis sayacı
                Node temp=head; //geçici düğüm baştan başlayarak hareket eder
                Node temp2 = temp; //geçici düğümün bir önceki düğümü

                while (temp!=tail) //Liste boyunca dönülerek doğru indisi buluruz
                {
                    if(i==indis)
                    {
                        temp2.next = eleman; //Önceki düğümün sonraki işaretçisi, yeni düğümü işaret eder
                        eleman.prev = temp2; //Yeni düğümün önceki işaretçisi, önceki düğümü işaret eder
                        eleman.next = temp; //Yeni düğümün sonraki işaretçisi, mevcut düğümü işaret eder
                        temp.prev = eleman; //Mevcut düğümün önceki işaretçisi, yeni düğümü işaret eder
                        Console.WriteLine("araya eleman eklendi");
                        i++;
                        break;
                    }
                    temp2 = temp; //bir sonraki adım için temp2 güncellenir
                    temp = temp.next; //ilerleme sağlanır

                    i++;

                }
                if (i==indis) //döngü sonunda indise ulaşıldıysa
                {
                    temp2.next = eleman; //aynı işlemler tekrar edilir
                    eleman.prev=temp2;
                    eleman.next = temp;
                    temp.prev = eleman;
                    Console.WriteLine("araya eleman eklendi");
                }
            }
        }
        public void yazdir() 
        {
            //Listenin boş olup olmadığını kontrol ediyoruz
            if (head == null)
                Console.WriteLine("liste boş");
            else
            {
                //Listenin başından başlayarak tüm düğümleri yazdırıyoruz
                Node temp = head; //Geçici düğümü baş düğüme atıyoruz
                Console.Write("baş->");
                while (temp!=tail) //Son düğüme ulaşana kadar devam ediyoruz
                {
                    Console.Write(temp.data + "->");//Mevcut düğümün verisini yazdırıyoruz
                    temp =temp.next; // Bir sonraki düğüme geçiyoruz
                }
                Console.WriteLine(temp.data + "son.");
            }
        }
        public void terstenYazdir()
        {
            //Listenin boş olup olmadığını kontrol ediyoruz
            if (head == null)
                Console.WriteLine("liste boş");

            else
            {
                //Listenin sonundan başlayarak düğümleri tersten yazdırıyoruz
                Node temp = tail; //Geçici düğümü kuyruk düğüme atıyoruz
                Console.Write("Son->");
                while(temp!=head) //Baş düğüme ulaşana kadar devam ediyoruz
                {
                    Console.Write(temp.data + "->"); //Mevcut düğümün verisini yazdırıyoruz
                    temp = temp.prev; //Bir önceki düğüme geçiyoruz
                }
                Console.WriteLine(temp.data + "baş.");
            }
        }
        public void bastanSil()
        {
            // Listenin boş olup olmadığını kontrol ediyoruz
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head) // Listede tek düğüm varsa
            {
                head = tail = null; // Düğümü siliyoruz ve listeyi boş hale getiriyoruz
                Console.WriteLine("eleman silindi,listede eleman kalmadı");
            }
            else
            {
                // Baş düğümü silip başı bir sonraki düğüme kaydırıyoruz
                head = head.next;
                head.prev = tail;
                tail.next = head;
                Console.WriteLine("baştan eleman silindi");
            }
        }

        public void sondanSil()
        {
            // Listenin boş olup olmadığını kontrol ediyoruz
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head) // Listede tek düğüm varsa
            {
                head = tail = null; // Düğümü siliyoruz ve listeyi boş hale getiriyoruz
                Console.WriteLine("eleman silindi,listede eleman kalmadı");
            }
            else
            {
                // Kuyruk düğümünü silip kuyruk göstergesini bir önceki düğüme kaydırıyoruz
                tail = tail.prev;
                tail.next = head;
                head.prev = tail;
                Console.WriteLine("sondan eleman silindi");
            }
        }

        public void aradanSil(int indis)
        {
            //Listenin boş olup olmadığını kontrol ediyoruz
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head && indis == 0) //Listede tek düğüm varsa ve o düğüm silinecekse
            {
                head = tail = null; //Düğümü siliyoruz ve listeyi boş hale getiriyoruz
                Console.WriteLine("eleman silindi,listede eleman kalmadı ");
            }
            else if (head.next != head && indis == 0) //Eğer baş düğüm silinecekse
            {
                bastanSil();
            }
            else
            {
                //Aradaki düğümü silmek için geçici bir düğüm kullanıyoruz
                Node temp = head;
                Node temp2 = temp;
                int i = 0; //Düğüm indeksini takip etmek için sayaç
                while (temp != tail)
                {
                    if (i == indis) //İstenen indeksi bulursak
                    {
                        temp2.next = temp.next; //Düğüm bağlantılarını düzenliyoruz
                        temp.next.prev = temp2;
                        Console.WriteLine("aradan eleman silindi");
                        i++;
                        break;
                    }
                    temp2 = temp; //Bir sonraki döngü için geçici düğümleri ilerletiyoruz
                    temp = temp.next;
                    i++;
                }
                if (i == indis) //Eğer kuyruk düğümü silinecekse
                {
                    sondanSil();
                }
            }
        }
    }
}
