using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ComputerShop.DTO;
using ComputerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ComputerShop.Pages
{
    public static class Constants
    {
        public const string CPU = "cpu";
        public const string VGA = "vga";
        public const string MEMORY = "memory";
        public const string MONITOR = "monitor";
        public const string MOTHERBOARD = "motherboard";
    }

    public static class CategoryId
    {
        public const int VGA_ID = 1;
        public const int CPU_ID = 2;
        public const int MEMORY_ID = 3;
        public const int MONITOR_ID = 4;
        public const int MOTHERBOARD_ID = 5;
    }

    public enum Component
    {
        CPU, VGA, MOTHERBOARD, MEMORY, MONITOR
    }

    public class ComputerBuilderModel : PageModel
    {
        private readonly ShopContext context;
        private readonly ISession session;

        [BindProperty]
        public int CpuId { get; set; }
        [BindProperty]
        public IList<Product> Cpus { get; set; }

        [BindProperty]
        public int VgaId { get; set; }
        [BindProperty]
        public IList<Product> Vgas { get; set; }

        [BindProperty]
        public int MemoryId { get; set; }
        [BindProperty]
        public IList<Product> Memories { get; set; }

        [BindProperty]
        public int MonitorId { get; set; }
        [BindProperty]
        public IList<Product> Monitors { get; set; }

        [BindProperty]
        public int MotherboardId { get; set; }
        [BindProperty]
        public IList<Product> Motherboards { get; set; }

        public IList<Compatible> Compatibles { get; set; }

        public ComputerBuilderModel(ShopContext _context, IHttpContextAccessor httpContextAccessor)
        {
            context = _context;
            session = httpContextAccessor.HttpContext.Session;
        }

        public async Task init()
        {
            Cpus = await (from p in context.Product
                          where p.Category.Name.Equals(Constants.CPU, StringComparison.OrdinalIgnoreCase)
                          select p).ToListAsync();

            Vgas = await (from p in context.Product
                          where p.Category.Name.Equals(Constants.VGA, StringComparison.OrdinalIgnoreCase)
                          select p).ToListAsync();

            Memories = await (from p in context.Product
                              where p.Category.Name.Equals(Constants.MEMORY, StringComparison.OrdinalIgnoreCase)
                              select p).ToListAsync();

            Monitors = await (from p in context.Product
                              where p.Category.Name.Equals(Constants.MONITOR, StringComparison.OrdinalIgnoreCase)
                              select p).ToListAsync();

            Motherboards = await (from p in context.Product
                              where p.Category.Name.Equals(Constants.MOTHERBOARD, StringComparison.OrdinalIgnoreCase)
                              select p).ToListAsync();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await init();

            // Get ids from session
            if (session.Get("computer") != null)
            {
                var data = session.GetString("computer");
                if (data != null && data != "")
                {
                    ComputerDTO computer = JsonConvert.DeserializeObject<ComputerDTO>(data);

                    // CPU - Motherboard
                    if (computer.CpuId != null)
                    {

                       var query =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.CpuId && product.CategoryID == CategoryId.MOTHERBOARD_ID
                           select product;

                        Motherboards = query.ToList();
                    }

                     // Motherboard - CPU, VGA, Memory
                    if (computer.MotherboardId != null)
                    {

                        var cpuQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.MotherboardId && product.CategoryID == CategoryId.CPU_ID
                           select product;

                        Cpus = cpuQuery.ToList();

                        var vgaQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.MotherboardId && product.CategoryID == CategoryId.VGA_ID
                           select product;

                        Vgas = vgaQuery.ToList();

                        var memoryQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.MotherboardId && product.CategoryID == CategoryId.MEMORY_ID
                           select product;

                        Memories = memoryQuery.ToList();

                    }

                    // VGA - Motherboard, Monitor
                    if (computer.VgaId != null)
                    {
                        var motherboardQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.VgaId && product.CategoryID == CategoryId.MOTHERBOARD_ID
                           select product;

                        Motherboards = motherboardQuery.ToList();

                        var monitorQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.VgaId && product.CategoryID == CategoryId.MONITOR_ID
                           select product;

                        Monitors = monitorQuery.ToList();
                    }

                    // Memory - Motherboard
                    if (computer.MemoryId != null)
                    {
                        var motherboardQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.MemoryId && product.CategoryID == CategoryId.MOTHERBOARD_ID
                           select product;

                        Motherboards = motherboardQuery.ToList();
                    }

                    // Monitor - VGA
                    if (computer.MonitorId != null)
                    {
                        var vgaQuery =
                           from compatible in context.Compatible
                           join product in context.Product on compatible.ProductId equals product.ID
                           where compatible.CompatibleProductId == computer.MonitorId && product.CategoryID == CategoryId.VGA_ID
                           select product;

                        Vgas = vgaQuery.ToList();
                    }

                }
            }

            
            
            
            return Page();
        }

        public IActionResult OnPostCpu()
        {
            AddComputerToSession(CpuId, Component.CPU);
            return RedirectToAction("OnGetAsync");
        }

        public IActionResult OnPostVga()
        {
            AddComputerToSession(VgaId, Component.VGA);
            return RedirectToAction("OnGetAsync");
        }

        public IActionResult OnPostMemory()
        {
            AddComputerToSession(MemoryId, Component.MEMORY);
            return RedirectToAction("OnGetAsync");
        }

        public IActionResult OnPostMonitor()
        {
            AddComputerToSession(MonitorId, Component.MONITOR);
            return RedirectToAction("OnGetAsync");
        }

        public IActionResult OnPostMotherboard()
        {
            AddComputerToSession(MotherboardId, Component.MOTHERBOARD);
            return RedirectToAction("OnGetAsync");
        }

        public void AddComputerToSession(int id, Component component)
        {
            if (session.Get("computer") == null)
            {
                ComputerDTO computer = new ComputerDTO();
                computer = SetComponent(computer, component, id);
                var data = JsonConvert.SerializeObject(computer);
                session.SetString("computer", data);
            }
            else
            {
                var data = session.GetString("computer");
                ComputerDTO computer = JsonConvert.DeserializeObject<ComputerDTO>(data);
                computer = SetComponent(computer, component, id);
                var newData = JsonConvert.SerializeObject(computer);
                session.SetString("computer", newData);
            }
        }

        public ComputerDTO SetComponent(ComputerDTO computer, Component component, int id)
        {
            switch (component)
            {
                case Component.CPU:
                    computer.CpuId = id;
                    break;
                case Component.MEMORY:
                    computer.MemoryId = id;
                    break;
                case Component.VGA:
                    computer.VgaId = id;
                    break;
                case Component.MOTHERBOARD:
                    computer.MotherboardId = id;
                    break;
                case Component.MONITOR:
                    computer.MonitorId = id;
                    break;
                default:
                    break;
            }
            return computer;
        }

        public void AddSelectedIdToSession(int id)
        {
            if (session.Get("compatibles") == null)
            {
                List<int> IntegerList = new List<int>();
                IntegerList.Add(id);
                byte[] bytes = IntegerList.SelectMany(BitConverter.GetBytes).ToArray();
                session.Set("compatibles", bytes);
            }
            else
            {
                byte[] bytes = session.Get("compatibles");
                List<int> IntegerList = ToListOf<int>(bytes, BitConverter.ToInt32);
                IntegerList.Add(id);
                bytes = IntegerList.SelectMany(BitConverter.GetBytes).ToArray();
                session.Set("compatibles", bytes);
            }
        }

        static List<T> ToListOf<T>(byte[] array, Func<byte[], int, T> bitConverter)
        {
            var size = Marshal.SizeOf(typeof(T));
            return Enumerable.Range(0, array.Length / size)
                             .Select(i => bitConverter(array, i * size))
                             .ToList();
        }
    }
}