using App.Models;
using ApplicationCore.Entities.Main;
using ApplicationCore.Interfaces.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<WorkersViewModel> ongetWorkers;

        private readonly IEFRepository<Worker> WorkerRepository;

        [BindProperty]
        public Worker Worker { get; set; }

        public IndexModel(IEFRepository<Worker> workerRepository)
        {
            WorkerRepository = workerRepository;
        }

        public async void OnGet(int OrderId = 0)
        {
            //  DTO(data transfer object) model
            //  получение списка воркеров
            var getWorkers = await WorkerRepository.ListAsync();

            if (OrderId == 1) getWorkers = getWorkers.OrderByDescending(x => x.Id);
            // mapping
            // преобразование списка воркеров в список вьюмоделей воркеров и профилей
            ongetWorkers = getWorkers.Adapt<IEnumerable<WorkersViewModel>>();
        }


        public async Task<IActionResult> OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                await WorkerRepository.AddAsync(Worker);
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToAction("OnPostAdd",Worker);
            }
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            await WorkerRepository.DeleteAsync(id);
            return RedirectToPage("Index");
        }

    }
}

