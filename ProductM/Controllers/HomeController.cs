using Microsoft.AspNetCore.Mvc;
using ProductM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ProductM.Controllers
{
    public class HomeController : Controller
    {
       
        private static List<Product> _products = new List<Product>()
        {
            
            new Product { Id = 1, Name = "Laptop Bilgisayar", Description = "Yüksek performanslı oyun laptopu", Price = 35000.50m },
            new Product { Id = 2, Name = "Kablosuz Klavye", Description = "RGB Işıklı Mekanik Klavye", Price = 1250.00m },
            new Product { Id = 3, Name = "Monitor", Description = "27 inch IPS Panel", Price = 7800.75m },
            new Product { Id = 4, Name = "Kablosuz Mouse", Description = "Ergonomik tasarımlı, uzun ömürlü pil", Price = 450.00m },
            new Product { Id = 5, Name = "USB Bellek 64GB", Description = "Hızlı veri aktarımı sağlayan USB 3.0 bellek", Price = 150.00m },
            new Product { Id = 6, Name = "Harici Hard Disk 1TB", Description = "Yüksek kapasiteli taşınabilir depolama", Price = 1200.00m },
            new Product { Id = 7, Name = "Webcam Full HD", Description = "Online toplantılar ve video kaydı için 1080p webcam", Price = 600.00m },
            new Product { Id = 8, Name = "Kulaklık (Gürültü Engelleme)", Description = "Aktif gürültü engelleme özellikli Bluetooth kulaklık", Price = 900.00m },
            new Product { Id = 9, Name = "Router Wi-Fi 6", Description = "En yeni nesil, yüksek hızlı Wi-Fi yönlendirici", Price = 1100.00m },
            new Product { Id = 10, Name = "Akıllı Saat", Description = "Adım sayar, kalp ritmi ölçer ve bildirim gösterir", Price = 2500.00m },
    };

        private static int _nextId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1; // Liste boşsa 1'den başlat

        public IActionResult Index()
        {
            return View(_products.OrderBy(p => p.Name).ToList()); // İsime göre sıralı
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // ID gelmediyse Hata
            }

            // ID'ye göre ürünü listede bul
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Ürün bulunamadıysa Hata
            }

            // Bulunan ürünü Details View'ına gönder
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _nextId++; // Yeni ID ata ve sayacı artır
                _products.Add(product);  // Listeye ekle
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Mevcut ürünü bul
                var existingProduct = _products.FirstOrDefault(p => p.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                }
                else
                {
                    return NotFound(); // Güncellenecek ürün bulunamadı
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product); // Listeden kaldır
            }
            return RedirectToAction(nameof(Index));
        }

        // Standart Error action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}