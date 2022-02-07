using App.Models;
using ApplicationCore.Entities.Interfaces;
using ApplicationCore.Entities.Main;
using ApplicationCore.Interfaces.Base;
using ApplicationCore.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace App.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IEFRepository<Worker> WorkerRepository;
		private readonly IWorkerService WorkerService;


        [BindProperty]
        public WorkersViewModel Worker { get; set; }

        public UpdateModel(IEFRepository<Worker> workerRepository,
                           IWorkerService workerService)
        {
            WorkerRepository = workerRepository;
			WorkerService = workerService;
        }

        public async Task OnGet(int id)
        {
            Worker currentWorker = await WorkerRepository.FindAsync(id);
            Worker = currentWorker.Adapt<WorkersViewModel>();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var newModel = Worker.Adapt<Worker>();
                await WorkerService.UpdateAsync(newModel);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}